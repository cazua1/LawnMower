using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _leaderboardScreen;
    [SerializeField] private Timer _timer;    
    [SerializeField] private LeaderboardElement _elementTemplate;
    [SerializeField] private Transform _content;
    [SerializeField] private string _title;
    
    private List<LeaderboardElement> _elements = new();

    private void OnEnable()
    {
        _player.LevelCompleted += SetScore;
    }    

    private void OnDisable()
    {
        _player.LevelCompleted -= SetScore;
    }

    public void EnableScreen()
    {
        Time.timeScale = 0;        
        _leaderboardScreen.SetActive(true);
        LoadData();
    }

    public void DisableScreen()
    {
        Time.timeScale = 1;
        _leaderboardScreen.SetActive(false);
    }    

    private void LoadData()
    {
        if (YandexGamesSdk.IsInitialized == false)
            return;

        ClearLeaderboard();
        Authorize();                

        Agava.YandexGames.Leaderboard.GetEntries(_title, (result) =>
        {
            foreach (var entry in result.entries)
            {
                string name = entry.player.publicName;

                if (string.IsNullOrEmpty(name))
                    name = "Anonymous";

                LeaderboardElement element = Instantiate(_elementTemplate, _content);
                element.Initialize(entry.rank, name, entry.formattedScore);
                _elements.Add(element);
            }
        });
    }

    private void Authorize()
    {
        PlayerAccount.RequestPersonalProfileDataPermission();

        if (PlayerAccount.IsAuthorized == false)
            PlayerAccount.Authorize();
    }    

    private void ClearLeaderboard()
    {
        foreach (var element in _elements)
            Destroy(element.gameObject);

        _elements = new List<LeaderboardElement>();        
    }

    private void SetScore()
    {
        if (PlayerAccount.IsAuthorized == false)
            return;

        Agava.YandexGames.Leaderboard.SetScore(_title, _timer.GetRecordTime());
    }    
}
