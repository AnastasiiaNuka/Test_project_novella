using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIALOGUE;
using System.IO;

public class TestDialogueFiles : MonoBehaviour //демонстрация чтения текстового файла с диалогами, используя TextAsset, запускает диалоговую систему для обработки строк. 
{
    [SerializeField] private TextAsset fileToRead = null;

    void Start()
    {
        StartConversation();
    }

    void StartConversation()
    {
        List<string> lines = FileManager.ReadTextAsset(fileToRead);
        //for (int i = 0; i < lines.Count; i++)
        //{
        //    string line = lines[i];
        //    if (string.IsNullOrWhiteSpace (line)) continue;

        //    Dialogue_Line dl = DialogueParser.Parse(line);

        //    Debug.Log($"{dl.speaker.name} as [{(dl.speaker.castName != string.Empty ? dl.speaker.castName : dl.speaker.name)}]at {dl.speaker.castPosition}");

        //    List<(int l, string ex)> expr = dl.speaker.CastExpression;
        //    for (int c = 0; c < expr.Count; c++)
        //    {
        //        Debug.Log($"[Layer[{expr[c].l}) = '{expr[c].ex}']");
        //    }
        //}

        DialogueSystem.instance.Say(lines);
    }

    //    List<string> lines = new List<string>();

    //    using (StreamReader reader = new StreamReader(FilePaths.dialoguePath))
    //    {
    //        string? line;
    //        while ((line = reader.ReadLine()) != null)
    //        {
    //            lines.Add(line);
    //        }
    //    }
    //    DialogueSystem.instance.Say(lines);

    //    foreach (string line in lines)
    //    {
    //        if (line == string.Empty)
    //        { continue; }

    //        Dialogue_Line dl = DialogueParser.Parse(line);
    //    }
    //}
}
