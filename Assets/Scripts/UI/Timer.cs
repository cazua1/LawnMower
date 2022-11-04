using UnityEngine;
using System.Diagnostics;
using TMPro;
using System;

[RequireComponent(typeof(TextMeshProUGUI))]

public class Timer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _recordTimeValue;
    [SerializeField] private PlayerStatistics _statistics;
    [SerializeField] private int _secondsForThreeStars;
    [SerializeField] private int _secondsForTwoStars;
    
    private readonly Stopwatch _stopWatch = new();
    private TextMeshProUGUI _value;
    private TimeSpan _recordTime;
    private string _recordTimeString;
    private TimeSpan _timeForThreeStars;
    private TimeSpan _timeForTwoStars;
        
    private void OnEnable()
    {
        _player.LevelStarted += OnLevelStarted;
        _player.LevelCompleted += OnLevelCompleted;
        _player.TrapTouched += OnTrapTouched;
    }    

    private void OnDisable()
    {
        _player.LevelStarted -= OnLevelStarted;
        _player.LevelCompleted -= OnLevelCompleted;
        _player.TrapTouched -= OnTrapTouched;
    }    

    private void Start()
    {
       // PlayerPrefs.DeleteAll();
        _value = GetComponent<TextMeshProUGUI>();
        _recordTimeString = PlayerPrefs.GetString(_statistics.GetCurrentLevelRecordTime());
        TimeSpan.TryParseExact(_recordTimeString, @"mm\:ss\:ff", System.Globalization.CultureInfo.InvariantCulture, out _recordTime);
        ShowBestTime(_recordTime);
        _timeForThreeStars = TimeSpan.FromSeconds(_secondsForThreeStars);
        _timeForTwoStars = TimeSpan.FromSeconds(_secondsForTwoStars);              
    }

    private void Update()
    {
        ShowStopWatch();                
    }

    private void ShowStopWatch()
    {
        TimeSpan timeSpan = _stopWatch.Elapsed;
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
        _value.text = elapsedTime;
    }

    private void RecordBestResult(TimeSpan currentTime)
    {
        if (_recordTime == TimeSpan.Zero)        
            _recordTime = currentTime;        

        if (_recordTime > currentTime)        
            _recordTime = currentTime;            
               
        PlayerPrefs.SetString(_statistics.GetCurrentLevelRecordTime(), _recordTime.ToString(@"mm\:ss\:ff"));        
    }

    private void ShowBestTime(TimeSpan time)
    {
        _recordTimeValue.text = time.ToString(@"mm\:ss\:ff");        
    }

    private void OnLevelStarted()
    {
        _stopWatch.Reset();
        _stopWatch.Start();
    }

    private void OnLevelCompleted()
    {
        _stopWatch.Stop();
        RecordBestResult(_stopWatch.Elapsed);
        ShowBestTime(_recordTime);
        CalculateReward();        
    }

    private void OnTrapTouched()
    {
        _stopWatch.Stop();        
    }
    
    private void CalculateReward()
    {
        int numberOfstars = 1;

        if (_stopWatch.Elapsed > _recordTime)        
            return;        

        else if (_recordTime <= _timeForThreeStars)        
            numberOfstars = 3;        

        else if (_recordTime <= _timeForTwoStars)        
            numberOfstars = 2;
               
        PlayerPrefs.SetInt(_statistics.GetCurrentLevelReward(), numberOfstars);
    }
}
