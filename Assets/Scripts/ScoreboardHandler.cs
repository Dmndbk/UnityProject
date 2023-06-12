using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardHandler : MonoBehaviour
{
    List<ScoreboardElement> highscoreList = new List<ScoreboardElement>();
    public int maxCount = 11;
    public string filename;

    public delegate void OnScoreboardListChanged(List<ScoreboardElement> list);
    public static event OnScoreboardListChanged onScoreboardListChanged;
    private void Start()
    {
        LoadHighscores();
    }
    private void LoadHighscores()
    {
        highscoreList = FileHandler.ReadListFromJSON<ScoreboardElement>(filename);

        while(highscoreList.Count > maxCount)
        {
            highscoreList.RemoveAt(maxCount);
        }
        if(onScoreboardListChanged != null)
        {
            onScoreboardListChanged.Invoke(highscoreList);
        }
    }
    private void SaveScore()
    {
        FileHandler.SaveToJSON<ScoreboardElement>(highscoreList, filename);
    }

    public void AddHighscore(ScoreboardElement element)
    {
        for (int i = 0; i < maxCount; i++)
        {
            if(i >= highscoreList.Count || element.points > highscoreList[i].points)
            {
                //add new score
                highscoreList.Insert(i, element);
                while (highscoreList.Count > maxCount)
                {
                    highscoreList.RemoveAt(maxCount);
                }

                SaveScore();

                if (onScoreboardListChanged != null)
                {
                    onScoreboardListChanged.Invoke(highscoreList);
                }

                break;
            }
        }
    }
}
