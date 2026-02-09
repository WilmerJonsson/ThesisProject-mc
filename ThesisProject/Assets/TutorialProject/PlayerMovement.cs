using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody characterRB;
    Vector3 movementInput;
    Vector3 movementVector;
    [SerializeField ]float movementSpeed = 5;

    private void Start()
    {
        characterRB = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        ApplyMovement();
    }

    void OnMovement(InputValue input)
    {
        movementInput = new Vector3(input.Get<Vector2>().x, 0, input.Get<Vector2>().y);
    }

    void OnMovementStop(InputValue input)
    {
        movementVector = Vector3.zero;
    }

    void ApplyMovement()
    {
        if (movementInput != Vector3.zero)
        {
            movementVector = transform.right * movementInput.x + transform.forward * movementInput.z;
            movementVector.y = 0; // Ignore vertical component
        }
        characterRB.velocity = (movementVector * Time.fixedDeltaTime * movementSpeed);
    }
}

