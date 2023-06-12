using System;

[Serializable]
public class ScoreboardElement
{
    public string playerName;
    public int points;

    public ScoreboardElement(string name , int points)
    {
        playerName = name;
        this.points = points;
    }
}
