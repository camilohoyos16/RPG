using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PcInputContext: InputContext
{
    public override string DeviceId => InputUtilities.PC_INPUT_DEVICE_ID;

}

public class PcInputUpdater : InputUpdater
{
    Vector2 mousePosition = new Vector2();

    public override Dictionary<string, InputInfo> UpdateInputs()
    {
        /// Keyboard Inputs
        #region Keyboard inputs
        CheckInputExistAndHasBeenUsed(Keyboard.current.qKey);
        CheckInputExistAndHasBeenUsed(Keyboard.current.wKey);
        CheckInputExistAndHasBeenUsed(Keyboard.current.eKey);
        CheckInputExistAndHasBeenUsed(Keyboard.current.rKey);
        CheckInputExistAndHasBeenUsed(Keyboard.current.tKey);
        CheckInputExistAndHasBeenUsed(Keyboard.current.yKey);
        CheckInputExistAndHasBeenUsed(Keyboard.current.uKey);
        CheckInputExistAndHasBeenUsed(Keyboard.current.iKey);
        CheckInputExistAndHasBeenUsed(Keyboard.current.oKey);
        CheckInputExistAndHasBeenUsed(Keyboard.current.pKey);
        CheckInputExistAndHasBeenUsed(Keyboard.current.aKey);
        CheckInputExistAndHasBeenUsed(Keyboard.current.sKey);
        CheckInputExistAndHasBeenUsed(Keyboard.current.dKey);
        CheckInputExistAndHasBeenUsed(Keyboard.current.fKey);
        CheckInputExistAndHasBeenUsed(Keyboard.current.gKey);
        CheckInputExistAndHasBeenUsed(Keyboard.current.hKey);
        CheckInputExistAndHasBeenUsed(Keyboard.current.jKey);
        CheckInputExistAndHasBeenUsed(Keyboard.current.kKey);
        CheckInputExistAndHasBeenUsed(Keyboard.current.lKey);
        CheckInputExistAndHasBeenUsed(Keyboard.current.zKey);
        CheckInputExistAndHasBeenUsed(Keyboard.current.xKey);
        CheckInputExistAndHasBeenUsed(Keyboard.current.cKey);
        CheckInputExistAndHasBeenUsed(Keyboard.current.vKey);
        CheckInputExistAndHasBeenUsed(Keyboard.current.bKey);
        CheckInputExistAndHasBeenUsed(Keyboard.current.nKey);
        CheckInputExistAndHasBeenUsed(Keyboard.current.mKey);
        CheckInputExistAndHasBeenUsed(Keyboard.current.digit0Key);
        CheckInputExistAndHasBeenUsed(Keyboard.current.digit1Key);
        CheckInputExistAndHasBeenUsed(Keyboard.current.digit2Key);
        CheckInputExistAndHasBeenUsed(Keyboard.current.digit3Key);
        CheckInputExistAndHasBeenUsed(Keyboard.current.digit4Key);
        CheckInputExistAndHasBeenUsed(Keyboard.current.digit5Key);
        CheckInputExistAndHasBeenUsed(Keyboard.current.digit6Key);
        CheckInputExistAndHasBeenUsed(Keyboard.current.digit7Key);
        CheckInputExistAndHasBeenUsed(Keyboard.current.digit8Key);
        CheckInputExistAndHasBeenUsed(Keyboard.current.digit9Key);
        CheckInputExistAndHasBeenUsed(Keyboard.current.spaceKey);
        #endregion

        /// Mouse Inputs
        #region Mouse inputs
        CheckInputExistAndHasBeenUsed(Mouse.current.leftButton);
        CheckInputExistAndHasBeenUsed(Mouse.current.rightButton);
        CheckInputExistAndHasBeenUsed(Mouse.current.middleButton);
        //MouseChangeFromZero = new Vector2(
        //    mousePosition.x - Mouse.current.position.x.ReadValue(),
        //    mousePosition.y - Mouse.current.position.y.ReadValue());
        MouseChangeFromZero = new Vector2(
            Mouse.current.delta.x.ReadValue(),
            Mouse.current.delta.y.ReadValue());
        #endregion

        mousePosition.x = Mouse.current.position.x.ReadValue();
        mousePosition.y = Mouse.current.position.y.ReadValue();

        return m_actionsPressedIdCache;
    }

    private void CheckInputExistAndHasBeenUsed(ButtonControl buttonControl)
    {
        string actionId = InputController.GetActionByInput(buttonControl.name);

        if (buttonControl.wasPressedThisFrame)
        {
            AddActionUsedToList(actionId, 1);
        }
        else
        {
            if (buttonControl.wasReleasedThisFrame)
            {
                RemoveActionUsedFromList(actionId);
            }
        }
    }

    private void AddActionUsedToList(string actionId, float value)
    {
        m_actionsPressedIdCache.Add(actionId, new InputInfo(actionId, value));
        //Debug.Log(string.Concat(actionId, " was added to inputs"));
    }

    private void RemoveActionUsedFromList(string actionId)
    {
        m_actionsPressedIdCache.Remove(actionId);
        //Debug.Log(string.Concat(actionId, " was removed from inputs"));
    }

    #region KeyboardKeys

    #endregion
}