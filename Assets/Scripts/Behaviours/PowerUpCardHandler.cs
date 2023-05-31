using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpCardHandler : MonoBehaviour {
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private Image icon;

    private PowerUpData m_powerUpData;

    public void fillCardData(PowerUpData t_powerUpData) {
        m_powerUpData = t_powerUpData;
        nameText.text = t_powerUpData.powerUpName;
        descriptionText.text = t_powerUpData.powerUpDescription;
        levelText.text = "Level: " + t_powerUpData.powerUpEffect.currentLevel.ToString();
        icon.sprite = t_powerUpData.icon;
    }

    public void applyEffect() {
        GameObject player = GameObject.Find("Player");
        m_powerUpData.powerUpEffect.apply(player);
        Time.timeScale = 1f;
    }
}