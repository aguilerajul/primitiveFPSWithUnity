using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuActions : MonoBehaviour
{
    [SerializeField] private Texture2D _mouseTexture;

    void Start()
    {
        Cursor.SetCursor(_mouseTexture, Vector2.zero, CursorMode.Auto);
    }

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
