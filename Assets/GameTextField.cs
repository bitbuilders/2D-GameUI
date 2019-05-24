using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTextField : GameElement
{
    [SerializeField] TMP_InputField m_TextField = null;

    public override void SetOptions(ToolbarOptions options)
    {
        base.SetOptions(options);
        m_TextField.text = options.Content;
        m_TextField.interactable = options.Interactable;
    }
}
