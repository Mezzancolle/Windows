using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    private float _rotationX = 0f;
    private float _rotationY = 0f;
    public float Sensitivity = 400f;

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

        _rotationX = math.clamp(_rotationX, -90f, 90f);
        _rotationY = math.clamp(_rotationY, -90f, 90f);

        transform.rotation = Quaternion.Euler(_rotationX, _rotationY, 0);

    }
}
