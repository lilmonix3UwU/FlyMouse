using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Leaderboard : MonoBehaviour
{
    // Leaderboard Head-Decryption: Name;Score;Position|
    string emptyLeaderboard = "NUL;300;1|NUL;300;2|NUL;300;3|NUL;300;4|NUL;300;5|NUL;300;6|NUL;300;7|NUL;300;8|NUL;300;9|NUL;300;10";
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
            positions.Add(new LeaderboardPosition(stats[0], float.Parse(stats[1]), float.Parse(stats[2])));
        }
        foreach (LeaderboardPosition position in positions)
        {
            switch (position.position)
            {
                case 0:
                    break;
                case 1:
                    transform.GetChild((int)position.position).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = position.position.ToString();
                    transform.GetChild((int)position.position).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = position.name;
                    transform.GetChild((int)position.position).GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = position.score.ToString();
                    break;
                case 2:
                    transform.GetChild((int)position.position).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = position.position.ToString();
                    transform.GetChild((int)position.position).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = position.name;
                    transform.GetChild((int)position.position).GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = position.score.ToString();
                    break;
                case 3:
                    transform.GetChild((int)position.position).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = position.position.ToString();
                    transform.GetChild((int)position.position).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = position.name;
                    transform.GetChild((int)position.position).GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = position.score.ToString();
                    break;
                case 4:
                    transform.GetChild((int)position.position).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = position.position.ToString();
                    transform.GetChild((int)position.position).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = position.name;
                    transform.GetChild((int)position.position).GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = position.score.ToString();
                    break;
                case 5:
                    transform.GetChild((int)position.position).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = position.position.ToString();
                    transform.GetChild((int)position.position).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = position.name;
                    transform.GetChild((int)position.position).GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = position.score.ToString();
                    break;
                case 6:
                    transform.GetChild((int)position.position).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = position.position.ToString();
                    transform.GetChild((int)position.position).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = position.name;
                    transform.GetChild((int)position.position).GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = position.score.ToString();
                    break;
                case 7:
                    transform.GetChild((int)position.position).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = position.position.ToString();
                    transform.GetChild((int)position.position).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = position.name;
                    transform.GetChild((int)position.position).GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = position.score.ToString();
                    break;
                case 8:
                    transform.GetChild((int)position.position).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = position.position.ToString();
                    transform.GetChild((int)position.position).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = position.name;
                    transform.GetChild((int)position.position).GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = position.score.ToString();
                    break;
                case 9:
                    transform.GetChild((int)position.position).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = position.position.ToString();
                    transform.GetChild((int)position.position).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = position.name;
                    transform.GetChild((int)position.position).GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = position.score.ToString();
                    break;
                case 10:
                    transform.GetChild((int)position.position).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = position.position.ToString();
                    transform.GetChild((int)position.position).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = position.name;
                    transform.GetChild((int)position.position).GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = position.score.ToString();
                    break;
            }
        }


    }

    public bool ScoreChecker(float score)
    {
        for (int i = 0; i < positions.Count; i++)
        {
            if (positions[i].score < score)
            {
                return true;
            }
        }
        return false;
    }
    public void Sort()
    {
        List<LeaderboardPosition> temp = new()
        {
            new("иии", -1, 0)
        };
        LeaderboardPosition t = new("NUL", 10000000000, 0);
        for (int u = 0; u < 10; u++)
        {
            for (int i = 0; i < positions.Count; i++)
            {
                if (positions[i].score < t.score && positions[i].score > temp.Last().score)
                {
                    t = positions[i];
                }
            }
            if (temp[0].name == "иии")
            {
                temp.Remove(temp[0]);
            }
            t.position = u + 1;
            temp.Add(t);
        }
        positions = temp;
    }
    public bool CheckIfHighScore(float score)
    {
        if (score < positions[9].score)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void NewScore(string name, float score)
    {
        Sort();
        positions[9] = new LeaderboardPosition(name, score, 10);
        Sort();
        SaveLeaderboard();
    }
    public void SaveLeaderboard()
    {
        string save = string.Empty;
        for (int i = 0; i < positions.Count; i++)
        {
            string[] stats = { positions[i].name, positions[i].score.ToString(), positions[i].position.ToString() };
            string pos = string.Join(";", stats);
            string[] a = { save, pos };
            save = string.Join("|", a);
        }
        save.Trim('|');
        PlayerPrefs.SetString("leaderboard", save);
    }
}
