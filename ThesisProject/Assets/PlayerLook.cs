using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    public int mouseSensitivity;
    [SerializeField] Transform playerCamera;
    float xRotation;
    float yRotation;
    float mouseX;
    float mouseY;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        mouseX *= Time.deltaTime * mouseSensitivity;
        mouseY *= Time.deltaTime * mouseSensitivity;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -35f, 40f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        playerCamera.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    private void OnLook(InputValue input)
    {
        mouseX = input.Get<Vector2>().x;
        mouseY = input.Get<Vector2>().y;
    }
}
