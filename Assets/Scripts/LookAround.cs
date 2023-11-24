using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class LookAround : MonoBehaviour
{
    private float _rotationX = 0f;
    private float _rotationY = 0f;
    public float Sensitivity = 400f;

    public float ClampA;
    public float ClampB;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        _rotationY += mouseX;
        _rotationX -= mouseY;

        _rotationX = math.clamp(_rotationX, ClampA, ClampB);
        _rotationY = math.clamp(_rotationY, ClampA, ClampB);

        transform.rotation = Quaternion.Euler(_rotationX, _rotationY, 0);

    }
}
