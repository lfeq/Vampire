using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/ShootBuff")]
public class ShootBuff : PowerUpEffects {
    public float damageMultiplier;
    
    private void OnEnable() {
        currentLevel = 1;
    }
    
    public override void apply(GameObject t_target) {
        PlayerShoot tempPlayerShoot = t_target.GetComponent<PlayerShoot>();
        tempPlayerShoot.currentLevel++;
        tempPlayerShoot.damage *= damageMultiplier;
        currentLevel++;
    }
}
