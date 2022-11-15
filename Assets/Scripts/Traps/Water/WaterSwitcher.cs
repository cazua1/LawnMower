using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _waterJet;
    [SerializeField] private float _activationDelay;
    [SerializeField] private float _deactivationDelay;

    private readonly bool _isGameRunning = true;
    private Coroutine _coroutine;

    private void Start()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(SwitchState(_activationDelay, _deactivationDelay));
    }

    private IEnumerator SwitchState(float activationDelay, float deactivationDelay)
    {
        var delay1 = new WaitForSeconds(activationDelay);
        var delay2 = new WaitForSeconds(deactivationDelay);

        while (_isGameRunning)
        {
            _waterJet.SetActive(false);
            yield return delay2;
            _waterJet.SetActive(true);
            yield return delay1;
        }
    }
}
