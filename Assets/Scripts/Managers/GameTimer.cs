using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour {
    [SerializeField] private FloatReference timer;
    [SerializeField] private TMP_Text timerText;

    private void Update() {
        int minutes = Mathf.FloorToInt(timer.value / 60F);
        int seconds = Mathf.FloorToInt(timer.value - minutes * 60);
        string timerString = $"{minutes:0}:{seconds:00}";
        timerText.text = timerString;
    }
}
