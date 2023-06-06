using UnityEngine;

[RequireComponent(typeof(TakeDamage))]
[RequireComponent(typeof(DestroyManager))]
public class Health : MonoBehaviour {
    [SerializeField] private bool createHealth = false;
    [SerializeField] private FloatVariable health;
    [SerializeField] private bool resetHealth;
    [SerializeField] private FloatReference startingHealth;
    [SerializeField] private FloatReference maxHealth;

    void Awake() {
        if (createHealth) {
            health = ScriptableObject.CreateInstance<FloatVariable>();
        }
        if (resetHealth) {
            health.value = startingHealth.value;
        }
        if(maxHealth != null) {
            maxHealth.value = startingHealth.value;
        }
    }

    public void ReduceHealth(float damage) {
        health.value -= damage;
        if (health.value < 0) {
            die();
        }
    }

    public void AddMaxHealth(float health) {
        maxHealth.value += health;
    }

    public FloatReference GetMaxHealth() {
        return maxHealth;
    }

    public void SetMaxHealth(float newValue) {
        maxHealth.value = newValue;
    }

    private void die() {
        Destroy(gameObject);
    }
}
