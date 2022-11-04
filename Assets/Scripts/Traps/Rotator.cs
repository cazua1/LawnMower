using UnityEngine;
using DG.Tweening;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _duration = 5f;
    [SerializeField] private Vector3 _directionOfRotation = new Vector3(0, 360, 0);

    private Tween _tween;

    private void Start()
    {
        Rotate();
    }

    private void OnDestroy()
    {
        _tween.Kill();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Player>())
        {
            _tween.Kill();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponent<Player>())
        {
            transform.rotation = Quaternion.identity;
            Rotate();
        }
    }

    private void Rotate()
    {
        _tween = transform.DOLocalRotate(_directionOfRotation, _duration, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1);
    }
}
