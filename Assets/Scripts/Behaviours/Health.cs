using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TakeDamage))]
[RequireComponent(typeof(DestroyManager))]
public class Health : MonoBehaviour
{
    [SerializeField] private bool createHealth = false;
    [SerializeField] private FloatVariable health;
    [SerializeField] private bool resetHealth;
    [SerializeField] private FloatReference startingHealth;

    // Start is called before the first frame update
    void Awake()
    {
        if (createHealth) {
            health = ScriptableObject.CreateInstance<FloatVariable>();
        }
        if (resetHealth) {
            health.value = startingHealth.value;
        }
        print(health.value);
    }

    public void ReduceHealth(float damage)
    {
        health.value -= damage;
        print(health.value);
        if(health.value < 0)
        {
            die();
        }
    }

    private void die()
    {
        Destroy(gameObject);
    }
}
