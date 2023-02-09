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
    private static float SecondToUpdateWorld => 1 / (float)FRAMES_PER_SECOND;

    private void Awake() {
        Instance = this;
        ItemsDatabase.Initialize();
        m_worldState = new WorldState();
    }

    private void Update()
    {
        m_worldState.NextTickCounter += Time.deltaTime;

        InputController.UpdateController(m_worldState);
        if(m_worldState.NextTickCounter >= SecondToUpdateWorld)
        {
            m_worldState.DeltaTime = SecondToUpdateWorld;
            m_worldState.LastTickTime = Time.time;
            m_worldState.TotalTicks++;
            m_worldState.NextTickCounter -= SecondToUpdateWorld;
            EntitiesController.Instance.UpdateController(m_worldState);
            CameraController.UpdateCamera(m_worldState);

            Debug.Log(m_worldState.DeltaTime);
        }

        m_worldState.UpdateState(InputController);
    }

    private void FixedUpdate()
    {
    }

    public DynamicStatsDatabase DynamicStatsDatabaseInstance;
    public ItemsDatabase ItemsDatabase;
    public EntitiesController EntitiesController;
    public CameraController CameraController;

    public InputController InputController;
}

public class WorldState
{
    public float DeltaTime;
    public float NextTickCounter;
    public float LastTickTime;
    public float TotalTicks;

    public InputContext CurrentInputContext;

    public void UpdateState(InputController inputController)
    {
        DeltaTime = Time.smoothDeltaTime;
        CurrentInputContext = inputController.currentInputContext;
    }
}