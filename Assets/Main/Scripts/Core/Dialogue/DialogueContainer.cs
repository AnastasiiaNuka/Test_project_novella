
using UnityEngine;
using TMPro;
using System;

namespace DIALOGUE
{
    [Serializable]
    public class DialogueContainer
    {
        public GameObject root;
        public NameContainer nameContainer; //��� ����� 
        public TextMeshProUGUI dialogueText; //������ �����

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


