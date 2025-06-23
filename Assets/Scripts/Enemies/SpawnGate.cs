using System.Collections;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    [Header("Enemy Spawn Settings")]
    [SerializeField] float waitSecsForBeginSpawnLoop = 0f;
    [SerializeField] GameObject botPrefab;
    [SerializeField] float spawnEnemyEverySecs = 5f;
    [SerializeField] Transform spawnPoint;

    PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(WaitBeforeStartSpawnFunction());
    }

    IEnumerator WaitBeforeStartSpawnFunction()
    {
        yield return new WaitForSeconds(waitSecsForBeginSpawnLoop);
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (playerHealth)
        {
            EnemyHealth enemyHealthComponent = Instantiate(botPrefab, spawnPoint.position, spawnPoint.rotation).GetComponent<EnemyHealth>();
            enemyHealthComponent.Init(gameManager);
            
            yield return new WaitForSeconds(spawnEnemyEverySecs);
        }
    }
}
