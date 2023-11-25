using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Information Card")]
public class InformationCard : ScriptableObject
{
    public string Name;
    public string Job;
    [TextArea]
    public string Description;
}
