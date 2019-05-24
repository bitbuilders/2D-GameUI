using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public struct ToolbarOptions
{
    public bool Interactable;
    public int Width;
    public int Height;
    public string Content;
    public float R;
    public float G;
    public float B;
}

[System.Serializable]
public enum OutputLanguage
{
    HTML,
    JSON
}

public class UICreator : MonoBehaviour
{
    [SerializeField] Toolbar m_Toolbar = null;
    [SerializeField] ElementSelector m_ElementSelector = null;
    [SerializeField] GameElementFactory m_Factory = null;
    [SerializeField] RectTransform m_ElementParent = null;
    [SerializeField] JSONLoader m_JSONLoader = null;
    [SerializeField] TMP_Dropdown m_Dropdown = null;

    public OutputLanguage m_OutputLanguage;
    FileCreator m_FileCreator = new FileCreator();

    private void Start()
    {
        m_Dropdown.captionText.text = m_OutputLanguage.ToString();
        m_Dropdown.SetValueWithoutNotify((int)m_OutputLanguage);
        m_JSONLoader.Load();
    }

    public void PlaceElement(Vector2 pos)
    {
        GameElement ge = m_Factory.Create(m_ElementSelector.GetSelectedElement().ToString());
        ge.SetOptions(m_Toolbar.GetOptions());

        ge.transform.SetParent(m_ElementParent, true);
        ge.gameObject.transform.position = pos;
    }

    public void Undo()
    {
        m_Factory.Undo();
    }

    public void SetTargetOutput(TMP_Dropdown dropdown)
    {
        Enum.TryParse(dropdown.captionText.text.ToUpper(), out m_OutputLanguage);
    }

    public void Generate()
    {
        LanguageFactory lFactory = null;

        switch (m_OutputLanguage)
        {
            case OutputLanguage.HTML:
                lFactory = new HTMLFactory("html");
                break;
            case OutputLanguage.JSON:
                lFactory = new JSONFactory("json");
                break;
        }

        foreach (GameElement ge in m_Factory.GameElements)
        {
            lFactory.AddContentFromElement(ge);
        }

        string content = lFactory.GetText();
        m_FileCreator.CreateFile(content, "test", lFactory.Format);

        if (m_OutputLanguage == OutputLanguage.JSON)
        {
            m_Factory.Clear();
            StartCoroutine(DelayedJSONLoad("test", lFactory.Format));
        }
    }

    IEnumerator DelayedJSONLoad(string filename, string format)
    {
        yield return new WaitForSeconds(0.2f);
        m_FileCreator.MoveToJsonFolder(filename, format);
        m_JSONLoader.Load();
    }
}
