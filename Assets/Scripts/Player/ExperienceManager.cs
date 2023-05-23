using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    [SerializeField] private FloatReference currentLevel;
    [SerializeField] private FloatReference currentXP;
    [SerializeField] private FloatReference requiredXPForNextLevel;
    [SerializeField] private FloatReference requiredXPForNextLevelMultiplyer;
    [SerializeField] private GameEvent onXpPickup;

    private void Start() {
        currentLevel.value = 1;
        currentXP.value = 0;
        requiredXPForNextLevel.value = 10;
    }

    public void AddXP() {
        currentXP.value++;
        if (currentXP.value >= requiredXPForNextLevel.value) {
            LevelUp();
        }
    }

    private void LevelUp() {
        currentLevel.value++;
        currentXP.value = 0;
        requiredXPForNextLevel.value *= requiredXPForNextLevelMultiplyer.value;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("XP")) {
            AddXP();
            onXpPickup.Raise();
            Destroy(collision.gameObject);
        }
    }
}
