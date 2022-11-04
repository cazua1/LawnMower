using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]

public class PlayerPointsView : MonoBehaviour
{
    [SerializeField] private PlayerStatistics _statistics;

    private TextMeshProUGUI _value;

    private void Start()
    {
        _value = GetComponent<TextMeshProUGUI>();
        _value.text = _statistics.CalculatePlayerPoints().ToString();
    }    
}
