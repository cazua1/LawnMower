using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player1 : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private ParticleSystem _sparkEffect;
    [SerializeField] private ParticleSystem _smokeEffect;

    public event UnityAction TrapTouched;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Trap>())
        {
            _mover.Stop();
            TrapTouched?.Invoke();
            Instantiate(_sparkEffect, transform.position, transform.rotation);
            _smokeEffect.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponent<Trap>())
        {
            _smokeEffect.gameObject.SetActive(false);
        }
    }
}
