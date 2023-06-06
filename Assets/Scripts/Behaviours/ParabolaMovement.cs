using System;
using UnityEngine;

public class ParabolaMovement : MonoBehaviour
{
    public float initialVelocity = 10;
    public float damage = 15;

    private const float ANGLE = 80f;
    private float m_horizontalInitialVelocity;
    private float m_verticalInitialVelocity;
    private float m_timer;
    private Formulas m_formulas;

    private void Start()
    {
        m_horizontalInitialVelocity = initialVelocity * Mathf.Cos(ANGLE * Mathf.Deg2Rad);
        m_verticalInitialVelocity = initialVelocity * Mathf.Sin(ANGLE * Mathf.Deg2Rad);
        m_timer = 0;
        m_formulas = new Formulas();
    }

    private void Update() {
        m_timer += Time.deltaTime;
        transform.position = m_formulas.tiroParabolico(m_timer, m_horizontalInitialVelocity, m_verticalInitialVelocity);
    }

    private void OnTriggerEnter2D(Collider2D t_collision)
    {
        if (!t_collision.CompareTag("Enemy")) return;
        t_collision.GetComponent<TakeDamage>()?.takeDamage(damage);
        Destroy(gameObject);
    }
}
