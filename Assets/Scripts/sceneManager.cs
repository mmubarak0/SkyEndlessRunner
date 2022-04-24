using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public GameObject howToPlayUI;
    public GameObject optionsUI;
    public GameObject HUD;

    public void StartEndlessRunner()
    {
        Time.timeScale = 1f;
        Obstacles.obstacleDestroyTime = 0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public static void GoToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void HowToPlay()
    {
        HUD.SetActive(false);
        howToPlayUI.SetActive(true);
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }
    public void ShowOptions()
    {
        HUD.SetActive(false);
        optionsUI.SetActive(true);
    }
}
