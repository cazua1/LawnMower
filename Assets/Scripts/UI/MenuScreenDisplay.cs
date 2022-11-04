using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScreenDisplay : MonoBehaviour
{
    [SerializeField] private PlayerStatistics _statistics;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private GrassClipper _grassClipper;
    [SerializeField] private GameObject _startGameScreen;
    [SerializeField] private GameObject _restartScreen;
    [SerializeField] private GameObject _levelComplitedScreen;    
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _reloadButton;
    [SerializeField] private Button[] _mainMenuButtons;
    [SerializeField] private Image _secondStar;
    [SerializeField] private Image _thirdStar;

    private readonly float _delay = 2f;
    private readonly int _menuSceneIndex = 0;

    private void OnEnable()
    {
        _mover.MovingStarted += OnMovingStarted;
        _player.TrapTouched += OnTrapTouched;
        _player.LevelCompleted += OnLevelCompleted;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _reloadButton.onClick.AddListener(OnReloadButtonClick);

        foreach (var button in _mainMenuButtons)
        {
            button.onClick.AddListener(OnMainMenuButtonsClick);
        }
    }

    private void OnDisable()
    {
        _mover.MovingStarted -= OnMovingStarted;
        _player.TrapTouched -= OnTrapTouched;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _reloadButton.onClick.RemoveListener(OnReloadButtonClick);

        foreach (var button in _mainMenuButtons)
        {
            button.onClick.RemoveListener(OnMainMenuButtonsClick);
        }
    }

    private void OnMovingStarted()
    {
        DisableScreen(_startGameScreen);
    }

    private void OnTrapTouched()
    {
        EnableScreen(_restartScreen);
    }

    private void OnLevelCompleted()
    {
        StartCoroutine(EnableWithDelay(_delay));
        ShowReward();
    }

    private void OnReloadButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnRestartButtonClick()
    {
        DisableScreen(_restartScreen);
        EnableScreen(_startGameScreen);
        _mover.ResetPosition();
        _grassClipper.ReserGrassHeight();
    }

    private void OnMainMenuButtonsClick()
    {
        SceneManager.LoadScene(_menuSceneIndex);
    }

    private void EnableScreen(GameObject screen)
    {
        screen.SetActive(true);
    }

    private void DisableScreen(GameObject screen)
    {
        screen.SetActive(false);
    }

    private IEnumerator EnableWithDelay(float activationDelay)
    {
        var delay = new WaitForSeconds(activationDelay);

        yield return delay;
        EnableScreen(_levelComplitedScreen);        
    }

    private void ShowReward()
    {
        int numberOfStars = PlayerPrefs.GetInt(_statistics.GetCurrentLevelReward());

        if (numberOfStars == 1)        
            _secondStar.enabled = false;
        
        if (numberOfStars <= 2)        
            _thirdStar.enabled = false;        
    }
}
