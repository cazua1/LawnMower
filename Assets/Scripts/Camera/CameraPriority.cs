using UnityEngine;
using Cinemachine;

public class CameraPriority : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _vcam1;
    [SerializeField] private CinemachineVirtualCamera _vcam2;
    
    private void OnEnable()
    {
        _vcam1.Priority = 10;
        _vcam2.Priority = 9;
    }    
}
