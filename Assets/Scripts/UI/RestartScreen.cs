using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StixGames.GrassShader;

public class RestartScreen : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Mover _mover;
    [SerializeField] private Image _restartScreen;
    [SerializeField] private Button _restartButton;
    [SerializeField] private InteractionTrailRenderer _renderer;
    
    private void OnEnable()
    {
        _player.TrapTouched += OnTrapTouched;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
    }

    private void OnDisable()
    {
        _player.TrapTouched -= OnTrapTouched;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
    }

    private void OnTrapTouched()
    {
        EnableRestartScreen();
    }

    private void OnRestartButtonClick()
    {
        DisableRestartScreen();
        _mover.ResetPosition();
        _renderer.ClearPath();
    }

    private void EnableRestartScreen()
    {
        _restartScreen.gameObject.SetActive(true);
    }

    private void DisableRestartScreen()
    {
        _restartScreen.gameObject.SetActive(false);
    }
}
