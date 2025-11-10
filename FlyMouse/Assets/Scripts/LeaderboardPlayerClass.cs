using System;

public class LeaderboardPosition
{
    public string name;
    public float score;
    public float position;

    public LeaderboardPosition(string name, float score, float position)
    {
        this.name = name;
        this.score = score;
        this.position = position;
    }
    public string ScoreTimed()
    {
        if (name == "N/A")
        {
            return "N/A";
        }
        float scoreSeconds = score - 1;
        int minutes = (int)Math.Floor(scoreSeconds / 60);
        scoreSeconds -= minutes * 60;
        if (minutes == 0)
        {
            return Math.Round(scoreSeconds, 2).ToString()+"s";
        }
        else
        {
            return minutes.ToString() + " : " + Math.Round(scoreSeconds, 2).ToString()+"s";
        }
    }
}
