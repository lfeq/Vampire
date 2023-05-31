using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/Data")]
public class PowerUpData : ScriptableObject {
    public string powerUpName;
    public string powerUpDescription;
    public PowerUpEffects powerUpEffect;
    public Sprite icon;
}