using DIALOGUE;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFiles : MonoBehaviour //Final. Класс отвечает за разделение текста на сегменты 
{
    [SerializeField] private TextAsset fileName;

    void Start()
    {
        Run();
    }

    void Run()
    {
        List<string> lines = FileManager.ReadTextAsset(fileName, false);

        foreach (string line in lines)
        {
            if (line == string.Empty)
            {
                continue;
            }

            Dialogue_Line dl = DialogueParser.Parse(line);

            Debug.Log(dl.dialogue);
        }
    }
}
