public class InputManager
{
    public static string AttackInput = "q|Q";
    public static string InteractInput = "e|E";
    public static string JumpInput = " ";

    public static bool WasInputUsed(string staticInput, string dinamycInput) {
        // gURADAR EL INPUT EN lower case para evitar hacer el split y tener que gaurdar mas de un input con la separacion
        string[] staticInputs = staticInput.Split('|');
        foreach (string input in staticInputs) {
            if (input.Equals(dinamycInput)) {
                return true;
            }
        }
        return false;
    }
}