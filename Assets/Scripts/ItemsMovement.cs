using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class ItemsMovement : MonoBehaviour
{
    private float interactTimer = 1f, interactCounter = 0f;
    private Vector3 startPos, endPos;

    private float movementSpeed = 2f;
    [SerializeField] private float upOffset = 0.2f;
    private AnimationCurve movementCurve;

    private void Awake()
    {
        movementCurve = new AnimationCurve();

        movementCurve.AddKey(0f, 0f);
        movementCurve.AddKey(0.5f, 1f);
        movementCurve.AddKey(1f, 0f);

        enabled = false;

        GetComponent<Interactable>().onInteract.AddListener(() => enabled = true);
    }

    void OnEnable()
    {
        interactCounter = interactTimer;
        startPos = transform.position;
        endPos = transform.position + Vector3.up * upOffset;

        gameObject.layer = 0;

        movementSpeed = Random.Range(1f, 3f);
    }

    private void Update()
    {
        interactCounter -= Time.deltaTime * movementSpeed;

        transform.position = Vector3.Lerp(startPos, endPos, movementCurve.Evaluate(interactCounter));

        if (interactCounter < 0)
        {
            transform.position = startPos;
            gameObject.layer = 7;
            enabled = false;
        }
    }
}
