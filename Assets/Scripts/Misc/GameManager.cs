using TMPro;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text enemyCountText;
    [SerializeField] GameObject gameOverPanel;

    int enemyLeft = 0;

    //const string ENEMIES_LEFT_STRING = "";

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
        gameOverPanel.SetActive(true);
        StarterAssetsInputs starterAssetInputs = FindFirstObjectByType<StarterAssetsInputs>();
        starterAssetInputs.SetCursorState(false);
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
}
