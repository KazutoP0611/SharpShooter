using StarterAssets;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    //[SerializeField] private Transform targetTransform;
    private NavMeshAgent bot;
    private FirstPersonController player;

    const string PLAYER_STRING = "Player";

    private void Awake()
    {
        bot = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        //bot.SetDestination(targetTransform.position); 
        player = FindFirstObjectByType<FirstPersonController>();
    }

    private void Update()
    {
        if (!player) return;
        
        bot.SetDestination(player.transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_STRING))
        {
            EnemyHealth enemyHealth = GetComponent<EnemyHealth>();
            enemyHealth.SelfDestruct();
        }
    }
}
