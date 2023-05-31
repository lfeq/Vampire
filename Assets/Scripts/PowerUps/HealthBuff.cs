using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/HealthBuff")]
public class HealthBuff : PowerUpEffects {

    [Range(0.1f, 100f)]
    public float percent;
    public GameEvent gameEvent;

    public override void apply(GameObject t_target) {
        Health playerHealth = t_target.GetComponent<Health>();
        FloatReference playerMaxHealth = playerHealth.GetMaxHealth();
        float maxHealth = playerMaxHealth.value;
        float maxHealthPercent = maxHealth * (percent / 100);
        maxHealth += maxHealthPercent;
        playerHealth.SetMaxHealth(maxHealth);
        currentLevel++;
        gameEvent.Raise();
    }
}