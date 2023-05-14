using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    /// WWWWWWWWWWWWWWWWWWWWWIIIIIIIIIIIIIIIIIIIIIIIIIPPPPPPPPPPPPPPPPPP
    /// <summary>
    /// All of this should be made with WorldMnager but instantiating a prefab
    /// </summary>
    public static WorldManager Instance;
    private WorldState m_worldState;

    private const int FRAMES_PER_SECOND = 60;
    public static float SecondToUpdateWorld => 1 / (float)FRAMES_PER_SECOND;

    [SerializeField] private List<ScriptableObject> m_initialDatabases;

    private void Awake() {
        Instance = this;
        ItemsDatabase.Initialize();
        EntitiesController.InitController();
        CameraController.InitController();
        InputController.InitController();
        UiController.InitController();
        m_worldState = new WorldState();
        m_worldState.UiController = UiController;
        foreach (Object databaseObject in m_initialDatabases)
        {
            if(databaseObject is IDatabase database)
            {
                database.Initialize();
            }
        }
    }

    private void Update()
    {
        m_worldState.NextTickCounter += Time.deltaTime;

        InputController.UpdateController(m_worldState);
        m_worldState.UpdateState(InputController, CameraController);
        if(m_worldState.NextTickCounter >= SecondToUpdateWorld)
        {
            m_worldState.DeltaTime = SecondToUpdateWorld;
            m_worldState.LastTickTime = Time.time;
            m_worldState.TotalTicks++;
            m_worldState.NextTickCounter -= SecondToUpdateWorld;
            EntitiesController.UpdateController(m_worldState);
            CameraController.UpdateController(m_worldState);
            UiController.UpdateController(m_worldState);
        }

    }

    private void FixedUpdate()
    {
    }

    public StatsDatabase DynamicStatsDatabaseInstance;
    public ItemsDatabase ItemsDatabase;

    public EntitiesController EntitiesController;
    public CameraController CameraController;

    public InputController InputController;
    public UiController UiController;
}

public class WorldState
{
    public float DeltaTime;
    public float NextTickCounter;
    public float LastTickTime;
    public float TotalTicks;

    public InputContext CurrentInputContext;
    public CameraControllerState CameraControllerState;
    public UiController UiController;

    public void UpdateState(InputController inputController, CameraController cameraController)
    {
        DeltaTime = WorldManager.SecondToUpdateWorld;
        CurrentInputContext = inputController.currentInputContext;
        CameraControllerState = cameraController.CameraControllerState;
    }
}