using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct JsonElement
{
    public ElementType Type;
    public ToolbarOptions Options;
    public Vector2 Position;
}

[System.Serializable]
public struct JsonFormat
{
    public List<JsonElement> Elements;
}

public class JSONFactory : LanguageFactory
{
    List<JsonElement> m_Elements = new List<JsonElement>();

    public JSONFactory(string format)
    {
        Format = format;
        string prefix = "{" +
                            "\"Elements\": [";
        string suffix =         "]" +
                        "}";

        SetStringValues(prefix, suffix);
    }

    public override void AddContentFromElement(GameElement element)
    {
        m_Elements.Add(new JsonElement() { Type = element.Type, Options = element.Options, Position = element.transform.position });
    }

    public override string GetText()
    {
        return JsonUtility.ToJson(new JsonFormat() { Elements = m_Elements });
    }
}
