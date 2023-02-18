using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITag 
{
    public HashSet<Tag> Tags { get; }
    public void AddTag(Tag newTag);
    public void RemoveTag(Tag removeTag);
    public bool HasTag(Tag tag);
}
