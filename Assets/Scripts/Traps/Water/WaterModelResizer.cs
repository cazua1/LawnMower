using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WaterModelResizer : MonoBehaviour
{        
    private readonly float _animationDelay = 0.1f;     
    private readonly float _size = 33;
    private Tween _tween;
    
    private void OnEnable()
    {
        transform.localScale = Vector3.one;
        Resize(_size);
    }

    private void OnDestroy()
    {
        _tween.Kill();
    }

    private void Resize(float size)
    {        
        _tween = transform.DOScaleY(size, _animationDelay);
    }    
}
