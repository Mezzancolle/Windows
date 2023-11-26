using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderTextureCamera : MonoBehaviour
{
    [SerializeField] private Transform[] cameras;
    [SerializeField] private int currentCamera;

    private void Start()
    {
        cameras[currentCamera].gameObject.SetActive(true);
        transform.SetParent(cameras[currentCamera]);
        transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
    }

    public void SwitchCamera(int switchOffset)
    {
        SetCamera(currentCamera + switchOffset);
    }

    void SetCamera(int index)
    {
        if (index > cameras.Length-1) index = 0;
        else if (index < 0) index = cameras.Length-1;

        cameras[currentCamera].gameObject.SetActive(false);
        cameras[index].gameObject.SetActive(true);

        currentCamera = index;

        transform.SetParent(cameras[index]);
        transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
    }
}
