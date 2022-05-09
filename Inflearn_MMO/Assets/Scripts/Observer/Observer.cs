using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Observer
{
    ~Observer()
    {
        Util.Log("~Observer");
    }

    public virtual void OnNotify(Entity entity, UnityEvent evt)
    {
        Util.Log("Observer::OnNotify");
    }
}
