using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InformationDisplay : MonoBehaviour
{
    public static InformationDisplay Singleton;

    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _job;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    public InformationCard Card;

    [SerializeField] private GameObject _currentNPC;

    private void Awake()
    {
        Singleton = this;
        gameObject.SetActive(false);
    }

    public void FireHim()
    {
        Destroy(_currentNPC);
        HideInformationDisplay();
    }

    public void SetCard(InformationCard card, GameObject selectedNPC)
    {
        _nameText.text = card.name;
        _job.text = card.Job;
        _descriptionText.text = card.Description;
        _currentNPC = selectedNPC;
    }

    public void HideInformationDisplay()
    {
        NPCAudioSource.Singleton.PlayClick();
        gameObject.SetActive(false);
    }

}
