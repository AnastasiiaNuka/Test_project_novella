using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMD_databaseExtentions_Examples : CMD_DatabaseExtension //реализации различных команд и их расширений + движение персонажа(Image) вправо-влево
{
    new public static void Extend(CommandDatabase database)
    {
        //добавить команду без параметров
        database.AddCommand("print", new Action(PrintDefaultMessage));
        database.AddCommand("print_1p", new Action<string>(PrintUsermessage));
        database.AddCommand("print_mp", new Action<string[]>(PrintLines));

        database.AddCommand("lambda", new Action(() => { Debug.Log("Print a default message to console from lambda command"); }));
        database.AddCommand("lambda_lp", new Action<string>((arg) => { Debug.Log($"Log user lambda message: '{arg}'"); }));
        database.AddCommand("lambda_mp", new Action<string[]>((args) => { Debug.Log(string.Join(",", args)); }));


        database.AddCommand("process", new Func<IEnumerator>(SimpleProcess));
        database.AddCommand("process_1p", new Func<string, IEnumerator>(LineProcess));
        database.AddCommand("process_mp", new Func<string[], IEnumerator>(MultiLineProcess));

        database.AddCommand("moveCharDemo", new Func<string, IEnumerator>(MoveCharacter));
    }

    private static void PrintDefaultMessage()
    {
        Debug.Log("Print a default message to console.");
    }

    private static void PrintUsermessage(string message)
    {
        Debug.Log($"Message : '{message}'");
    }

    private static void PrintLines(string[] lives)
    {
        int i = 1;
        foreach (string line in lives)
        {
            Debug.Log($"{i++}. ' {line}'");
        }
    }

    private static IEnumerator SimpleProcess()
    {
        for (int i = 0; i <= 5; i++)
        {
            Debug.Log($"Process Running...[{i}]");
            yield return new WaitForSeconds(1);
        }
    }
    private static IEnumerator LineProcess(string data)
    {
        if (int.TryParse(data, out int num))
        {
            for (int i = 0; i <= num; i++)
            {
                Debug.Log($"Process Running...[{i}]");
                yield return new WaitForSeconds(1);
            }
        }
    }
    private static IEnumerator MultiLineProcess(string[] data)
    {
        foreach (string line in data)
        {
            Debug.Log($"process message:;{line}'");
            yield return new WaitForSeconds(0.5f);
        }
    }

    private static IEnumerator MoveCharacter(string direction)
    {
        bool left = direction.ToLower() == "left";

        Transform character = GameObject.Find("Image").transform;
        float moveSpeed = 50;

        float targetX = left ? -8 : 8;

        float currentX = character.position.x;

        while (Mathf.Abs(targetX - currentX) > 0.1f)
        {
            //Debug.Log($"Moving character to {(left ? "left" : "right")} [{currentX}/{targetX}]");
            currentX = Mathf.MoveTowards(currentX, targetX, moveSpeed * Time.deltaTime);
            character.position = new Vector3(currentX, character.position.y, character.position.z);
            yield return null;
        }
    }
}
