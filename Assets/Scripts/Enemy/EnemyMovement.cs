using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    private Transform m_player;
    private Formulas m_formulas;
    private bool m_canDamage;
    private const float DAMAGE_COOLDOWN = 0.5f;
    private float m_timer;

    [SerializeField] private float speed = 1f;
    [SerializeField] private float damage = 1f;

    void Start() {
        m_player = GameObject.FindWithTag("Player").transform;
        m_formulas = new Formulas();
        m_canDamage = true;
    }

    void Update() {
        Vector3 direction = m_formulas.direction(transform.position, m_player.position);
        direction = m_formulas.normalize(direction);
        transform.position += direction * (speed * Time.deltaTime);
        coolDown();
    }

    private void coolDown() {
        m_timer -= Time.deltaTime;
        if (m_timer <= 0) {
            m_canDamage = true;
        }
    }

    private void OnTriggerStay2D(Collider2D t_collision) {
        if (t_collision.CompareTag("Player") && m_canDamage) {
            TakeDamage takeDamage = t_collision.GetComponent<TakeDamage>();
            takeDamage.takeDamage(damage);
            m_canDamage = false;
            m_timer = DAMAGE_COOLDOWN;
        }
    }
}