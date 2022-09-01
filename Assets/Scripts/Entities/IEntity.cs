using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity
{
    public MathUtils.Vector3 EntityPosition { get; set; }

    public void UpdateEntity();
}
