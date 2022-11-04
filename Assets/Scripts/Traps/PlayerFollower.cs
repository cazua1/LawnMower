using UnityEngine;
using DG.Tweening;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private ParticleSystem _angryEffect;
    [SerializeField] private ParticleSystem _bangEffect;

    private Player _player;
    private Transform _target;
    private Vector3 _targetLastPosition;
    private Tweener _tweener;

    private void OnEnable()
    {
        _player = FindObjectOfType<Player>();
        _target = _player.transform;
        _angryEffect.Play();
        _tweener = transform.DOMove(_target.position, 3f).SetAutoKill(false);
        _player.TrapTouched += OnPlayerTrapTouched;
        _player.LevelCompleted += OnPlayerLevelCompleted;
    }    

    private void OnDestroy()
    {
        _tweener.Kill();
        _player.TrapTouched -= OnPlayerTrapTouched;
        _player.LevelCompleted -= OnPlayerLevelCompleted;
    }

    private void Update()
    {
        if (_targetLastPosition != _target.position)
        {
            _tweener.ChangeEndValue(_target.position, true).Restart();
            _targetLastPosition = _target.position;
            transform.LookAt(_target);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Player>())
        {
            Instantiate(_bangEffect, transform.position, transform.rotation);
            DestroyYorself();
        }
    }
    
    private void DestroyYorself()
    {
        Destroy(gameObject);
    }

    private void OnPlayerLevelCompleted()
    {
        DestroyYorself();
    }

    private void OnPlayerTrapTouched()
    {
        DestroyYorself();
    }
}
