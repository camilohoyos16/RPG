using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TESTINPUT : MonoBehaviour
{
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
    }
    
    public void TEST() {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = new Vector2(Mouse.current.delta.x.ReadValue(), Mouse.current.radius.y.ReadValue());
    }

    private void OnAnyButtonPressed()
    {

    }
}
