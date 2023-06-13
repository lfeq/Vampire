using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class ParabolaMovement : MonoBehaviour {
    [SerializeField] private float initialVelocity = 10;
    [SerializeField] private float damage = 30;
    [SerializeField] private float angle = 80f;

    private float m_horizontalInitialVelocity;
    private float m_verticalInitialVelocity;
    private float m_timer;
    private Formulas m_formulas;

    private void Start() {
        m_horizontalInitialVelocity = initialVelocity * Mathf.Cos(angle * Mathf.Deg2Rad);
        m_verticalInitialVelocity = initialVelocity * Mathf.Sin(angle * Mathf.Deg2Rad);
        m_timer = 0;
        m_formulas = new Formulas();
        Destroy(gameObject, 5);
    }

    private void Update() {
        m_timer += Time.deltaTime;
        transform.position = m_formulas.parabolicMovement(m_timer, m_horizontalInitialVelocity,
            m_verticalInitialVelocity, transform.position);
    }

    private void OnTriggerEnter2D(Collider2D t_collision) {
        if (!t_collision.CompareTag("Enemy")) return;
        t_collision.GetComponent<TakeDamage>()?.takeDamage(damage);
    }
}