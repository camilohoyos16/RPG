using System.Collections.Generic;

public class InputManager
{
    public static string AttackInput = "q|Q";
    public static string InteractInput = "e|E";
    public static string JumpInput = " ";

    public static bool WasInputUsed(string assignedInput, string usedInput) {
        // gURADAR EL INPUT EN lower case para evitar hacer el split y tener que gaurdar mas de un input con la separacion
        // Lo de arriba se implementara a la mitad, si se guardara en lower case, pero se dejara el split
        // para facilitar el cambio de control: xbox, play, teclado, etc. En ese caso el contenido quedara algo asi: "shift|x|square"
        /// NOTE: no se tomara un desicion hasta no empezar a conectar y mirar como son los inputs
        string[] staticInputs = assignedInput.Split('|');
        foreach (string input in staticInputs) {
            if (input.Equals(usedInput)) {
                return true;
            }
        }
        return false;
    }

    public static string GetInputByAction(string actionId) {
        switch (actionId) {
            case ActionsDictionary.ATTACK_ACTION_ID:
                return AttackInput;
            case ActionsDictionary.INTERACT_ACTION_ID:
                return InteractInput;
            case ActionsDictionary.JUMP_ACTION_ID:
                return JumpInput;
            default:
                return "";
        }
    }
}
