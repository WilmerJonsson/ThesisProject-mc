using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public interface IInteractable
{
    void Interact();
}

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] float interactRange;

    private void Start()
    {
        playerCamera = Camera.main;
    }

    private void OnInteract(InputValue value)
    {
        Ray ray = new Ray
        {
            origin = playerCamera.transform.position,
            direction = playerCamera.transform.forward
        };
        
        Debug.DrawRay(ray.origin, ray.direction* interactRange);

        RaycastHit rayHitInfo;

        if (Physics.Raycast(ray, out rayHitInfo, interactRange))
        {
            F_IInteractable interactable = rayHitInfo.collider.GetComponent<F_IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
        

    }
}
