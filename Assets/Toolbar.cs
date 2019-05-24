using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Toolbar : MonoBehaviour
{
    [SerializeField] Toggle m_Toggle = null;
    [SerializeField] TMP_InputField m_Width = null;
    [SerializeField] TMP_InputField m_Height = null;
    [SerializeField] TMP_InputField m_Content = null;
    [SerializeField] Slider m_R = null;
    [SerializeField] Slider m_G = null;
    [SerializeField] Slider m_B = null;

    public ToolbarOptions GetOptions()
    {
        return new ToolbarOptions()
        {
            Interactable = m_Toggle.isOn,
            Width = int.Parse(m_Width.text),
            Height = int.Parse(m_Height.text),
            Content = m_Content.text.Length == 0 ? "Content" : m_Content.text,
            R = m_R.value,
            G = m_G.value,
            B = m_B.value,
        };
    }
}
