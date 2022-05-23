using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Operable
{
    protected override void Operation()
    {
        Debug.Log("Door mamu");
        transform.position = new Vector2(transform.position.x, transform.position.y + 2);
    }

    protected override void Stoppage()
    {

    }
}
