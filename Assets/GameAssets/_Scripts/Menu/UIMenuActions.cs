#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuActions : MonoBehaviour
{
    [SerializeField]
    private Texture2D _mouseTexture;

    void Start()
    {
        Cursor.SetCursor(_mouseTexture, Vector2.zero, CursorMode.Auto);
    }

    public void PlayGame(string sceneName)
    {
        GlobalActions.IsShotGunDroped = false;
        GlobalActions.ChangedWeapon = false;
        GlobalActions.HasRevolver = false;
        GlobalActions.HasMachineGun = false;
        GlobalActions.HasShotGun = false;
        GlobalActions.IsBossDead = false;
        GlobalActions.BossDrop = false;
        GlobalActions.PlayerHasStone = false;

        SceneManager.LoadScene(sceneName);
    }

    public void Credits(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void RestartLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
