using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ActionResult
{
    public bool WasSuccessful;
    public string Message;

    public ActionResult(bool wasSuccessful, string message) {
        WasSuccessful = wasSuccessful;
        Message = message;
    }
}
