using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputController : ScriptableObject
{
    public abstract float RetrieveMoveInput();

    public abstract bool RetrieveJumpInput();

    protected static bool GetButtonDown(string v)
    {
        throw new NotImplementedException();
    }
}
