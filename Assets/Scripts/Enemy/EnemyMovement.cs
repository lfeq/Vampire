using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    private Formulas formulas;
    
    [SerializeField] private float speed = 1f;
    [SerializeField] private float damage = 1f;

    void Start() {
        player = GameObject.FindWithTag("Player").transform;
        formulas = new Formulas();
    }

    void Update() {
        Vector3 direction = formulas.Direction(transform.position, player.position);
        direction = formulas.Normalizar(direction);
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            TakeDamage takeDamage = collision.GetComponent<TakeDamage>();
            takeDamage.takeDamage(damage);
        }
    }
}
