using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameButton : GameElement
{
    [SerializeField] Button m_Button = null;

    public override void SetOptions(ToolbarOptions options)
    {
        base.SetOptions(options);
        m_Button.interactable = options.Interactable;
        m_Button.GetComponentInChildren<TextMeshProUGUI>().text = options.Content;
    }
}
