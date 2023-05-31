using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpCardHandler : MonoBehaviour {
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private Image icon;

    private PowerUpData powerUpData;

    public void FillCardData(PowerUpData _powerUpData) {
        powerUpData = _powerUpData;
        nameText.text = _powerUpData.powerUpName;
        descriptionText.text = _powerUpData.powerUpDescription;
        levelText.text = "Level: " + _powerUpData.powerUpEffect.currentLevel.ToString();
        icon.sprite = _powerUpData.icon;
    }
}