using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    public void GoToGameScene()
    {
        SceneManager.LoadScene("PlayingScene");
    }

    public void GoToRankingScene()
    {
        SceneManager.LoadScene("RankingScene");
    }

    public void GoToMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}