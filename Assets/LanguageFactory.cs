using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LanguageFactory
{
    public string Content { get; set; }
    public string Format { get; set; }

    protected string m_Prefix;
    protected string m_Suffix;

    protected void SetStringValues(string prefix, string suffix)
    {
        m_Prefix = prefix;
        m_Suffix = suffix;
    }

    abstract public void AddContentFromElement(GameElement element);

    virtual public string GetText()
    {
        return m_Prefix + Content + m_Suffix;
    }
}
