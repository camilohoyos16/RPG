using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MathUtils;

/// <summary>
/// Spherical coordinates definition and examples were checked on:
/// 1. http://laplace.us.es/wiki/index.php/Coordenadas_esféricas._Definición
/// 2. https://www.mineduc.gob.gt/DIGECADE/documents/Telesecundaria/Recursos%20Digitales/3o%20Recursos%20Digitales%20TS%20BY-SA%203.0/MATEMATICA/U2%20pp%2039%20esfera.pdf
/// 3. https://www.neurochispas.com/wiki/coordenadas-esfericas-a-cartesianas/
/// 4. https://www.neurochispas.com/wiki/coordenadas-cilindricas-a-cartesianas/
/// </summary>

public class CameraControllerState
{
    public Transform CameraTransform;

    public void UpdateState(Camera camera)
    {
        CameraTransform = camera.transform;
    }
}

public class CameraController : MonoBehaviour, IController
{
    /// <summary>
    /// TODO: This probably should be searched from entities controller later with a certain system of tags
    /// </summary>
    public GameObject player;
    public CameraControllerState CameraControllerState { get; private set; } = new CameraControllerState();

    [SerializeField]
    private float m_distanceFromPlayer;

    /// <summary>
    /// This z value might be sum to the player z position
    /// </summary>
    [SerializeField]
    private float m_cameraLookAtPointHeight;
    [SerializeField]
    private float m_horizontalSpeed;
    [SerializeField]
    private float m_verticalSpeed;

    private float m_currentAzimuth;
    private float m_currentTetha;

    private float m_initialAzimuth = 0;
    private float m_initialTetha = 90;

    /// <summary>
    /// Azimuth calculates position from west to east, making an entire circle around. 
    /// That is why goes from 0 to 360
    /// </summary>
    private const float m_minAzimuth = 0;
    private const float m_maxAzimuth = 360;

    /// <summary>
    /// Tetha caculates position from north to south, finishing to cover all the possibles
    /// point in conjuction with <see cref="m_currentAzimuth"/>.
    /// That is why we just would need to cover from 0 to 180.
    /// This angles are just handmade to avoid weird camera positions
    /// </summary>
    private const float m_minTetha = 45;
    private float m_maxTetha = 120;

    private Camera m_camera;


    public void InitController()
    {
        m_camera = Camera.main;

        m_currentAzimuth = m_initialAzimuth;
        m_currentTetha = m_initialTetha;
    }

    public void UpdateController(WorldState worldState)
    {
        /// Need to do it smoothly
        SVector3 playerPosition = player.transform.position;
        playerPosition.y += m_cameraLookAtPointHeight;
        MovingOnDegrees(worldState.CurrentInputContext.CameraPointerChange);
        Vector3 cameraPosition = playerPosition + MathUtils.SphericalToCartesian(m_distanceFromPlayer, m_currentAzimuth, m_currentTetha);
        m_camera.transform.position = cameraPosition;
        m_camera.transform.LookAt(player.transform);

        CameraControllerState.UpdateState(m_camera);
    }

    public void MovingOnDegrees(Vector2 pointerMove)
    {
        if (pointerMove.x < 0)
        {
            m_currentAzimuth -= m_horizontalSpeed * Time.deltaTime;
        }
        else if (pointerMove.x > 0)
        {
            m_currentAzimuth += m_horizontalSpeed * Time.deltaTime;
        }

        if (pointerMove.y < 0)
        {
            m_currentTetha -= m_verticalSpeed * Time.deltaTime;
        }
        else if (pointerMove.y > 0)
        {
            m_currentTetha += m_verticalSpeed * Time.deltaTime;
        }

        m_currentAzimuth = Mathf.Clamp(m_currentAzimuth, m_minAzimuth, m_maxAzimuth);
        if (m_currentAzimuth >= m_maxAzimuth)
        {
            m_currentAzimuth = m_minAzimuth;
        }
        else if (m_currentAzimuth <= m_minAzimuth)
        {
            m_currentAzimuth = m_maxAzimuth;
        }

        m_currentTetha = Mathf.Clamp(m_currentTetha, m_minTetha, m_maxTetha);
    }
}
