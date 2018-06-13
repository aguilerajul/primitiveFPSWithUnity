using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeController : LifeController
{
    protected override void Die()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene("GameOver");
    }
}
