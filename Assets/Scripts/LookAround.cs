using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LookAround : MonoBehaviour
{
    private float _rotationX = 0f;
    private float _rotationY = 0f;
    public float Sensitivity = 400f;

    public float MinClampX;
    public float MaxClampX;
    public float MinClampY;
    public float MaxClampY;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        _rotationY += mouseX;
        _rotationX -= mouseY;

        _rotationX = Mathf.Clamp(_rotationX, MinClampX, MaxClampX);
        _rotationY = Mathf.Clamp(_rotationY, MinClampY, MaxClampY);

        transform.rotation = Quaternion.Euler(_rotationX, _rotationY, 0);

    }
}
