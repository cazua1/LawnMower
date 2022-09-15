using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        Mover mover = collider.GetComponent<Mover>();

        if (collider.GetComponent<Mover>())
        {
            mover.Stop();            
            mover.ResetPosition();
        }
    }
}
