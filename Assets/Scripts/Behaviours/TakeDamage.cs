using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TakeDamage : MonoBehaviour
{
    private bool hasHealth;
    private Health health;

    public UnityEvent onTakeDamage;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        hasHealth = health != null;
    }

    
    public void takeDamage(float damage)
    {
        if(hasHealth)
            health.ReduceHealth(damage);
        onTakeDamage.Invoke();
    }
}
