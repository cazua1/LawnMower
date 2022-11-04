using UnityEngine;
using PathCreation;

public class BeeMover : MonoBehaviour, IMovable
{
    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private float _speed = 5f;

    private float _distanceTravelled;

    private void Start()
    {
        ResetPosition();        
    }    

    private void Update()
    {
        Move();
    }

    public void ResetPosition()
    {
        _distanceTravelled = 0;
    }

    public void Move()
    {
        _distanceTravelled += _speed * Time.deltaTime;
        transform.SetPositionAndRotation(_pathCreator.path.GetPointAtDistance(_distanceTravelled), _pathCreator.path.GetRotationAtDistance(_distanceTravelled));
    }

    public void Stop()
    {
        _speed = 0;
    }
}
