using TMPro;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Threading;

public enum UIPanel
{
    StartPanel = 0,
    RestartPanel = 1
}

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text enemyCountText;

    [Header("General Settings")]
    [SerializeField] StarterAssetsInputs starterAssetInputs;
    [SerializeField] float startLevelCountDown = 3.0f;
    [SerializeField] GameObject surviveStartText;

    [Header("UI Panel Settings")]
    [SerializeField] GameObject gameTitleText;
    [SerializeField] GameObject gameoverTitleText;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject quitButton;
    [SerializeField] GameObject[] generalUIPanels;

    [Header("Enemy Settings")]
    [SerializeField] SpawnGate[] spawnGates;
    [SerializeField] Turret[] turrets;

    int enemyLeft = 0;

    //const string ENEMIES_LEFT_STRING = "";

    void Start()
    {
        //SceneManager.sceneLoaded += OnSceneLoaded;
        OpenUIPanel(UIPanel.StartPanel);
    }

    // void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    // {
    //     OpenUIPanel(UIPanel.StartPanel);
    // }

    public void UpdateEnemyCount(int leftAmount)
    {
        enemyLeft += leftAmount;
        enemyCountText.text = enemyLeft.ToString();

        if (enemyLeft <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        OpenUIPanel(UIPanel.RestartPanel);
    }

    public void StartLevel()
    {
        CloseUIPanel();
        StartCoroutine(StartLevelCountDown());
    }

    IEnumerator StartLevelCountDown()
    {
        surviveStartText.SetActive(true);
        starterAssetInputs.SetGetInputLookInput(true);

        yield return new WaitForSeconds(startLevelCountDown);

        surviveStartText.SetActive(false);
        starterAssetInputs.SetCursorState(true);
        starterAssetInputs.SetCanMove(true);

        //TODO - start enable input and start enemy AI;
        foreach (SpawnGate gate in spawnGates)
        {
            gate.enabled = true;
        }

        foreach (Turret turret in turrets)
        {
            turret.enabled = true;
        }
    }

    public void RestartLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OpenUIPanel(UIPanel panel)
    {
        starterAssetInputs.SetCanMove(false);
        starterAssetInputs.SetGetInputLookInput(false);
        starterAssetInputs.SetCursorState(false);
        surviveStartText.SetActive(false);

        gameTitleText.SetActive(panel == UIPanel.StartPanel);
        gameoverTitleText.SetActive(panel == UIPanel.RestartPanel);
        startButton.SetActive(panel == UIPanel.StartPanel);
        restartButton.SetActive(panel == UIPanel.RestartPanel);

        quitButton.SetActive(true);

        foreach (GameObject uiPanel in generalUIPanels)
        {
            uiPanel.SetActive(false);
        }
    }

    public void CloseUIPanel()
    {
        gameTitleText.SetActive(false);
        gameoverTitleText.SetActive(false);
        startButton.SetActive(false);
        restartButton.SetActive(false);
        quitButton.SetActive(false);

        foreach (GameObject uiPanel in generalUIPanels)
        {
            uiPanel.SetActive(true);
        }
    }
}
