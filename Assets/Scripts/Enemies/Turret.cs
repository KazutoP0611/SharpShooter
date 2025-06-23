using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform turretHead;
    [SerializeField] Transform playerTargetPoint;
    [SerializeField] float fireDistanceThreshold = 8f;

    [Header("Projectile Settings")]
    [SerializeField] LayerMask hitLayerMask;
    [SerializeField] Transform projectileSpawnPoint;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float fireProjectileSetInSecs = 3f;
    [SerializeField] int numberOfProjectileInSet = 3;
    [SerializeField] float fireEverySecs = 0.12f;

    [Tooltip("Projectile already has 10 damage, os if you want to lower or higher its power, you can adjust by changning this number")]
    [SerializeField] int projectileDamage = 10;

    PlayerHealth playerHealth;
    bool fired = false;
    const string PLAYER_TAG_STRING = "Player";

    Coroutine FireSetProjectile;
    Coroutine FireProjectileBullet;

    void Start()
    {
        fired = false;
        playerHealth = FindFirstObjectByType<PlayerHealth>();
    }

    void Update()
    {
        if (playerHealth)
        {
            if ((transform.position - playerTargetPoint.position).magnitude < fireDistanceThreshold)
            {
                turretHead.LookAt(playerTargetPoint);
                //Debug.LogWarning((transform.position - playerTargetPoint.position).magnitude);
                RaycastHit hit;
                Physics.Raycast(projectileSpawnPoint.position, projectileSpawnPoint.transform.forward, out hit, 1000f, hitLayerMask);

                if (!fired && hit.collider.CompareTag(PLAYER_TAG_STRING))
                {
                    //Debug.Log(hit.collider.gameObject.name);
                    fired = true;
                    FireSetProjectile = StartCoroutine(FireSetOfProjectile());
                }

                if (fired && !hit.collider.CompareTag(PLAYER_TAG_STRING))
                {
                    fired = false;
                    StopCoroutine(FireSetProjectile);
                    StopCoroutine(FireProjectileBullet);
                }
            }
            else
            {
                if (fired)
                    fired = false;

                if (FireSetProjectile != null && FireProjectileBullet != null)
                {
                    StopCoroutine(FireSetProjectile);
                    StopCoroutine(FireProjectileBullet);
                }
            }
        }
    }

    IEnumerator FireSetOfProjectile()
    {
        while (playerHealth)
        {
            FireProjectileBullet = StartCoroutine(FireProjectile());
            yield return new WaitForSeconds(numberOfProjectileInSet * fireEverySecs);
            yield return new WaitForSeconds(fireProjectileSetInSecs);
        }
    }

    IEnumerator FireProjectile()
    {
        for (int i = 0; i < numberOfProjectileInSet; i++)
        {
            Projectile projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity).GetComponent<Projectile>();
            projectile.transform.LookAt(playerTargetPoint);
            projectile.Init(projectileDamage);

            yield return new WaitForSeconds(fireEverySecs);
        }
    }
}
