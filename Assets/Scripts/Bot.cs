using StarterAssets;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    //[SerializeField] private Transform targetTransform;
    private NavMeshAgent bot;
    private FirstPersonController player;

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
        bot.SetDestination(player.transform.position); 
    }
}
