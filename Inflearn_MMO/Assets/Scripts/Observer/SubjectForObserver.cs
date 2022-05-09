using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SubjectForObserver
{
    private List<Observer> m_Observers = new List<Observer>();

    public void AddObserver(ref Observer observer)
    {
        m_Observers.Add(observer);
    }

    public void RemoveObserver(ref Observer observer)
    {
        if (m_Observers.Contains(observer) == true)
        {
            m_Observers.Remove(observer);
        }
    }

    protected void Notify(Entity entity, UnityEvent evt)
    {
        for(int i = 0; i < m_Observers.Count; i++)
        {
            m_Observers[i].OnNotify(entity, evt);
        }

    }

}
