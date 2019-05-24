using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum ElementType
{
    BUTTON,
    TEXT_FIELD,
    IMAGE
}

public abstract class GameElementFactory : MonoBehaviour
{
    public List<GameElement> GameElements = new List<GameElement>();

    abstract public GameElement Create(string element);
    public void Undo()
    {
        if (GameElements.Count == 0) return;

        Destroy(GameElements[GameElements.Count - 1].gameObject);
        GameElements.RemoveAt(GameElements.Count - 1);
    }

    public void Clear()
    {
        foreach (GameElement ge in GameElements)
        {
            Destroy(ge.gameObject);
        }

        GameElements.Clear();
    }
}
