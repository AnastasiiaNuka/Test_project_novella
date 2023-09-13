using DIALOGUE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.VersionControl;
using UnityEngine;

public class FileManager //класс отвечает за считывание текста из файла
{
    public static List<string> ReadTextAsset(TextAsset textAsset, bool includeBlankLines = true)
    {
        List<string> lines = new List<string>();

        string text = textAsset.text;
        string[] textLines = text.Split('\n');

        foreach (string line in textLines)
        {
            if (includeBlankLines || !string.IsNullOrWhiteSpace(line))
                lines.Add(line);
        }

        return lines;
    }
}
