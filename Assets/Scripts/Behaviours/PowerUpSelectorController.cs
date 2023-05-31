using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class PowerUpSelectorController : MonoBehaviour {
    [SerializeField] private PowerUpData[] availablePowerUps;
    [SerializeField] private PowerUpCardHandler[] cards;

    public void resetCards() {
        List<PowerUpData> tempPowerUps = availablePowerUps.ToList();
        foreach (PowerUpCardHandler card in cards) {
            PowerUpData randomPowerUp = tempPowerUps[Random.Range(0, tempPowerUps.Count)];
            card.fillCardData(randomPowerUp);
            tempPowerUps.Remove(randomPowerUp);
        }
        Time.timeScale = 0;
    }
}