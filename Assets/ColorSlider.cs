using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorSlider : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_ValueText = null;

    public void SetText(float value)
    {
        m_ValueText.text = "[" + (int)(value * 255) + "]";
    }
}
