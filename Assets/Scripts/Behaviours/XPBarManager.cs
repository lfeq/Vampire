using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBarManager : MonoBehaviour
{
    [SerializeField] private Image xpBar;
    [SerializeField] private FloatReference currentXP;
    [SerializeField] private FloatReference requiredXPForNextLevel;

    public void UpdateXPBar() {
        float fillAmount = currentXP.value / requiredXPForNextLevel.value;
        xpBar.fillAmount = fillAmount;
    }
}
