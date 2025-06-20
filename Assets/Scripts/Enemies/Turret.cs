using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform turretHead;
    [SerializeField] Transform playerTargetPoint;
    [SerializeField] float fireDistanceThreshold = 8f;

    [Header("Projectile Settings")]
    [SerializeField] Transform projectileSpawnPoint;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float fireProjectileSetInSecs = 3f;
    [SerializeField] int numberOfProjectileInSet = 3;
    [SerializeField] float fireEverySecs = 0.12f;

    [Tooltip("Projectile already has 10 damage, os if you want to lower or higher its power, you can adjust by changning this number")]
    [SerializeField] int projectileDamage = 10;

    PlayerHealth playerHealth;
    bool fired = false;

    void Start()
    {
        fired = false;
        playerHealth = FindFirstObjectByType<PlayerHealth>();
    }

    void Update()
    {
        if (playerHealth)
        {
            turretHead.LookAt(playerTargetPoint);

            if (Vector3.Magnitude(transform.position - playerTargetPoint.position) < fireDistanceThreshold)
            {
                if (!fired)
                {
                    fired = true;
                    StartCoroutine(FireSetOfProjectile());
                }
            }
            else
            {
                StopCoroutine(FireSetOfProjectile());
                fired = false;
            }
        }
    }

    IEnumerator FireSetOfProjectile()
    {
        while (playerHealth)
        {
            Debug.Log("Fired");
            StartCoroutine(FireProjectile());
            yield return new WaitForSeconds(numberOfProjectileInSet * fireEverySecs);
            yield return new WaitForSeconds(fireProjectileSetInSecs);
        }
    }

    IEnumerator FireProjectile()
    {
        for (int i = 0; i < numberOfProjectileInSet; i++)
        {
            //Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);

            Projectile projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity).GetComponent<Projectile>();
            projectile.transform.LookAt(playerTargetPoint);
            projectile.Init(projectileDamage);

            yield return new WaitForSeconds(fireEverySecs);
        }
    }
}
