using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsComponent : MonoBehaviour, IGameComponent
{
    public string GameComponentId { get => GameComponentDictionary.PHYSICS_COMPONENT_ID; }

    public Rigidbody Rigidbody;
    public Collider Collider;
}
