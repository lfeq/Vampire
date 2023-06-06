using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookBehaviour : MonoBehaviour
{
    private int damage;
    private PlayerBookDefense bookDefense;

    private void OnTriggerEnter2D(Collider2D t_collision)
    {
        if (!t_collision.CompareTag("Enemy")) return;
        t_collision.GetComponent<TakeDamage>()?.takeDamage(damage);
        bookDefense.removeBook(transform);
        Destroy(gameObject);
    }

    public void setDamage(int t_damage)
    {
        damage = t_damage;
    }

    public void setBookDefemse(PlayerBookDefense t_bookDefense)
    {
        bookDefense = t_bookDefense;
    }
}
