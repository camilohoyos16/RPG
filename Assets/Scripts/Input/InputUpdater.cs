using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputUpdater
{
    public abstract Dictionary<string, InputInfo> UpdateInputs();

    protected Dictionary<string, InputInfo> m_actionsPressedIdCache = new ();
}
