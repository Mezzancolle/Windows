using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    [SerializeField] private LayerMask interactableLayerMask;
    [SerializeField] private float maxDistance;    
    private RaycastHit hit;
    [SerializeField] private Image interactorImage;
    [SerializeField] private Sprite defaultIcon;
    [SerializeField] private Sprite interactIcon;

    private void Update()
    {
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance, interactableLayerMask);

        if (hit.collider)
        {
            interactorImage.sprite = interactIcon;
        }
        else if (interactorImage.sprite != defaultIcon)
        {
            interactorImage.sprite = defaultIcon;
        }

        if (Input.GetButtonDown("Interact") && hit.collider)
        {
            Interactable interactableScript = hit.collider.GetComponent<Interactable>();

            if (interactableScript != null)
            {
                interactableScript.onInteract.Invoke();
            }
        }
    }
}