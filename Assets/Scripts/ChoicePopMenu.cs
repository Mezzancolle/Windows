using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChoicePopMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _popupMessage;
    public GameObject NPC;


    public void LeftButtonPressed()
    {
        _popupMessage.SetActive(false);
    }

    public void RightButtonPressed()
    {
        _popupMessage.SetActive(false);
        Destroy(NPC);

    }

    

}
