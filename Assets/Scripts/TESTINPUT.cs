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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            JumpAction jump = new JumpAction("j");
            player.AddActionToPlayer(jump);
        }
    }
}
