using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/AxeBuff")]
public class AxeBuff : PowerUpEffects {
    public GameObject axe;
    
    public override void apply(GameObject t_target) {
        PlayerAxeAttack playerAxeAttack = t_target.GetComponent<PlayerAxeAttack>();
        if (playerAxeAttack == null) {
            playerAxeAttack = t_target.AddComponent<PlayerAxeAttack>();
            playerAxeAttack.setAxePrefab(axe);
        }
        currentLevel++;
    }
}