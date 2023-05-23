using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TakeDamage))]
[RequireComponent(typeof(DestroyManager))]
public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void ReduceHealth(int damage)
    {
        currentHealth -= damage;

        if(currentHealth < 0)
        {
            die();
        }
    }

    private void die()
    {
        Destroy(gameObject);
    }
}
