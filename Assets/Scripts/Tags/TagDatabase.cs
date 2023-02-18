using UnityEngine;

[CreateAssetMenu(fileName = "TagsDatabase", menuName = "Tags/New TagDatabase", order = 1)]
public class TagDatabase : ScriptableObject
{
    // ScriptableObjects
    [SerializeField]
    private TagScriptableObject MoveInputSpeedModifierTagConfig;

    //Tag
    [HideInInspector]
    public Tag MoveInputSpeedModifier;

    public void InitTags()
    {
        MoveInputSpeedModifier = new Tag(MoveInputSpeedModifierTagConfig.Tag);
    }
}