using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineManager : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer m_Renderer;
    [SerializeField]
    private Material _originalMaterial, _outlineColor;
    [SerializeField]
    private GameObject _popupMessage;
    [SerializeField]
    private bool Enemy;

    private NPCManager NPCManager;

    private void Start()
    {
        m_Renderer.material = _originalMaterial;
        NPCManager = FindObjectOfType<NPCManager>();
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
        _popupMessage.SetActive(true);
    }

    private void OnDestroy()
    {
        if (Enemy)
        {
            NPCManager.IncrementKilledEnemies();
        }
        else
        {
            NPCManager.IncrementKilledCivilians();
        }
    }
}
