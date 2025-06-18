using Cinemachine;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 50;
    [SerializeField] CinemachineVirtualCamera deathVirtualCamera;
    [SerializeField] Transform weaponCameraTransform;
    [SerializeField] Image[] shieldBars;

    int currentHealth;
    int gameOverVirtualCameraPriority = 20;
    int eachBarValue;

    private void Awake()
    {
        currentHealth = maxHealth;
        eachBarValue = maxHealth / shieldBars.Length;
    }

    void Start()
    {
        UpdateShieldUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateShieldUI();

        if (currentHealth <= 0)
        {
            weaponCameraTransform.parent = null;
            deathVirtualCamera.Priority = gameOverVirtualCameraPriority;

            Destroy(gameObject);
        }
    }

    private void UpdateShieldUI()
    {
        int currentBarAmount = currentHealth / eachBarValue;
        for (int i = 0; i < shieldBars.Length; i++)
        {
            shieldBars[i].enabled = (i < currentBarAmount);
        }
    }
}
