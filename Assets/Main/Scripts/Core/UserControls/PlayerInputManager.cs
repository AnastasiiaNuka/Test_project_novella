using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIALOGUE
{


    public class PlayerInputManager : MonoBehaviour //отвечает за переключение 
    {

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
                PromptAdvance();



        }

        public void PromptAdvance()
        {
            DialogueSystem.instance.OnUserPrompt_Next();
        }
    }
}
