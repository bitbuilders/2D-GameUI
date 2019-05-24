using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTMLFactory : LanguageFactory
{
    public HTMLFactory(string format)
    {
        Format = format;
        string prefix = "<!DOCTYPE html>" +
                        "<html lang='en'>" +
                        "<head>" +
                        "    <meta charset='UTF-8' >" +
                        "    <meta name='viewport' content ='width =device-width, initial-scale=1.0' > " +
                        "    <meta http-equiv='X-UA-Compatible' content = 'ie=edge'> " +
                        "    <title>Document</title>" +
                        "</head>" +
                        "<body>";

        string suffix = "</body>" +
                        "</ html >";

        SetStringValues(prefix, suffix);
    }

    public override void AddContentFromElement(GameElement element)
    {
        int r = (int)(element.Options.R * 255);
        int g = (int)(element.Options.G * 255);
        int b = (int)(element.Options.B * 255);
        string color = "background-color:rgb(" + r + "," + g + "," + b + ");";
        string positionType = "position: absolute;";
        string position = "left:" + element.transform.position.x + "px;top:" + (Screen.height - element.transform.position.y) + "px;";
        string dims = "width:" + element.Options.Width + "px;height:" + element.Options.Height + "px;";
        string disabled = element.Options.Interactable ? "" : "disabled";
        switch (element.Type)
        {
            case ElementType.BUTTON:
                Content += "<button type='button' style='" + color + positionType + position + dims + "' " + disabled + ">" + element.Options.Content + "</button>";
                break;
            case ElementType.TEXT_FIELD:
                Content += "<form><input type='text' value='" + element.Options.Content + "' style='" + color + positionType + position + dims + "' " + disabled + "></input></form>";
                break;
            case ElementType.IMAGE:
                Content += "<image src='" + element.Options.Content + "' style='" + positionType + position + dims + "'></image>";
                break;
        }
    }
}
