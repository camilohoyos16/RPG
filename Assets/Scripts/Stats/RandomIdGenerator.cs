using System;
using UnityEngine;

public static class RandomIdGenerator
{
    private static int m_idCounter;

    public static int GetNewRandomId() {
        return m_idCounter++;
    }

    public static string GetNewModifierId()
    {
        string id = string.Concat(Time.time + DateTime.Now.ToString());
        return id;
    }
}
