using System.Collections.Generic;

public class InputManager
{
    public static string AttackInput = "q";
    public static string InteractInput = "e";
    public static string JumpInput = " ";
    public static string MoveForwardInput = "w";
    public static string MoveBackInput = "s";
    public static string MoveRightInput = "d";
    public static string MoveLeftInput = "a";

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
            case ActionsDictionary.ATTACK_MELEE_ACTION_ID:
                return AttackInput;
            case ActionsDictionary.INTERACT_ACTION_ID:
                return InteractInput;
            case ActionsDictionary.JUMP_ACTION_ID:
                return JumpInput;
            case ActionsDictionary.MOVE_FORWARD_ACTION_ID:
                return MoveForwardInput;
            case ActionsDictionary.MOVE_BACK_ACTION_ID:
                return MoveBackInput;
            case ActionsDictionary.MOVE_LEFT_ACTION_ID:
                return MoveLeftInput;
            case ActionsDictionary.MOVE_RIGHT_ACTION_ID:
                return MoveRightInput;
            default:
                return "";
        }
    }
}
