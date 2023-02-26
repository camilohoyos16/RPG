using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour, IController
{
    private Canvas m_canvas;

    public void InitController()
    {
        m_canvas = GetComponent<Canvas>();

    }

    public void UpdateController(WorldState worldState)
    {
    }
}
