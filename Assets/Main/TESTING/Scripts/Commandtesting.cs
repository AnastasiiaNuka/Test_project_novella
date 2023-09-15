using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commandtesting : MonoBehaviour //сценарий для проверки работы команд в игре с разными аргументами + подключение нажатия 
{
   
    void Start()
    {
        StartCoroutine(Running());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            CommandManager.instance.Execute("moveCharDemo", "left");
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            CommandManager.instance.Execute("moveCharDemo", "right");

    }


    IEnumerator Running()
    {
        yield return CommandManager.instance.Execute("print");
        yield return CommandManager.instance.Execute("print_1p", "Hello World");
        yield return CommandManager.instance.Execute("print_mp", "Line1", "Line2", "Line3");

        yield return CommandManager.instance.Execute("lambda");
        yield return CommandManager.instance.Execute("lambda_lp", "Hello lambda");
        yield return CommandManager.instance.Execute("lambda_mp", "Lambda1", "Lambda2", "Lambda3");

        yield return CommandManager.instance.Execute("process");
        yield return CommandManager.instance.Execute("process_1p", "3");
        yield return CommandManager.instance.Execute("process_mp", "Process Line1", "Process Line2", "Process Line3");
    }
}
