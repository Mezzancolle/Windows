using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineManager : MonoBehaviour
{
    [SerializeField]
    private SkinnedMeshRenderer m_Renderer;
    [SerializeField]
    private Material _originalMaterial, _outlineColor;
    [SerializeField]
    private bool _isEnemy;
    [SerializeField]
    private InformationCard _myCard;

    private void Start()
    {
        _originalMaterial = m_Renderer.material;
    }

    void OnMouseOver()
    {
        m_Renderer.material = _outlineColor;
    }

    void OnMouseExit()
    {
        m_Renderer.material = _originalMaterial;
    }

    private void OnMouseDown()
    {
        NPCAudioSource.Singleton.PlayClickNPC();
        InformationDisplay.Singleton.gameObject.SetActive(true);
        InformationDisplay.Singleton.SetCard(_myCard, this.gameObject);
    }

    private void OnDestroy()
    {
        if (_isEnemy)
        {
            NPCManager.Singleton.IncrementKilledEnemies();
        }
        else
        {
            NPCManager.Singleton.IncrementKilledCivilians();
        }
    }
}
