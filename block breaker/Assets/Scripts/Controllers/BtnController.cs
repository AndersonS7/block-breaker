using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BtnController : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
