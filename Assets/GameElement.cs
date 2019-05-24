using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class GameElement : MonoBehaviour
{
    [SerializeField] protected RectTransform m_Transform = null;
    [SerializeField] protected Image m_Image = null;

    public ToolbarOptions Options { get; private set; }
    public ElementType Type { get; set; }

    public virtual void SetOptions(ToolbarOptions options)
    {
        Options = options;
        m_Transform.sizeDelta = new Vector2(options.Width, options.Height);
        m_Image.color = new Color(options.R, options.G, options.B, 1.0f);
    }
}
