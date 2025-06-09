using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int damageAmount = 10;
    [SerializeField] ParticleSystem muzzleFlashParticle;

    StarterAssetsInputs starterAssetsInputs;

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

    private bool HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return false;

        muzzleFlashParticle.Play();
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(damageAmount);

            starterAssetsInputs.ShootInput(false);
        }

        return true;
    }
}
