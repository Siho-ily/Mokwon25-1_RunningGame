using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}