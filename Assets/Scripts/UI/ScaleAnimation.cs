using UnityEngine;
using DG.Tweening;

public class ScaleAnimation : MonoBehaviour
{
    private void OnEnable()
    {
        gameObject.transform.DOScale(1.2f, 0.6f).OnComplete(() => Scale(1f, 0.3f));
    }

    private void Scale(float targetValue, float duration)
    {
        gameObject.transform.DOScale(targetValue, duration);
    }
}
