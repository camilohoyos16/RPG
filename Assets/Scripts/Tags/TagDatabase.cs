using UnityEngine;

[CreateAssetMenu(fileName = "TagsDatabase", menuName = "Tags/New TagDatabase", order = 1)]
public class TagDatabase : ScriptableObject, IDatabase
{
    // ScriptableObjects
    [SerializeField]
    private TagScriptableObject MoveInputSpeedModifierTagConfig;

    //Tag
    [HideInInspector]
    public Tag MoveInputSpeedModifier;

    public void Initialize()
    {
        TagsDictionary.MoveInputSpeedModifier = new Tag(MoveInputSpeedModifierTagConfig.Tag);
    }
}

public static class TagsDictionary
{
    public static Tag MoveInputSpeedModifier;

}