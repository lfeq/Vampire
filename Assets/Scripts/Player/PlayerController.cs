using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Formulas formulas;
    [SerializeField] private float movementSpeed = 5f;

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
    }
}
