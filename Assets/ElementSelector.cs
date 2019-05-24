using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSelector : MonoBehaviour
{
    ElementType m_Selected;

    private void Awake()
    {
        m_Selected = 0;
    }

    public ElementType GetSelectedElement()
    {
        return m_Selected;
    }

    public void Select(Element e)
    {
        m_Selected = e.Type;
    }
}
