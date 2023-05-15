using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private Vector2 direction;
    private Formulas formulas;

    private void Start()
    {
        formulas = new Formulas();
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
}
