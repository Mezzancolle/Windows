using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    [SerializeField] private LayerMask obsevableLayerMask;
    [SerializeField] private float maxDistance;
    //private RaycastHit hit;
    [SerializeField] private Image observableImage;
    [SerializeField] private Sprite defaultIcon;
    [SerializeField] private Sprite interactIcon;

    //void FixedUpdate()
    //{
    //    //Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * maxDistance, Color.red);

    //    //if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance, obsevableLayerMask))
    //    //{
    //    //    RaycastController(hit);
    //    //    Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * maxDistance, Color.green);
    //    //}

    //    hits = Physics.RaycastAll(Camera.main.transform.position, Camera.main.transform.forward, maxDistance, obsevableLayerMask, QueryTriggerInteraction.UseGlobal);
    //}

    //private void Update()
    //{
    //    if (hits.Length > 0)
    //    {
    //        observableImage.sprite = interactIcon;

    //        foreach (RaycastHit hit in hits)
    //        {
    //            ObservableCheck(hit);
    //            InteractableCheck(hit);
    //        }
    //    }
    //    else if (observableImage.sprite != defaultIcon)
    //    {
    //        observableImage.sprite = defaultIcon;
    //    }
    //}

    void ObservableCheck(RaycastHit hit)
    {
        Interactable observable = hit.collider.GetComponent<Interactable>();

        if (observable != null)
        {
            observable.onInteract.Invoke();
        }
    }

    void InteractableCheck(RaycastHit hit)
    {
        if (hit.collider.CompareTag("ConstantInteract"))
        {
            if (Input.GetButton("Interact"))
            {
                Interactable interactableScript = hit.collider.GetComponent<Interactable>();

                if (interactableScript != null)
                {
                    interactableScript.onInteract.Invoke();
                }
            }
        }
        else if (Input.GetButtonDown("Interact"))
        {
            Interactable interactableScript = hit.collider.GetComponent<Interactable>();

            if (interactableScript != null)
            {
                interactableScript.onInteract.Invoke();
            }
        }


    }
}