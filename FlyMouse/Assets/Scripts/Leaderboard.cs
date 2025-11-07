using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    // Leaderboard Head-Decryption: Name;Score;Position|
    [SerializeField] string emptyLeaderboard = "NUL;0;1|NUL;0;2|NUL;0;3|NUL;0;4|NUL;0;5|NUL;0;6|NUL;0;7|NUL;0;8|NUL;0;9|NUL;0;10";
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
        List<LeaderboardPosition> temp = new();
        temp.Add(new("иии", -1, 0));
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
            string[] a = {save, pos};
            save = string.Join("|", a);
        }
        save.Trim('|');
        PlayerPrefs.SetString("leaderboard", save);
    }
}
