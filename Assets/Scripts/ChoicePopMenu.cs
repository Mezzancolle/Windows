using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChoicePopMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _popupMessage;

    private GameObject _npc;
    private GameObject _lastNpcCalled;

    private void Start()
    {

        GameObject _lastNpcCalled = _npc.GetComponent<GameObject>();
    }

    public void LeftButtonPressed()
    {
        _popupMessage.SetActive(false);
    }

    public void RightButtonPressed()
    {
        _popupMessage.SetActive(false);
        Destroy(_lastNpcCalled);

    }

    

}
