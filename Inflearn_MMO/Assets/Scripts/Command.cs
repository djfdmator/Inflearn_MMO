using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Command
{
    public KeyActionEvent _action = null;
    public Command(KeyActionEvent action) { _action = action; }
    public virtual void Execute() { Util.Log($"Execute [{_action.ToString()}]!"); }
}

[Serializable]
public class ForwardCommand : Command
{
    public ForwardCommand(KeyActionEvent action) : base(action)
    {
    }

    public override void Execute()
    {
        base.Execute();

        if (_action != null)
            _action.Invoke();
    }
}

[Serializable]
public class BackCommand : Command
{
    public BackCommand(KeyActionEvent action) : base(action)
    {
    }

    public override void Execute()
    {
        base.Execute();

        if (_action != null)
            _action.Invoke();
    }
}

[Serializable]
public class RightCommand : Command
{
    public RightCommand(KeyActionEvent action) : base(action)
    {
    }

    public override void Execute()
    {
        base.Execute();

        if (_action != null)
            _action.Invoke();
    }
}

[Serializable]
public class LeftCommand : Command
{
    public LeftCommand(KeyActionEvent action) : base(action)
    {
    }

    public override void Execute()
    {
        base.Execute();

        if (_action != null)
            _action.Invoke();
    }
}
