
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitiesController : MonoBehaviour
{
    private List<IEntity> m_entities;
    private List<IEntity> m_entitiesInRange; //This will hold filtered entities by quadtree
    private List<IInteractable> m_interactablesEntities; // This will hold filteres entities in range to take just the interactable ones
    private List<ICharacter> m_characters;

    private void Awake() {
        EventManager.Instance.Register(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckCharactersInteractions();
    }

    private void CheckCharactersInteractions() {
        foreach (IInteractable entity in m_interactablesEntities) {
            foreach (ICharacter character in m_characters) {
                if (MathUtils.PointsDistance(entity.EntityPosition, character.EntityPosition) < entity.InteractRadius) {
                    // Podria tener un input manager done tenga toda la configuracion de la accionacion de los botones con el id de cada action
                    InteractAction newAction = new InteractAction("", entity);
                    character.AddActionToCharacter(newAction);
                }
            }
        }
    }

    #region Events
    [EventListener]
    public void OnResgisterEntity(OnRegisterEntityEvent e) {
        m_entities.Add(e.Entity);
    }
    #endregion
}

public class OnRegisterEntityEvent : GlobalEvent
{
    public IEntity Entity;

    public OnRegisterEntityEvent(IEntity entity) {
        Entity = entity;
    }
}
