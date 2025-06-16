using StarterAssets;
using UnityEngine;
using Cinemachine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Assertions.Must;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO startWeaponSO;
    [SerializeField] CinemachineVirtualCamera playerFollowCamera;
    [SerializeField] TMP_Text ammoText;

    [Header("Zoom Settings")]
    [SerializeField] int zoomFOV = 5;
    [SerializeField] Camera weaponCamera;
    [SerializeField] GameObject zoomVignette;

    WeaponSO currentWeaponSO;
    StarterAssetsInputs starterAssetsInputs;
    Animator animator;
    Weapon currentWeapon;
    FirstPersonController firstPersonController;

    float shotCoolDown = 0f;
    bool justShot = false;
    bool zoomingIN = false;
    float defaultLensFOV;
    float defaultRotationSpeed;
    int currentAmmo;

    const string SHOOT_STRING = "Recoil";

    void Awake()
    {
        firstPersonController = GetComponentInParent<FirstPersonController>();
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
        defaultLensFOV = playerFollowCamera.m_Lens.FieldOfView;
        defaultRotationSpeed = firstPersonController.RotationSpeed;
    }

    void Start()
    {
        SwitchWeapon(startWeaponSO);
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        if (currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
        }

        Weapon newWeapon = Instantiate(weaponSO.WeaponPrefab, transform).GetComponent<Weapon>();
        currentWeapon = newWeapon;
        currentWeaponSO = weaponSO;
        InitWeapon();
    }

    void InitWeapon()
    {
        justShot = false;
        shotCoolDown = currentWeaponSO.FireRate;
        shotCoolDown = currentWeaponSO.FireRate;
        UpdateAmmo(currentWeaponSO.AmmoAmount);
    }

    void Update()
    {
        HandleShoot();
        HandleZoom();

        if (justShot)
        {
            shotCoolDown -= Time.deltaTime;
        }

        if (justShot && shotCoolDown <= 0)
        {
            justShot = false;
            shotCoolDown = currentWeaponSO.FireRate;
        }
    }

    public void UpdateAmmo(int ammoAmount)
    {
        currentAmmo += ammoAmount;

        if (currentAmmo > currentWeaponSO.AmmoAmount)
        {
            currentAmmo = currentWeaponSO.AmmoAmount;
        }

        ammoText.text = currentAmmo.ToString("D2");
    }

    private void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return;

        if (!justShot && currentAmmo > 0)
        {
            justShot = true;
            animator.Play(SHOOT_STRING, 0, 0f);
            currentWeapon.Shoot(currentWeaponSO);

            UpdateAmmo(-1);
        }

        if (!currentWeaponSO.IsAutomatic)
        {
            starterAssetsInputs.ShootInput(false);
        }
    }

    private void HandleZoom()
    {
        if (!currentWeaponSO.CanZoom) return;

        // playerFollowCamera.m_Lens.FieldOfView = starterAssetsInputs.zoom ? currentWeaponSO.ZoomAmount : defaultLensFOV;
        // weaponCamera.fieldOfView = starterAssetsInputs.zoom ? currentWeaponSO.ZoomAmount : defaultLensFOV;

        if (zoomingIN != starterAssetsInputs.zoom)
        {
            zoomingIN = starterAssetsInputs.zoom;

            playerFollowCamera.m_Lens.FieldOfView = starterAssetsInputs.zoom ? currentWeaponSO.ZoomAmount : defaultLensFOV;
            weaponCamera.fieldOfView = starterAssetsInputs.zoom ? currentWeaponSO.ZoomAmount - 5 : defaultLensFOV;
            zoomVignette.SetActive(zoomingIN);
            firstPersonController.ChangeRotationSpeed(zoomingIN ? currentWeaponSO.CameraSpeedWhenZoom / 100 : defaultRotationSpeed);
        }
    }
}
