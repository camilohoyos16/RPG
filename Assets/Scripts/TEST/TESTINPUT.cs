using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Input.GetKeyDown(KeyCode.Space)) {
            JumpAction jump = new JumpAction(InputManager.JumpInput);
            player.AddActionToCharacter(jump);
        }
    }
}