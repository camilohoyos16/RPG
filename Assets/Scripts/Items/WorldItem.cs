using UnityEngine;

public class WorldItem : MonoBehaviour, IItem, IEntity
{
    /// <summary>
    /// From <see cref="IEntity"/>
    /// </summary>
    public MathUtils.Vector3 EntityPosition { get => transform.position; set => transform.position = value; }

    /// <summary>
    /// From <see cref="IItem"/>
    /// </summary>
    public ItemData ItemData { get; set; }

    #region IEntity implementation

    public void UpdateEntity() {
        throw new System.NotImplementedException();
    }

    #endregion

    #region IItem implementation

    public void UseItem() {
        throw new System.NotImplementedException();
    }

    #endregion
}
