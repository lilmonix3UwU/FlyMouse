using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    // Leaderboard Head-Decryption: Name;Score;Position|
    string emptyLeaderboard = "NUL;300;1|NUL;300;2|NUL;300;3|NUL;300;4|NUL;300;5|NUL;300;6|NUL;300;7|NUL;300;8|NUL;300;9|NUL;300;10";
    [SerializeField] List<LeaderboardPosition> positions = new();
    // Start is called before the first frame update
    void Start()
    {
        // sets the leaderboard if it's empty
        if (!PlayerPrefs.HasKey("leaderboard"))
        {
            PlayerPrefs.SetString("leaderboard", emptyLeaderboard);
        }
        // takes leaderboard from disk
        string leaderboard = PlayerPrefs.GetString("leaderboard");
        // splits the leaderboard into each of the positions
        string[] splitLeaderboard = leaderboard.Split('|');
        // creates a LeaderboardPosition object for each position on the leaderboard
        foreach (string line in splitLeaderboard)
        {
            // removes the empty string in the start
            if (line == string.Empty)
            {
                continue;
            }
            // splits the information into an array
            string[] stats = line.Split(";");
            // makes an object from the information
            positions.Add(new LeaderboardPosition(stats[0], float.Parse(stats[1]), float.Parse(stats[2])));
        }
        // shows the positions correctly on the leaderboard
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
    /// <summary>
    /// sorts the leaderboard positions, so the best score is in 1st rank.
    /// </summary>
    private void Sort()
    {
        List<string> names = new();
        List<LeaderboardPosition> temp = new()
        {
            new("иии", -1, 0)
        };

        for (int u = 0; u < 10; u++)
        {
            LeaderboardPosition t = new("NUL", 10000000000, 0);
            for (int i = 0; i < positions.Count; i++)
            {
                if (positions[i].score < t.score && positions[i].score > temp.Last().score && !names.Contains(positions[i].name))
                {
                    t = positions[i];
                }
            }
            if (temp[0].name == "иии")
            {
                temp.Remove(temp[0]);
            }
            names.Add(t.name);
            t.position = u + 1;
            temp.Add(t);
        }
        positions = temp;
    }
    /// <summary>
    /// checks if the given score would reach top 10, if so it returns true, else it returns false.
    /// </summary>
    /// <param name="score"></param>
    /// <returns></returns>
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
    /// <summary>
    /// creates a new score position on the leaderboard with the given parameters.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="score"></param>
    public bool NewScore(string name, float score)
    {
        Sort();
        int indexToReplace = 9;
        foreach (LeaderboardPosition position in positions)
        {
            if (position.name == name)
            {
                if (position.score > score)
                {
                    indexToReplace = (int)position.position - 1;
                    break;
                }
                else
                {
                    indexToReplace = -1;
                }
            }
        }
        if (indexToReplace == -1)
        {
            // score is not higher than the already listed score under same name.
            return false;
        }
        else
        {
            positions[indexToReplace] = new LeaderboardPosition(name, score, indexToReplace + 1);
            Sort();
            SaveLeaderboard();
            return true;
        }

    }
    /// <summary>
    /// saves the leaderboard to the disk.
    /// </summary>
    public void SaveLeaderboard()
    {
        string save = string.Empty;
        for (int i = 0; i < positions.Count; i++)
        {
            string[] stats = { positions[i].name, positions[i].score.ToString(), positions[i].position.ToString() };
            string pos = string.Join(";", stats);
            string[] a = { save, pos };
            save = string.Join('|', a);
        }
        save.Remove(0, 1);
        PlayerPrefs.SetString("leaderboard", save);
    }
}
