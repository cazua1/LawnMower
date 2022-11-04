using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassClipper: MonoBehaviour
{
    [SerializeField] private float _cutGrassHeight = 0.25f;

    private readonly float _defaultGrassHeight = 5f;
    private MaterialPropertyBlock _defaultProperties;
    private MaterialPropertyBlock _changedProperties;
    private readonly List<MeshRenderer> _renderers = new();
    
    private void Awake()
    {
        _changedProperties = new MaterialPropertyBlock();
        _defaultProperties = new MaterialPropertyBlock();
        _changedProperties.SetFloat("_Cut_height", _cutGrassHeight);
        _defaultProperties.SetFloat("_Cut_height", _defaultGrassHeight);        
    }    

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Grass grass))
        {
            _renderers.Add(grass.GetComponent<MeshRenderer>());            

            foreach (var meshRenderer in _renderers)
            {
                meshRenderer.SetPropertyBlock(_changedProperties);
            }            
        }
    }

    public void ReserGrassHeight()
    {     
        foreach (var meshRenderer in _renderers)
        {
            meshRenderer.SetPropertyBlock(_defaultProperties);
        }
        _renderers.Clear();
    }
}
