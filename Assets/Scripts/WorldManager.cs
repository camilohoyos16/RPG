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

    private void Awake() {
        Instance = this;
        ItemsDatabase.Initialize();
        m_worldState = new WorldState();
        TagsDatabase.InitTags();
        m_worldState.TagsDatabase = TagsDatabase;
        m_worldState.DynamicStatsDatabase = DynamicStatsDatabaseInstance;
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
            EntitiesController.Instance.UpdateController(m_worldState);
            CameraController.UpdateCamera(m_worldState);
        }

    }

    private void FixedUpdate()
    {
    }

    public DynamicStatsDatabase DynamicStatsDatabaseInstance;
    public ItemsDatabase ItemsDatabase;
    public EntitiesController EntitiesController;
    public CameraController CameraController;
    public TagDatabase TagsDatabase;

    public InputController InputController;
}

public class WorldState
{
    public float DeltaTime;
    public float NextTickCounter;
    public float LastTickTime;
    public float TotalTicks;

    public InputContext CurrentInputContext;
    public CameraControllerState CameraControllerState;
    public DynamicStatsDatabase DynamicStatsDatabase;
    public TagDatabase TagsDatabase;

    public void UpdateState(InputController inputController, CameraController cameraController)
    {
        DeltaTime = WorldManager.SecondToUpdateWorld;
        CurrentInputContext = inputController.currentInputContext;
        CameraControllerState = cameraController.CameraControllerState;
    }
}