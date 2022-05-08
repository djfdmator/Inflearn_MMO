using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Creature : MonoBehaviour
{
    //public Action<Creature> KeyAction_W = null;
    //public Action<Creature> KeyAction_S = null;
    //public Action<Creature> KeyAction_A = null;
    //public Action<Creature> KeyAction_D = null;

    [FormerlySerializedAs("onClick")]
    [SerializeField]
    public KeyActionEvent KeyAction_W = new KeyActionEvent();

    [FormerlySerializedAs("onClick")]
    [SerializeField]
    public KeyActionEvent KeyAction_S = new KeyActionEvent();

    [FormerlySerializedAs("onClick")]
    [SerializeField]
    public KeyActionEvent KeyAction_A = new KeyActionEvent();

    [FormerlySerializedAs("onClick")]
    [SerializeField]
    public KeyActionEvent KeyAction_D = new KeyActionEvent();
}
