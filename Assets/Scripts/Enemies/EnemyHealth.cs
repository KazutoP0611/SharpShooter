using UnityEditor;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 30;
    [SerializeField] GameObject explosionParticle;
    [SerializeField] Vector3 sfxSpawnOffset;

    [Header("Explosion Settings")]
    [SerializeField] CapsuleCollider explosionCapsuleCollider;
    [SerializeField] bool useTheSameRadiusAsPlayerDetectExplosion = true;
    [SerializeField] float explosionRadius;

    int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            SelfDestruct();
        }
    }

    public void SelfDestruct()
    {
        Vector3 spawnPosition = transform.position;
        spawnPosition += sfxSpawnOffset;

        Explosion explosion = Instantiate(explosionParticle, spawnPosition, Quaternion.identity).GetComponent<Explosion>();
        explosion.SetExplosionRadius(useTheSameRadiusAsPlayerDetectExplosion ? explosionCapsuleCollider.radius : explosionRadius);
        explosion.Explode();

        Destroy(gameObject);
    }
}

// [CustomEditor(typeof(EnemyHealth))]
// public class EnemyHealth_Editor : Editor
// {
//     public override void OnInspectorGUI()
//     {
//         var script = (EnemyHealth)target;

//         script.maxHealth = EditorGUILayout.IntField("Max Health", script.maxHealth);
//         script.explosionParticle = EditorGUILayout.ObjectField("Explosion Particle", script.explosionParticle, typeof(GameObject), true) as GameObject;
//         script.sfxSpawnOffset = EditorGUILayout.Vector3Field("SFX Spawn Offset", script.sfxSpawnOffset);
//         script.explosionCapsuleCollider = EditorGUILayout.ObjectField("Explosion Capsule Collider", script.explosionCapsuleCollider, typeof(CapsuleCollider), true) as CapsuleCollider;
//         script.useTheSameRadiusAsPlayerDetectExplosion = EditorGUILayout.Toggle("Use Same Radius", script.useTheSameRadiusAsPlayerDetectExplosion);

//         if (script.useTheSameRadiusAsPlayerDetectExplosion) return;

//         script.explosionRadius = EditorGUILayout.FloatField("Explosion Radius", script.explosionRadius);
//     }
// }
