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

    private void Start()
    {
        m_Renderer.material = _originalMaterial;
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
}
