using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControllerCharacter : ICharacter
{
    public void Jump();
    public void Move();
    public void Attack();
}
