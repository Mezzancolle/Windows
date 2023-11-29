using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BetterInformationDisplay : MonoBehaviour
{
    public InformationCard Card;

    public TextMeshProUGUI NameText;
    public TextMeshProUGUI Job;
    public TextMeshProUGUI DescriptionText;

    void Start()
    {
        NameText.text = Card.name;
        Job.text = Card.Job;
        DescriptionText.text = Card.Description;
    }

}
