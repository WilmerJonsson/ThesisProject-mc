using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody characterRB;
    Vector3 movementInput;
    Vector3 movementVector;
    [SerializeField] float movementSpeed = 200;
    [SerializeField] float movementWalkSpeed = 200;
    [SerializeField] float movementSprintSpeed = 300;
    [SerializeField] float movementCrouchingSpeed = 100;

    [SerializeField] bool isSprinting;
    [SerializeField] bool isCrouching;

    private void Start()
    {
        characterRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ChangeMovementSpeed();

        SetMovementStyle();
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

    void SetMovementStyle()
    {

        if (Keyboard.current.leftShiftKey.isPressed)
        {
            isSprinting = true;
        }
        else if (Keyboard.current.leftCtrlKey.isPressed) 
        {
            isCrouching = true;
        }
        else
        {
            isSprinting = false;
            isCrouching = false;
        }

    }

    void ChangeMovementSpeed()
    {
        if (isSprinting)
        {
            movementSpeed = movementSprintSpeed;
        }
        else if (isCrouching)
        {
            movementSpeed = movementCrouchingSpeed;
        }
        else
        {
            movementSpeed = movementWalkSpeed;
        }
    }
}

