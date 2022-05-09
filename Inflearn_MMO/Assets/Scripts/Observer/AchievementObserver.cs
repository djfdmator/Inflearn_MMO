using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AchivementObserver : Observer
{
    ~AchivementObserver()
    {
        Util.Log("~AchivementObserver");
    }

    public override void OnNotify(Entity entity, UnityEvent evt)
    {
        base.OnNotify(entity, evt);
        Util.Log("AchivementObserver::OnNotify");


    }
}
