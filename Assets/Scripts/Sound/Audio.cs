using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Audio : MonoBehaviour
{
    public static Audio Instance;

    [SerializeField] private AudioSource _audioSource;
    
    private bool _isPlaying = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (_isPlaying)        
            PlayMusic();        
    }
    
    public void PlayMusic()
    {
        _audioSource.Play();
        _isPlaying = true;
    }

    public void StopMusic()
    {
        _audioSource.Pause();
        _isPlaying = false;
    }   
}
