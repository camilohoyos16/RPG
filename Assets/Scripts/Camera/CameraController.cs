using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spherical coordinates definition and examples were checked on:
/// 1. http://laplace.us.es/wiki/index.php/Coordenadas_esféricas._Definición
/// 2. https://www.mineduc.gob.gt/DIGECADE/documents/Telesecundaria/Recursos%20Digitales/3o%20Recursos%20Digitales%20TS%20BY-SA%203.0/MATEMATICA/U2%20pp%2039%20esfera.pdf
/// 3. https://www.neurochispas.com/wiki/coordenadas-esfericas-a-cartesianas/
/// 4. https://www.neurochispas.com/wiki/coordenadas-cilindricas-a-cartesianas/
/// </summary>

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float DistanceFromPlayer;
    //public float UpperMaxAngle;
    //public float BottomMaxAngle;

    /// <summary>
    /// This z value might be sum to the player z position
    /// </summary>
    public float CameraLookAtPointHeight;
    public float cameraSpeed;

    private float m_currentAzimuth;
    private float m_currentTetha;

    private float m_initialAzimuth = 0;
    private float m_initialTetha = 90;

    private const float m_minAzimuth = 0;
    private const float m_maxAzimuth = 360;
    private const float m_minTetha = 45;
    private float m_maxTetha = 120;

    Camera m_camera;

    void Start()
    {
        m_camera = Camera.main;

        m_currentAzimuth = m_initialAzimuth;
        m_currentTetha = m_initialTetha;
    }

    public void UpdateCamera(InputContext inputContext)
    {
        /// Need to do it smoothly
        Vector3 playerPosition = player.transform.position;
        playerPosition.y += CameraLookAtPointHeight;
        MovingOnDegrees(inputContext.CameraPointerChange);
        Vector3 cameraPosition = playerPosition + SphericalToCartesian(DistanceFromPlayer, m_currentAzimuth, m_currentTetha);
        //Vector3 cameraPosition = playerPosition + CilindricalToCartesian(DistanceFromPlayer, m_currentAzimuth, CameraLookAtPointHeight);
        m_camera.transform.position = cameraPosition;
        m_camera.transform.LookAt(player.transform);
    }

    public void MovingOnDegrees(Vector2 pointerMove)
    {
        if (pointerMove.x < 0)
        {
            m_currentAzimuth -= cameraSpeed * Time.deltaTime;
        }
        else if (pointerMove.x > 0)
        {
            m_currentAzimuth += cameraSpeed * Time.deltaTime;
        }

        if (pointerMove.y < 0)
        {
            m_currentTetha -= cameraSpeed * Time.deltaTime;
        }
        else if (pointerMove.y > 0)
        {
            m_currentTetha += cameraSpeed * Time.deltaTime;
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

    private Vector3 CilindricalToCartesian(float r, float t, float h)
    {
        t *= Mathf.Deg2Rad;

        Vector3 cartesian = new Vector3();
        cartesian.x = r * Mathf.Cos(t);
        cartesian.z = r * Mathf.Sin(t);
        cartesian.y = h;

        return cartesian;
    }

    private Vector3 SphericalToCartesian(float r, float t, float a)
    {
        t *= -1;
        a *= Mathf.Deg2Rad;
        t *= Mathf.Deg2Rad;

        Vector3 cartesian = new Vector3();
        cartesian.x = r * Mathf.Sin(a) * Mathf.Cos(t);
        cartesian.z = r * Mathf.Sin(a) * Mathf.Sin(t);
        cartesian.y = r * Mathf.Cos(a);

        return cartesian;
    }

    private Vector3 CartesianToSpherical(float x, float y, float z)
    {
        Vector3 spherical = new Vector3();
        spherical.x = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2) + Mathf.Pow(z, 2));
        spherical.y = Mathf.Acos(z / spherical.x);
        spherical.z = Mathf.Asin(y/spherical.x*Mathf.Cos(spherical.y));

        return spherical;
    }
}
