using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerUpSelectorController : MonoBehaviour
{
    [SerializeField] private PowerUpData[] availabePowerUps;
    [SerializeField] private PowerUpCardHandler[] cards;

    public void ResetCards() {
        List<PowerUpData> tempPowerUps = new List<PowerUpData>();
        tempPowerUps = availabePowerUps.ToList();
        foreach(PowerUpCardHandler card in cards) {
            PowerUpData randomPowerUp = tempPowerUps[Random.Range(0, tempPowerUps.Count)];
            card.FillCardData(randomPowerUp);
            tempPowerUps.Remove(randomPowerUp);
        }
    }
}
