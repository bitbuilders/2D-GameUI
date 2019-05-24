using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Diagnostics;

public class FileCreator
{
    public void CreateFile(string content, string filename, string format)
    {
        string path = Application.dataPath + "/" + filename + "." + format;
        StreamWriter fs = new StreamWriter(path);
        fs.WriteLine(content);
        fs.Close();
        Process.Start("chrome.exe", "\"" + path + "\"");
    }

    public void MoveToJsonFolder(string filename, string format)
    {
        string path = Application.dataPath + "/" + filename + "." + format;
        string dest = Application.dataPath + "/JSONInput/" + filename + "." + format;
        File.Move(@path, @dest);
    }
}
