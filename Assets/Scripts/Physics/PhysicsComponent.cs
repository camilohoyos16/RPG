using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsComponent : MonoBehaviour, IGameComponent
{
    public string GameComponentId { get => GameComponentDictionary.PHYSICS_COMPONENT_ID; }

    [HideInInspector] public Rigidbody Rigidbody;
    [HideInInspector] public Collider Collider;

    public void InitComponent()
    {
        Rigidbody = GetComponentInChildren<Rigidbody>();
        Collider = GetComponentInChildren<Collider>();
    }

    public void UpdateComponent(WorldState worldState)
    {
    }
}
