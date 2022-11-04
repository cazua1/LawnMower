using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoaderView : MonoBehaviour
{
    [SerializeField] private PlayerStatistics _statistics;
    [SerializeField] private Button _button;
    [SerializeField] private int _pointsToUnlock;
    [SerializeField] private int _levelNumberToLoad;
    [SerializeField] private GameObject _firstStar;
    [SerializeField] private GameObject _secondStar;
    [SerializeField] private GameObject _thirdStar;
    
    private void OnEnable()
    {        
        _button.onClick.AddListener(OnNextButtonClick);        
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnNextButtonClick);
    }

    private void Start()
    {
        if (_pointsToUnlock <= _statistics.CalculatePlayerPoints())        
            _button.interactable = true;
        else
            _button.interactable = false;

        RenderStars();        
    }

    private void OnNextButtonClick()
    {
        SceneManager.LoadScene(_levelNumberToLoad);
    }

    private void RenderStars()
    {
        int numberOfStars = PlayerPrefs.GetInt(_statistics.GetLevelReward(_levelNumberToLoad));
                
        if (numberOfStars >= 1)
        {
            _firstStar.SetActive(true);           

            if (numberOfStars >= 2)
            {
                _secondStar.SetActive(true);

                if (numberOfStars == 3)
                {
                    _thirdStar.SetActive(true);
                }
            }
        }        
    }    
}
