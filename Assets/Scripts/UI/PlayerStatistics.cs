using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatistics : MonoBehaviour
{
    private readonly List<string> _recordTimes = new()
    {
        "time1", 
        "time2", 
        "time3", 
        "time4", 
        "time5", 
        "time6", 
        "time7", 
        "time8", 
        "time9", 
        "time10",
        "time11",
        "time12",
        "time13",
        "time14",
        "time15",
        "time16",
        "time17",
        "time18",
        "time19",
        "time20",      
    };

    private readonly List<string> _levelRewards = new()
    {
        "reward1",
        "reward2",
        "reward3",
        "reward4",
        "reward5",
        "reward6",
        "reward7",
        "reward8",
        "reward9",
        "reward10",
        "reward11",
        "reward12",
        "reward13",
        "reward14",
        "reward15",
        "reward16",
        "reward17",
        "reward18",
        "reward19",
        "reward20",
    };
        
    public string GetCurrentLevelRecordTime()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        return _recordTimes[index - 1];
    }

    public string GetLevelRecordTime(int levelNumber)
    {
        return _recordTimes[levelNumber];
    }

    public string GetCurrentLevelReward()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        return _levelRewards[index - 1];
    }

    public string GetLevelReward(int levelNumber)
    {
        return _levelRewards[levelNumber - 1];
    }

    public int CalculatePlayerPoints()
    {
        int sum = 0;

        for (int i = 1; i < _levelRewards.Count; i++)
        {
            sum += PlayerPrefs.GetInt(GetLevelReward(i));
        }
        
        return sum;
    }
}