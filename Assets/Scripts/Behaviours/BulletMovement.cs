using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private int damage = 10;

    private Vector2 direction;
    private Formulas formulas;

    private void Start()
    {
        formulas = new Formulas();
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        Vector3 movementVector = new Vector3(direction.x, direction.y, 0) * Time.deltaTime * speed;
        transform.position = formulas.Move(transform.position, movementVector);
    }

    public void SetDirection(Vector2 _direction)
    {
        direction = _direction;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<TakeDamage>()?.takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
