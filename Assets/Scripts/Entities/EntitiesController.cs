
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController
{
    public void UpdateController(WorldState worldState);
}

public class EntitiesController : MonoBehaviour, IController
{
    public static EntitiesController Instance;

    private List<IEntity> m_entities = new();
    private List<IEntity> m_entitiesInRange = new(); //This will hold filtered entities by quadtree
    private List<IInteractable> m_interactablesEntities = new(); // This will hold filteres entities in range to take just the interactable ones
    private List<ICharacter> m_characters = new();

    private List<IEntity> m_entitiesToDestroy = new();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }

        EventManager.Instance.Register<OnRegisterEntityEvent>(gameObject, OnRegisterEntity);
        EventManager.Instance.Register<OnDestroyEntityEvent>(gameObject, OnDestroyEntityEvent);
    }

    public void UpdateController(WorldState worldState)
    {
        CheckCharactersInteractions();
        foreach (IEntity entity in m_entities)
        {
            entity.UpdateEntity(worldState);
        }
        DestroyPendingEntities();
    }

    public List<ICharacter> GetCharactersInRange(MathUtils.SVector3 position, float radius)
    {
        List<ICharacter> characterInRange = new();

        foreach (ICharacter character in m_characters)
        {
            if (MathUtils.PointsDistance(position, character.EntityPosition) < radius)
            {
                characterInRange.Add(character);
            }
        }

        return characterInRange;
    }

    private void CheckCharactersInteractions()
    {
        foreach (IInteractable entity in m_interactablesEntities)
        {
            foreach (ICharacter character in m_characters)
            {
                if (entity == character)
                {
                    continue;
                }

                InteractAction interactAction;
                bool isObjectInRange = MathUtils.PointsDistance(entity.EntityPosition, character.EntityPosition) < entity.InteractRadius;
                if (character.HasAction(ActionsDictionary.INTERACT_ACTION_ID))
                {
                    interactAction = (InteractAction)character.GetAction(ActionsDictionary.INTERACT_ACTION_ID);
                    bool wasObjectInRange = interactAction.HasObject(entity);

                    if (isObjectInRange)
                    {
                        if (!wasObjectInRange)
                        {
                            interactAction.AddObjectToInteractWith(entity);
                        }
                    }
                }
                else
                {
                    if (isObjectInRange)
                    {
                        interactAction = new InteractAction();
                        interactAction.AddObjectToInteractWith(entity);
                        character.QueueActionToAdd(interactAction);
                    }
                }
            }
        }
    }

    private void DestroyPendingEntities()
    {
        foreach (IEntity entity in m_entitiesToDestroy)
        {
            m_entities.Remove(entity);
            m_interactablesEntities.Remove(entity as IInteractable);
            if (entity is WorldItem worldEntity)
            {
                Destroy(worldEntity.gameObject);
            }
        }

        m_entitiesToDestroy.Clear();
    }

    #region Events
    [EventListener]
    public void OnRegisterEntity(OnRegisterEntityEvent e)
    {
        m_entities.Add(e.Entity);

        if (e.Entity is IInteractable iIteractable)
        {
            m_interactablesEntities.Add(iIteractable);
        }

        if (e.Entity is ICharacter iCharacter)
        {
            m_characters.Add(iCharacter);
            if (iCharacter is IControllerCharacter controllerCharacter)
            {
                controllerCharacter.QueueActionToAdd(new MoveForwardRotatingPlayerAction());
                controllerCharacter.QueueActionToAdd(new MoveBackRotatingPlayerAction());
                controllerCharacter.QueueActionToAdd(new MoveLeftRotatingPlayerAction());
                controllerCharacter.QueueActionToAdd(new MoveRightRotatingPlayerAction());
            }
        }
    }

    [EventListener]
    public void OnDestroyEntityEvent(OnDestroyEntityEvent e)
    {
        m_entitiesToDestroy.Add(e.Entity);
    }
    #endregion
}
