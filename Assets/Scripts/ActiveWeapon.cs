using StarterAssets;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;

    StarterAssetsInputs starterAssetsInputs;
    Animator animator;
    Weapon currentWeapon;
    float shotCoolDown = 0f;
    bool justShot = false;
    bool zoomingIN = false;

    const string SHOOT_STRING = "Recoil";

    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        currentWeapon = GetComponentInChildren<Weapon>();
        InitWeapon();
    }

    void InitWeapon()
    {
        shotCoolDown = weaponSO.FireRate;

        justShot = false;
        shotCoolDown = weaponSO.FireRate;
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
            shotCoolDown = weaponSO.FireRate;
        }
    }

    private void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return;

        if (!justShot)
        {
            justShot = true;
            animator.Play(SHOOT_STRING, 0, 0f);
            currentWeapon.Shoot(weaponSO);
        }

        if (!weaponSO.IsAutomatic)
        {
            starterAssetsInputs.ShootInput(false);
        }
    }

    private void HandleZoom()
    {
        if (!weaponSO.CanZoom) return;

        if (starterAssetsInputs.zoom)
        {
            
        }
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        if (currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
        }

        Weapon newWeapon = Instantiate(weaponSO.WeaponPrefab, transform).GetComponent<Weapon>();
        currentWeapon = newWeapon;
        this.weaponSO = weaponSO;
        InitWeapon();
    }
}
