
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitiesController : MonoBehaviour
{
    private List<IEntity> m_entities = new();
    private List<IEntity> m_entitiesInRange = new(); //This will hold filtered entities by quadtree
    private List<IInteractable> m_interactablesEntities = new(); // This will hold filteres entities in range to take just the interactable ones
    private List<ICharacter> m_characters = new();

    private void Awake() {
        EventManager.Instance.Register<OnRegisterEntityEvent>(gameObject, OnRegisterEntity);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEntities();
        CheckCharactersInteractions();
    }

    private void UpdateEntities() {
        foreach (IEntity entity in m_entities) {
            entity.UpdateEntity();
        }
    }


    private void CheckCharactersInteractions() {
        foreach (IInteractable entity in m_interactablesEntities) {
            foreach (ICharacter character in m_characters) {
                if (MathUtils.PointsDistance(entity.EntityPosition, character.EntityPosition) < entity.InteractRadius) {
                    if (!character.HasAction(ActionsDictionary.PLAYER_INTERACT_ACTION_ID)) {
                        InteractAction newAction = new InteractAction(InputManager.InteractInput, entity);
                        character.AddActionToCharacter(newAction);
                    }
                } else {
                    if (character.HasAction(ActionsDictionary.PLAYER_INTERACT_ACTION_ID)) {
                        InteractAction action = (InteractAction)character.GetAction(ActionsDictionary.PLAYER_INTERACT_ACTION_ID);
                        if (action.GetInteracObject() == entity) {
                            character.RemoveAction(ActionsDictionary.PLAYER_INTERACT_ACTION_ID);
                        }
                    }
                }
            }
        }
    }

    #region Events
    [EventListener]
    public void OnRegisterEntity(OnRegisterEntityEvent e) {
        m_entities.Add(e.Entity);

        if(e.Entity is IInteractable) {
            m_interactablesEntities.Add((IInteractable)e.Entity);
        }

        if(e.Entity is ICharacter) {
            m_characters.Add((ICharacter)e.Entity);
        }
    }
    #endregion
}
