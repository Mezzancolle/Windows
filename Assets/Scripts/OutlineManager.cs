using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineManager : MonoBehaviour
{
    [SerializeField]
    public MeshRenderer m_Renderer;
    [SerializeField]
    public Material _originalMaterial, _outlineColor;

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
}
