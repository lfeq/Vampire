using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBarController : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private FloatReference playerHealth;
    [SerializeField] private FloatReference playerMaxHealth;

    public void UpdateHPBar() {
        float fillAmount = playerHealth.value / playerMaxHealth.value;
        healthBar.fillAmount = fillAmount;
    }
}
