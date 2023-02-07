using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputUpdater
{
    public abstract Dictionary<string, InputInfo> UpdateInputs();

    protected Dictionary<string, InputInfo> m_actionsPressedIdCache = new ();
    /// <summary>
    /// this value goes from 0 to 1 each time this got updated.
    /// </summary>
    public Vector2 MouseChangeFromZero = new Vector2();

}
