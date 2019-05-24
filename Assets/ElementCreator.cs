using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ElementCreator : GameElementFactory
{
    [SerializeField] GameObject m_ButtonTemplate = null;
    [SerializeField] GameObject m_FieldTemplate = null;
    [SerializeField] GameObject m_ImageTemplate = null;

    public override GameElement Create(string element)
    {
        ElementType type;
        if (!Enum.TryParse(element.ToUpper().Replace(' ', '_'), out type)) return null;

        GameElement gameElement = null;
        switch (type)
        {
            case ElementType.BUTTON:
                gameElement = Instantiate(m_ButtonTemplate).GetComponent<GameButton>();
                break;
            case ElementType.TEXT_FIELD:
                gameElement = Instantiate(m_FieldTemplate).GetComponent<GameTextField>();
                break;
            case ElementType.IMAGE:
                gameElement = Instantiate(m_ImageTemplate).GetComponent<GameImage>();
                break;
        }

        gameElement.Type = type;
        GameElements.Add(gameElement);
        return gameElement;
    }
}
