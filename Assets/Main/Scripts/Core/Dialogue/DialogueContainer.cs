
using UnityEngine;
using TMPro;
using System;

namespace DIALOGUE
{
    [Serializable]
    public class DialogueContainer //управление отображением текстом в диалогах
    {
        public GameObject root;
        public NameContainer nameContainer; //имя героя 
        public TextMeshProUGUI dialogueText; //диалог героя

        public void Show(string speakerName)
        {
            nameContainer.Show(speakerName);
        }

        public void Hide()
        {
            root.SetActive(false);
        }
    }
}


