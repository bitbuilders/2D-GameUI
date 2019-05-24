using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameImage : GameElement
{
    Sprite m_Sprite;

    public override void SetOptions(ToolbarOptions options)
    {
        base.SetOptions(options);
        StartCoroutine(GetTexture(options.Content, new Vector2(options.Width, options.Height)));
    }
    
    IEnumerator GetTexture(string url, Vector2 dims)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture2D tex = ((DownloadHandlerTexture)www.downloadHandler).texture;
            m_Sprite = Sprite.Create(tex, new Rect(Vector2.zero, dims), new Vector2(0.5f, 0.5f), 100.0f);
            m_Image.sprite = m_Sprite;
        }
    }
}
