using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UtilsClasses;

public interface IOperable
{
    void Operate();
    void Stop();
}

public class Operable : MonoBehaviour, IOperable//, IClassWithEvents
{
    public bool isOperating;
    public void Operate()
    {
        if(!isOperating)
        {
            isOperating = true;
            Operation();
        }
    }

    protected virtual void Operation()
    {

    }

    public void Stop()
    {
        if(isOperating)
        {
            isOperating = false;
            Stoppage();
        }
    }

    protected virtual void Stoppage()
    {

    }


}
