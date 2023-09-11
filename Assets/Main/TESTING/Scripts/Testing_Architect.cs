using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TESTING
{ 
public class Testing_Architect : MonoBehaviour
{
        DialogueSystem ds;
        TextArchitect architect;

        string[] lines = new string[5]
        {
            "Randome line! ",
            "Say smthing... ",
            "Hello world! ",
            "Its a new day... ",
            "I can by myself flowers! "
        };
    void Start()
    {
            ds = DialogueSystem.instance;
            architect = new TextArchitect(ds.dialogueContainer.dialogueText);
            architect.buildMethod = TextArchitect.BuildMethod.typewriter;
            architect.speed = 0.5f;
        }

   
    void Update()
    {
            string longLine = "This is a very long line..................................................................................";
           
            if (Input.GetKeyDown(KeyCode.Space))
            { if (architect.isBuilding)
                {
                    if (architect.hurryUp)
                        architect.hurryUp = true;
                    else
                        architect.ForceComplete();
                }
            else
                    architect.Build(longLine);
                //architect.Build(lines[Random.Range(0, lines.Length)]);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                architect.Append(longLine);
                //architect.Append(lines[Random.Range(0, lines.Length)]);
            }
         
    }
}
}