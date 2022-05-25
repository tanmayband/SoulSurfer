using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Operable
{
    public Transform door;
    protected override void Operation()
    {
        door.transform.localPosition = new Vector2(door.transform.localPosition.x, door.transform.localPosition.y + 2);
    }

    protected override void Stoppage()
    {

    }
}
