using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string GameScene = "GameScene";
    public string ScoreScene = "Scoreboard";

    public SceneFader sceneFader;
    public void Play()
    {
        sceneFader.FadeTo(GameScene);
    }
    public void Scoreboard()
    {
        sceneFader.FadeTo(ScoreScene);
    }
    public void Quit()
    {
        Debug.Log("Exciting...");
        Application.Quit();

    }
}