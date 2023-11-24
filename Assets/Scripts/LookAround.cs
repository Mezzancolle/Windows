using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LookAround : MonoBehaviour
{
    private float _rotationX = 0f;
    private float _rotationY = 0f;
    public float Sensitivity = 0f;

    [SerializeField]
    private float _minClampX, _maxClampX, _minClampY, _maxClampY;

    void Update()
    {
        float X = Input.GetAxis("Horizontal") * Sensitivity * Time.deltaTime;
        float Y = Input.GetAxis("Vertical") * Sensitivity * Time.deltaTime;

        _rotationY += X;
        _rotationX -= Y;

        _rotationX = Mathf.Clamp(_rotationX, _minClampX, _maxClampX);
        _rotationY = Mathf.Clamp(_rotationY, _minClampY, _maxClampY);

        transform.rotation = Quaternion.Euler(_rotationX, _rotationY, 0);

    }
}
