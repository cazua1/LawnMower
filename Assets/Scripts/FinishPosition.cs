using UnityEngine;

public class FinishPosition : MonoBehaviour
{
    [SerializeField] private ParticleSystem _confettiEffect;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.LevelCompleted += OnLevelCompleted;
    }    

    private void OnDisable()
    {
        _player.LevelCompleted -= OnLevelCompleted;
    }

    private void OnLevelCompleted()
    {
        _confettiEffect.Play();
    }
}
