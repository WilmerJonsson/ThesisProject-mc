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
            IInteractable interactable = rayHitInfo.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
}
