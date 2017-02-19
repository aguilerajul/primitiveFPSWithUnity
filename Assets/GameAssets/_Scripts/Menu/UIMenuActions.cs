using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuActions : MonoBehaviour {

    public void PlayGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Credits(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void RestartLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1.0F;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
