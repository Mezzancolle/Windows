using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Camera1;
    public GameObject Camera2;

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            MainCamera.SetActive(true);
            Camera1.SetActive(false);
            Camera2.SetActive(false);
        }

        if (Input.GetKeyDown("2"))
        {
            MainCamera.SetActive(false);
            Camera1.SetActive(true);
            Camera2.SetActive(false);
        }

        if (Input.GetKeyDown("3"))
        {
            MainCamera.SetActive(false);
            Camera1.SetActive(false);
            Camera2.SetActive(true);
        }
    }
}
