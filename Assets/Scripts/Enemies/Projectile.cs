using Unity.Mathematics;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float projectileSpeed = 8f;
    [SerializeField] GameObject hitVFX;

    int damage = 10;

    void Start()
    {
        rb.linearVelocity = transform.forward * projectileSpeed;
    }

    public void Init(int damage)
    {
        this.damage = damage;
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        playerHealth?.TakeDamage(damage);

        Instantiate(hitVFX, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
