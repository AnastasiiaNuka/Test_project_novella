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

        private TextArchitect architect = null;

        private bool userPrompt = false;

        public ConversationManager(TextArchitect architect)
        {
            this.architect = architect;
            dialogueSystem._onUserPrompt_Next += OnUserPrompt_Next;
        }

        public void StartConversation(List<string> conversation)
        {
            StopConversation();

            process = dialogueSystem.StartCoroutine(RunningConversation(conversation));
        }

        private void  OnUserPrompt_Next()
        {
            userPrompt = true;
        }


        public void StopConversation()
        {
            if (!isRunning)
                return;
            dialogueSystem.StopCoroutine(process);
            process = null;
        }
        IEnumerator RunningConversation(List<string> conversation)
        {
            for (int i = 0; i < conversation.Count; i++)
            {
                //dont show any blank lines or try to run any logic on them.
                if (string.IsNullOrWhiteSpace(conversation[i]))
                    continue;
                Dialogue_Line line = DialogueParser.Parse(conversation[i]);
                //Show dialogue 
                if (line.hasDialogue)
                {
                    yield return Line_RunDialogue(line);
                }
                if (line.hasCommands) //Run ane commends
                    yield return Line_RunCommands(line);

               
            }

        }
        IEnumerator Line_RunDialogue(Dialogue_Line line)
        {
            if (line.hasSpeaker)
                dialogueSystem.ShowSpeakerName(line.speaker.displayname);
            //else
            //    dialogueSystem.HideSpeakerName();

           yield return BuildLineSegments(line.dialogue);

            //wait for user input
            yield return WaitForUserInput();
        }
        IEnumerator Line_RunCommands(Dialogue_Line line)
        {
            Debug.Log(line.commands);
            yield return null;
        }

        IEnumerator BuildLineSegments(DL_DIALOGUE_DATA line)
        {
            for(int i =0; i <line.segments.Count; i++)
            {
                DL_DIALOGUE_DATA.DIALOGUE_SEGMENT segment = line.segments[i];

                yield return WaitForDialogueSegmentSignalToBeTriggered(segment);

                yield return BuildDialogue(segment.dialogue,segment.appendText);
            }
        }

        IEnumerator WaitForDialogueSegmentSignalToBeTriggered(DL_DIALOGUE_DATA.DIALOGUE_SEGMENT segment) 
        {
       switch (segment.startSignal)
            {
                case DL_DIALOGUE_DATA.DIALOGUE_SEGMENT.StartSignal.C:
                case DL_DIALOGUE_DATA.DIALOGUE_SEGMENT.StartSignal.A:
                    yield return WaitForUserInput();
                    break;
                case DL_DIALOGUE_DATA.DIALOGUE_SEGMENT.StartSignal.WC:
                case DL_DIALOGUE_DATA.DIALOGUE_SEGMENT.StartSignal.WA:
                    yield return new WaitForSeconds(segment.signalDelay);

                    break;
                default:
                    break;

            }
        }

        IEnumerator BuildDialogue(string dialogue, bool append = false)
        {
            if (!append)
                architect.Build(dialogue); //Build the dialogue
            else
                architect.Append(dialogue);  //Build for the dialogue to complete

            while (architect.isBuilding)
            {

                if (userPrompt)
                {
                    if (!architect.hurryUp)
                        architect.hurryUp = true;
                    else
                        architect.ForceComplete();

                    userPrompt = false;
                }
                yield return null;
            }

        }

        IEnumerator  WaitForUserInput()
        {
            while(!userPrompt)
                yield return null;

            userPrompt = false; 
        }
    }
}
