using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static string AttackInput = "q|Q";
    public static string InteractInput = "e|E";
    public static string JumpInput = " ";

    public static bool WasInputUsed(string staticInput, string dinamycInput) {
        string[] staticInputs = staticInput.Split('|');
        foreach (string input in staticInputs) {
            if (input.Equals(dinamycInput)) {
                return true;
            }
        }
        return false;
    }
}
