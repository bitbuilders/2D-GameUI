using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JSONLoader : MonoBehaviour
{
    [SerializeField] RectTransform m_ElementParent = null;
    [SerializeField] GameElementFactory m_Factory = null;
    [SerializeField] UICreator m_UICreator = null;

    public void Load()
    {
        if (m_UICreator.m_OutputLanguage != OutputLanguage.JSON) return;

        string path = Path.Combine(Application.dataPath, "JSONInput");
        string[] files = Directory.GetFiles(path);

        if (files.Length == 0) return;

        StreamReader fs = new StreamReader(files[0]);
        string s = fs.ReadToEnd();
        fs.Close();

        JsonFormat element = JsonUtility.FromJson<JsonFormat>(s);
        foreach (JsonElement je in element.Elements)
        {
            GameElement ge = m_Factory.Create(je.Type.ToString());
            ge.SetOptions(je.Options);

            ge.transform.SetParent(m_ElementParent, true);
            ge.gameObject.transform.position = je.Position;
        }
    }
}
