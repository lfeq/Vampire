using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;

    private Formulas formulas;
    public PlayerDirection playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        formulas = new Formulas();
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxisRaw("Horizontal") * Time.deltaTime * movementSpeed;
        float yMovement = Input.GetAxisRaw("Vertical") * Time.deltaTime * movementSpeed;
        Vector3 movementVector = new Vector3(xMovement, yMovement, 0);

        transform.position = formulas.Move(transform.position, movementVector);

        UpdatePlayerDirection(xMovement, yMovement);
    }

    private void UpdatePlayerDirection(float xMovement, float yMovement)
    {
        if(xMovement < 0)
        {
            playerDirection = PlayerDirection.West;
        }

        if(xMovement > 0)
        {
            playerDirection = PlayerDirection.East;
        }

        if(yMovement < 0)
        {
            playerDirection = PlayerDirection.South;
        }

        if(yMovement > 0)
        {
            playerDirection = PlayerDirection.North;
        }
    }
}

public enum PlayerDirection { North, South, East, West}
