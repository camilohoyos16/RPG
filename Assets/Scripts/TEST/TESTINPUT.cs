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
        IndexModified();

    }

    public void TEST() {

    }

    int index;
    int[] arrayIndex = new int[5];

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddIndex();
        }
    }

    private void AddIndex()
    {
        index++;
        IndexModified();
    }

    private void IndexModified()
    {
        int newIndex = index % (arrayIndex.Length);
        Debug.Log(newIndex);
    }

    private void OnAnyButtonPressed()
    {

    }
}
