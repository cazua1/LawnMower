using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;    

public class MainMenuLoader : MonoBehaviour
{
    [SerializeField] private Button _nextButton;

    private readonly int _menuSceneIndex = 0;
    
    private void OnEnable()
    {
        _nextButton.onClick.AddListener(OnNextButtonClick);
    }

    private void OnDisable()
    {
        _nextButton.onClick.RemoveListener(OnNextButtonClick);
    }

    private void OnNextButtonClick()
    {
        SceneManager.LoadScene(_menuSceneIndex);
    }    
}
