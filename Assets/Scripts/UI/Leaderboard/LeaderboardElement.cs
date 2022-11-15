using TMPro;
using UnityEngine;

public class LeaderboardElement : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerRank;
    [SerializeField] private TMP_Text _playerName;
    [SerializeField] private TMP_Text _playerScore;       

    public void Initialize(int rank, string name, string score)
    {
        _playerRank.text = rank.ToString();
        _playerName.text = name;
        _playerScore.text = score;        
    }

    private string Test(int playerTime)
    {
        //TimeSpan timeSpan = TimeSpan.FromMilliseconds(playerTime);
        //string result = string.Format("{0:00}:{1:00}:{2:00}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);

        string result = playerTime.ToString();

        return result;
    }
}