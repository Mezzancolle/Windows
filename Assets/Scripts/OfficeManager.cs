using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeManager : MonoBehaviour
{
    [SerializeField] private Transform[] disableOnStartObjs;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        for (int i = 0; i < disableOnStartObjs.Length; i++)
        {
            disableOnStartObjs[i].gameObject.SetActive(false);
        }
    }

}
