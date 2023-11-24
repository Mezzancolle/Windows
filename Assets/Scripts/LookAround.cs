using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LookAround : MonoBehaviour
{
    [SerializeField] private float _rotationX = 0f;
    [SerializeField] private float _rotationY = 0f;

    [SerializeField] private float _sensitivity = 400f;

    [SerializeField] private float _minClampX;
    [SerializeField] private float _maxClampX;
    [SerializeField] private float _minClampY;
    [SerializeField] private float _maxClampY;

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * _sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * _sensitivity * Time.deltaTime;

        _rotationY += mouseX;
        _rotationX -= mouseY;

        _rotationX = Mathf.Clamp(_rotationX, _minClampX, _maxClampX);
        _rotationY = Mathf.Clamp(_rotationY, _minClampY, _maxClampY);

        transform.rotation = Quaternion.Euler(_rotationX, _rotationY, 0);

    }
}
