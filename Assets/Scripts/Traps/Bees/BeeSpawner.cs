using UnityEngine;
using DG.Tweening;

public class BeeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _beePrefab;    

    private GameObject _spawnedBee;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Player>())
        {
            float duration = 1.3f;
            float strength = 0.1f;
                        
            transform.DOShakeScale(duration, strength).OnComplete(() => SpawnBee());
        }
    }

    private void SpawnBee()
    {
        if(_spawnedBee == null)
            _spawnedBee = Instantiate(_beePrefab, transform.position, Quaternion.identity);
    }
}
