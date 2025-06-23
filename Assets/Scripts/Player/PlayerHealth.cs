using Cinemachine;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;
using StarterAssets;
using System;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 50;
    [SerializeField] CinemachineVirtualCamera deathVirtualCamera;
    [SerializeField] Transform weaponCameraTransform;
    [SerializeField] Image[] shieldBars;
    [SerializeField] TMP_Text hpText;
    [SerializeField] GameObject gameoverPanel;

    float currentHealth;
    int gameOverVirtualCameraPriority = 20; //The more the number, the more priority it will have.
    int eachBarValue;
    GameManager gameManager;

    private void Awake()
    {
        currentHealth = maxHealth;
        eachBarValue = maxHealth / shieldBars.Length;
    }

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        UpdateShieldUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateShieldUI();

        if (currentHealth <= 0)
        {
            PlayerGameOver();
        }
    }

    void PlayerGameOver()
    {
        weaponCameraTransform.parent = null;
        deathVirtualCamera.Priority = gameOverVirtualCameraPriority;

        gameManager.GameOver();

        Destroy(gameObject);
    }

    private void UpdateShieldUI()
    {
        hpText.text = currentHealth.ToString();
        int currentBarAmount = (int)Math.Ceiling(currentHealth / eachBarValue);
        for (int i = 0; i < shieldBars.Length; i++)
        {
            shieldBars[i].enabled = (i < currentBarAmount);
        }
    }
}
