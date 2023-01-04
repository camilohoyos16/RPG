
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitiesController : MonoBehaviour
{
    public static EntitiesController Instance;

    private List<IEntity> m_entities = new();
    private List<IEntity> m_entitiesInRange = new(); //This will hold filtered entities by quadtree
    private List<IInteractable> m_interactablesEntities = new(); // This will hold filteres entities in range to take just the interactable ones
    private List<ICharacter> m_characters = new();

    private void Awake() {
        if(Instance != null) {
            Destroy(gameObject);
            return;
        } else {
            Instance = this;
        }

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

    public List<ICharacter> GetCharactersInRange(MathUtils.Vector3 position, float radius) {
        List<ICharacter> characterInRange = new();

        foreach (ICharacter character in m_characters) {
            if (MathUtils.PointsDistance(position, character.EntityPosition) < radius) {
                characterInRange.Add(character);
            }
        }

        return characterInRange;
    }

    private void CheckCharactersInteractions() {
        foreach (IInteractable entity in m_interactablesEntities) {
            foreach (ICharacter character in m_characters) {
                if (MathUtils.PointsDistance(entity.EntityPosition, character.EntityPosition) < entity.InteractRadius) {
                    if (!character.HasAction(ActionsDictionary.INTERACT_ACTION_ID)) {
                        InteractAction newAction = new InteractAction(entity);
                        character.AddActionToCharacter(newAction);
                    }
                } else {
                    if (character.HasAction(ActionsDictionary.INTERACT_ACTION_ID)) {
                        InteractAction action = (InteractAction)character.GetAction(ActionsDictionary.INTERACT_ACTION_ID);
                        if (action.GetInteracObject() == entity) {
                            character.RemoveAction(ActionsDictionary.INTERACT_ACTION_ID);
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

        if(e.Entity is IInteractable iIteractable) {
            m_interactablesEntities.Add(iIteractable);
        }

        if(e.Entity is ICharacter iCharacter) {
            m_characters.Add(iCharacter);
            if(iCharacter is IControllerCharacter controllerCharacter) {
                controllerCharacter.AddActionToCharacter(new MoveForwardAction());
                controllerCharacter.AddActionToCharacter(new MoveBackAction());
                controllerCharacter.AddActionToCharacter(new MoveLeftAction());
                controllerCharacter.AddActionToCharacter(new MoveRightAction());
            }
        }
    }
    #endregion
}
