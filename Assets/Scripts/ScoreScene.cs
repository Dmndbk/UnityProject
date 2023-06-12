using UnityEngine;
using UnityEngine.SceneManagement;
public class ScoreScene : MonoBehaviour
{
    public string SceneToLoad = "MainScene";
    

    public SceneFader sceneFader;
    public void Back()
    {
        sceneFader.FadeTo(SceneToLoad);
    }

}
