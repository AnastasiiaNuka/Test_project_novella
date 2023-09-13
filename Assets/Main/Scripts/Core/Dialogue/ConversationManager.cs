using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIALOGUE
{

    public class ConversationManager
    {
        private DialogueSystem dialogueSystem => DialogueSystem.instance;

        private Coroutine process = null;
        public bool isRunning => process != null;
      
        public void StartConversation (List<string> conversation)
        {
            StopConversation();

            process = dialogueSystem.StartCoroutine(RunningConversation(conversation));
        }


        public void StopConversation ()
        {
            if (!isRunning)
                return;
            dialogueSystem.StopCoroutine(process);
            process = null;
        }
        IEnumerator RunningConversation (List<string> conversation)
        {
            for(int i = 0; i < conversation.Count; i++)
            {
                //dont show any blank lines or try to run any logic on them.
                if (string.IsNullOrWhiteSpace(conversation[i]))
                    continue;
                Dialogue_Line line = DialogueParser.Parse( conversation[i]); 
                //Show dialogue 
                if(line.hasDialogue)
                {
                    yield return Line_RunDialogue(line);
                }
                if (line.hasCommands) //Run ane commends
               yield return Line_RunCommands(line);
            }

        }
        IEnumerator Line_RunDialogue(Dialogue_Line line)
        {
            yield return null;
        }
        IEnumerator Line_RunCommands(Dialogue_Line line)
        {
            yield return null;
        }

    }
}
