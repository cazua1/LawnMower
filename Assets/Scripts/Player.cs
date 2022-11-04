using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

[RequireComponent(typeof(PlayerMover))]

public class Player : MonoBehaviour
{
    [SerializeField] private ParticleSystem _sparkEffect;
    [SerializeField] private ParticleSystem _smokeEffect;    
    [SerializeField] private PlayableDirector _director;
        
    private PlayerMover _mover;

    public event UnityAction TrapTouched;
    public event UnityAction LevelCompleted;
    public event UnityAction LevelStarted;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Trap>())
        {
            _mover.Stop();
            TrapTouched?.Invoke();
            Instantiate(_sparkEffect, transform.position, transform.rotation);          
            _smokeEffect.gameObject.SetActive(true);
        }

        if (collider.GetComponent<StartPosition>())
        {
            _smokeEffect.gameObject.SetActive(false);
        }

        if (collider.GetComponent<FinishPosition>())
        {
            _mover.Stop();
            _director.Play();
            LevelCompleted?.Invoke();           
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponent<StartPosition>())
        {
            LevelStarted?.Invoke();
        }
    }
}
