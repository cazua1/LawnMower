using UnityEngine;
using UnityEngine.UI;

public class SwitchSound : MonoBehaviour
{    
    [SerializeField] private Image _soundOn;
    [SerializeField] private Image _soundOff;
    [SerializeField] private Toggle _toggle;    
    
    private Audio _music;

    private const string AudioState = "AudioState";

    private void Awake()
    {
        _music = FindObjectOfType<Audio>();        
    }

    private void Start()
    {        
        if (PlayerPrefs.GetInt(AudioState) == 1)
        {
            _toggle.isOn = true;
        }            
        
        if (PlayerPrefs.GetInt(AudioState) == 0)
        {
            _toggle.isOn = false;
        }          
    }

    public void ChangeState()
    {
        if (_music != null)
        {
            if (_toggle.isOn)
            {
                _soundOn.gameObject.SetActive(true);
                _soundOff.gameObject.SetActive(false);
                _music.PlayMusic();
                PlayerPrefs.SetInt(AudioState, 1);
            }
            else
            {
                _soundOn.gameObject.SetActive(false);
                _soundOff.gameObject.SetActive(true);
                _music.StopMusic();
                PlayerPrefs.SetInt(AudioState, 0);
            }
        }        
    }
}
