using System.Numerics;
using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;

    [SerializeField] private GameObject hitVFX;
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem muzzleFlashParticle;

    StarterAssetsInputs starterAssetsInputs;

    const string SHOOT_STRING = "Recoil";

    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    void Start()
    {
        //Debug.LogWarning(starterAssetsInputs);
    }

    void Update()
    {
        HandleShoot();
    }

    private void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return;

        muzzleFlashParticle.Play();
        animator.Play(SHOOT_STRING, 0, 0f);
        starterAssetsInputs.ShootInput(false);

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            Instantiate(hitVFX, hit.point, UnityEngine.Quaternion.identity);

            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(weaponSO.Damage);
        }
    }
}
