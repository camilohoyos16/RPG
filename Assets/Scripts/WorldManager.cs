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

    private void Awake() {
        Instance = this;
        ItemsDatabase.Initialize();
    }

    private void Update()
    {
        InputController.UpdateInputs();
        EntitiesController.Instance.UpdateEntities();
        CameraController.UpdateCamera(InputController.currentInputContext);
    }

    public DynamicStatsDatabase DynamicStatsDatabaseInstance;
    public ItemsDatabase ItemsDatabase;
    public EntitiesController EntitiesController;
    public CameraController CameraController;
}
