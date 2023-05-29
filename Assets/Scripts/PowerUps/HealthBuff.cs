using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PowerUp/HealthBuff")]
public class HealthBuff : PowerUpEffects
{
    [Range(0.1f, 100f)]
    public float percent;

    public override void Apply(GameObject target) {
        Health playerHealth = target.GetComponent<Health>();
        FloatReference playerMaxHealth = playerHealth.GetMaxHealth();
        float maxHealth = playerMaxHealth.value;
        float maxHealthPercent = maxHealth * percent;
        maxHealth += maxHealthPercent;
        playerHealth.SetMaxHealth(maxHealth);
    }
}
