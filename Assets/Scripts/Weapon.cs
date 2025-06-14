using UnityEngine;

public class Weapon : MonoBehaviour
{   
    [SerializeField] private ParticleSystem muzzleFlashParticle;

    public void Shoot(WeaponSO weaponSO)
    {
        muzzleFlashParticle.Play();

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            Instantiate(weaponSO.HitVFX, hit.point, Quaternion.identity);

            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(weaponSO.Damage);
        }
    }
}
