using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject leaderboardMemberPrefab;
    
    void Awake()
    {
        scoreText.text = "Your score: \n" + GameData.points.ToString();

        string playerID = PlayerPrefs.GetString("PlayerID");

        LootLockerSDKManager.SubmitScore(playerID, GameData.points, "main_leaderboard", (response) =>
        {
            if (response.statusCode == 200)
            {
                Debug.Log("LeaderboardSubmit: success");
            }
            else
            {
                Debug.Log("LeaderboardSubmit: failure");
            }
        });

        GameData.ResetData();

        FetchLeaderboard();
    }

    void FetchLeaderboard()
    {
        LootLockerSDKManager.GetScoreList("main_leaderboard", 10, 0, (response) =>
        {
            if (response.success)
            {


                LootLockerLeaderboardMember[] members = response.items;
                int offset = 0;

                foreach(var member in members)
                {
                    string leaderboardPlayerName = "";
                    string leaderboardPlayerScore = "";

                    leaderboardPlayerName += member.rank + ". ";

                    if(member.player.name != "")
                    {
                        leaderboardPlayerName += member.player.name;
                    }
                    else
                    {
                        leaderboardPlayerName += member.player.id;
                    }

                    leaderboardPlayerName += "\n";
                    leaderboardPlayerScore = member.score.ToString();

                    GameObject leaderboardMember = Instantiate(leaderboardMemberPrefab, GameObject.Find("Canvas/Leaderboard/Viewport/Content").transform);
                    RectTransform rect = leaderboardMember.GetComponent<RectTransform>();
                    rect.localPosition = new Vector3(930, -89 - offset);
                    offset += 62;

                    leaderboardMember.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = leaderboardPlayerName;
                    leaderboardMember.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = leaderboardPlayerScore;
                }
            }
            else
            {
                Debug.Log("Fetching leaderboard: failure");
            }
        });
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}