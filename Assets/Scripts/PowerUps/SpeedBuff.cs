using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/SpeedBuff")]
public class SpeedBuff : PowerUpEffects
{
    [Range(0.1f, 100f)]
    public float percent;

    public override void apply(GameObject t_target) {
        PlayerController playerController = t_target.GetComponent<PlayerController>();
        float playerSpeed = playerController.movementSpeed;
        float addSpeed = playerSpeed * (percent / 100);
        playerController.movementSpeed += addSpeed;
        currentLevel++;
    }
}
