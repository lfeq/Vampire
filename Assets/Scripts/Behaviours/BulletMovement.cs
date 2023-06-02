using System;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private int damage = 10;

    private Vector2 m_direction;
    private Formulas m_formulas;

    private void Start()
    {
        m_formulas = new Formulas();
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        Vector3 movementVector = new Vector3(m_direction.x, m_direction.y, 0) * (Time.deltaTime * speed);
        transform.position = m_formulas.move(transform.position, movementVector);
    }
    
    private void OnTriggerEnter2D(Collider2D t_collision) {
        if (!t_collision.CompareTag("Enemy")) return;
        t_collision.GetComponent<TakeDamage>()?.takeDamage(damage);
        Destroy(gameObject);
    }

    public void setDirection(PlayerDirection t_direction) {
        switch (t_direction) {
            case PlayerDirection.North:
                m_direction = new Vector2(0, 1);
                break;
            case PlayerDirection.South:
                m_direction = new Vector2(0, -1);
                break;
            case PlayerDirection.East:
                m_direction = new Vector2(1, 0);
                break;
            case PlayerDirection.West:
                m_direction = new Vector2(-1, 0);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void setDamage(int t_damage) {
        damage = t_damage;
    }
}
