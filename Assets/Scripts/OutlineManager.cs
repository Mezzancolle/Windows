using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineManager : MonoBehaviour
{
    public MeshRenderer m_Renderer;
    public Material OriginalMaterial;
    public Material MouseOvercolor;

    private void Start()
    {
        m_Renderer.material = OriginalMaterial;
    }

    void OnMouseOver()
    {
        m_Renderer.material = MouseOvercolor;
    }

    void OnMouseExit()
    {
        m_Renderer.material = OriginalMaterial;
    }
}
