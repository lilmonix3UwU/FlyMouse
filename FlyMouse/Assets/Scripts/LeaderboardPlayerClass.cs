using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
