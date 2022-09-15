using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Mover _mover;

    public event UnityAction TrapTouched;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Trap>())
        {
            _mover.Stop();
            TrapTouched?.Invoke();
        }
    }
}
