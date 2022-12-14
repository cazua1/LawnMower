using System.Collections;
using UnityEngine;
using PathCreation;
using UnityEngine.Events;

public class PlayerMover : MonoBehaviour, IMovable
{
    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private float _maxSpeed = 5f;
    [SerializeField] private ParticleSystem _piecesOfGrassParticle;    

    private readonly float _minSpeed = 0f;    
    private bool _canMove;
    private float _currentSpeed;
    private float _distanceTravelled;
    private Coroutine _changeSpeedCoroutine;

    public event UnityAction MovingStarted;
       
    private void Start()
    {
        ResetPosition();
        _canMove = true;
    }

    private void Update()
    {
        Move();               
    }    

    private void FixedUpdate()
    {
        if (_currentSpeed > 0)        
            _piecesOfGrassParticle.Play();        
    }

    public void Move()
    {
        if ((Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)) && _canMove == true)
        {
            MovingStarted?.Invoke();
            ChangeSpeedValue(_maxSpeed);
        }            
        else
        {
            ChangeSpeedValue(_minSpeed);
        }            
    }

    public void Stop()
    {        
        _canMove = false;
        _currentSpeed = 0;
    }

    public void ResetPosition()
    {
        _distanceTravelled = 0;
        _canMove = true;        
    }

    private void ChangeSpeedValue(float speed)
    {
        if (_changeSpeedCoroutine != null)
            StopCoroutine(_changeSpeedCoroutine);

        _changeSpeedCoroutine = StartCoroutine(ChangeSpeed(speed));
        _distanceTravelled += _currentSpeed * Time.deltaTime;
        transform.SetPositionAndRotation(_pathCreator.path.GetPointAtDistance(_distanceTravelled), _pathCreator.path.GetRotationAtDistance(_distanceTravelled));
    }    

    private IEnumerator ChangeSpeed(float targetSpeed)
    {
        float changeStep = 10f;

        while(_currentSpeed != targetSpeed)
        {
            _currentSpeed = Mathf.MoveTowards(_currentSpeed, targetSpeed, changeStep * Time.deltaTime);
            yield return null;
        }
    }    
}
