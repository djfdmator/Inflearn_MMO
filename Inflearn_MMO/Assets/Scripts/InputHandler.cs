using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AT.SerializableDictionary;
using UnityEngine.Events;

[Serializable]
public class KeyActionEvent : UnityEvent { }

[System.Serializable]
public class DictionaryCommand : SerializableDictionary<KeyCode, Command> { }

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private Creature creature = null;

    private DictionaryCommand _commands = new DictionaryCommand();

    private void Awake()
    {
        if (creature == null)
            creature = GetComponent<Creature>();
    }

    private void Start()
    {
        BindCommands();

        Managers.Input.KeyAction -= HandleInput;
        Managers.Input.KeyAction += HandleInput;
    }

    void BindCommands()
    {
        _commands.Add(KeyCode.W, new ForwardCommand(creature.KeyAction_W));
        _commands.Add(KeyCode.S, new BackCommand(creature.KeyAction_S));
        _commands.Add(KeyCode.A, new RightCommand(creature.KeyAction_A));
        _commands.Add(KeyCode.D, new LeftCommand(creature.KeyAction_D));
    }

    public void HandleInput()
    {
        Command command = null;

        if (Input.GetKey(KeyCode.W))
        {
            _commands.TryGetValue(KeyCode.W, out command);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _commands.TryGetValue(KeyCode.S, out command);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _commands.TryGetValue(KeyCode.A, out command);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _commands.TryGetValue(KeyCode.D, out command);
        }

        if(command != null) command.Execute();
    }


}
