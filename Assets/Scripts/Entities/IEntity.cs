using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity
{
    public MathUtils.SVector3 EntityPosition { get; set; }

    public void InitEntity();
    public void UpdateEntity(WorldState worldState);
}
