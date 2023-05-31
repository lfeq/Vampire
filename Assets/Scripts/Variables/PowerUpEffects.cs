using UnityEngine;

public abstract class PowerUpEffects : ScriptableObject {
    public int currentLevel;

    private void OnEnable() {
        currentLevel = 0;
    }

    public abstract void apply(GameObject t_target);
}