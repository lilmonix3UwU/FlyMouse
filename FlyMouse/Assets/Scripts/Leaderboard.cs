using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] string emptyLeaderboard = "name:0;score:0;position:0|name:0;score:0;position:0|name:0;score:0;position:0|name:0;score:0;position:0|name:0;score:0;position:0|name:0;score:0;position:0|name:0;score:0;position:0|name:0;score:0;position:0|name:0;score:0;position:0|name:0;score:0;position:0";
    [SerializeField] List<LeaderboardPosition> positions = new();
    [SerializeField] Text[] positionSpots;
    [SerializeField] string betweenSpace = "                                            ";
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("leaderboard"))
        {
            PlayerPrefs.SetString("leaderboard", emptyLeaderboard);
        }
        string leaderboard = PlayerPrefs.GetString("leaderboard");
        string[] splitLeaderboard = leaderboard.Split('|');
        foreach (string line in splitLeaderboard)
        {
            string[] stats = line.Split(";");
            stats[0].Remove(0, 5);
            stats[1].Remove(0, 6);
            stats[2].Remove(0, 9);
            positions.Add(new LeaderboardPosition(stats[0], float.Parse(stats[1]), float.Parse(stats[2])));
        }
        foreach (LeaderboardPosition position in positions)
        {
            switch (position.position)
            {
                case 0:
                    break;
                case 1:
                    positionSpots[0].text = position.position + betweenSpace + position.name + betweenSpace + position.score;
                    break;
                case 2:
                    positionSpots[1].text = position.position + betweenSpace + position.name + betweenSpace + position.score;
                    break;
                case 3:
                    positionSpots[2].text = position.position + betweenSpace + position.name + betweenSpace + position.score;
                    break;
                case 4:
                    positionSpots[3].text = position.position + betweenSpace + position.name + betweenSpace + position.score;
                    break;
                case 5:
                    positionSpots[4].text = position.position + betweenSpace + position.name + betweenSpace + position.score;
                    break;
                case 6:
                    positionSpots[5].text = position.position + betweenSpace + position.name + betweenSpace   + position.score;
                    break;
                case 7:
                    positionSpots[6].text = position.position + betweenSpace + position.name + betweenSpace + position.score;
                    break;
                case 8:
                    positionSpots[7].text = position.position + betweenSpace + position.name + betweenSpace + position.score;
                    break;
                case 9:
                    positionSpots[8].text = position.position + betweenSpace + position.name + betweenSpace + position.score;
                    break;
                case 10:
                    positionSpots[9].text = position.position + betweenSpace + position.name + betweenSpace + position.score;
                    break;
            }
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
