using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] string emptyLeaderboard = "name:0;score:0;position:0|name:0;score:0;position:0|name:0;score:0;position:0|name:0;score:0;position:0|name:0;score:0;position:0|name:0;score:0;position:0|name:0;score:0;position:0|name:0;score:0;position:0|name:0;score:0;position:0|name:0;score:0;position:0";
    [SerializeField] List<LeaderboardPosition> positions = new();
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
                    transform.GetChild(1).GetChild(1).gameObject.GetComponent<TextMeshPro>().text = position.name;
                    transform.GetChild(1).GetChild(2).gameObject.GetComponent<TextMeshPro>().text = position.score.ToString();
                    break;
                case 2:
                    transform.GetChild(2).GetChild(1).gameObject.GetComponent<TextMeshPro>().text = position.name;
                    transform.GetChild(2).GetChild(2).gameObject.GetComponent<TextMeshPro>().text = position.score.ToString();
                    break;
                case 3:
                    transform.GetChild(3).GetChild(1).gameObject.GetComponent<TextMeshPro>().text = position.name;
                    transform.GetChild(3).GetChild(2).gameObject.GetComponent<TextMeshPro>().text = position.score.ToString();
                    break;
                case 4:
                    transform.GetChild(4).GetChild(1).gameObject.GetComponent<TextMeshPro>().text = position.name;
                    transform.GetChild(4).GetChild(2).gameObject.GetComponent<TextMeshPro>().text = position.score.ToString();
                    break;
                case 5:
                    transform.GetChild(5).GetChild(1).gameObject.GetComponent<TextMeshPro>().text = position.name;
                    transform.GetChild(5).GetChild(2).gameObject.GetComponent<TextMeshPro>().text = position.score.ToString();
                    break;
                case 6:
                    transform.GetChild(6).GetChild(1).gameObject.GetComponent<TextMeshPro>().text = position.name;
                    transform.GetChild(6).GetChild(2).gameObject.GetComponent<TextMeshPro>().text = position.score.ToString();
                    break;
                case 7:
                    transform.GetChild(7).GetChild(1).gameObject.GetComponent<TextMeshPro>().text = position.name;
                    transform.GetChild(7).GetChild(2).gameObject.GetComponent<TextMeshPro>().text = position.score.ToString();
                    break;
                case 8:
                    transform.GetChild(8).GetChild(1).gameObject.GetComponent<TextMeshPro>().text = position.name;
                    transform.GetChild(8).GetChild(2).gameObject.GetComponent<TextMeshPro>().text = position.score.ToString();
                    break;
                case 9:
                    transform.GetChild(9).GetChild(1).gameObject.GetComponent<TextMeshPro>().text = position.name;
                    transform.GetChild(9).GetChild(2).gameObject.GetComponent<TextMeshPro>().text = position.score.ToString();
                    break;
                case 10:
                    transform.GetChild(10).GetChild(1).gameObject.GetComponent<TextMeshPro>().text = position.name;
                    transform.GetChild(10).GetChild(2).gameObject.GetComponent<TextMeshPro>().text = position.score.ToString();
                    break;
            }
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
