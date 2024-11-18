using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour, IValidateText
{
    [SerializeField] private TextMeshProUGUI _text;
    private BarLevel _level;
    private void OnEnable()
    {
        _level.OnLevelChanged += ValidateText;
        ValidateText();
    }
    private void Awake()
    {
        _level = transform.parent.GetComponent<Bar>().Level;
    }
    private void OnDisable()
    {
        _level.OnLevelChanged -= ValidateText;
    }
    public void ValidateText()
    {
        _text.text = _level.Level.ToString();
    }
}
