using System;
using UnityEngine;

public static class MathUtils
{
    public static void LookAtToSameDirection(Transform a, Transform b)
    {
        Quaternion newRotation = a.rotation;
        newRotation.y = b.rotation.y;
        newRotation.w = b.rotation.w;
        a.rotation = newRotation;
    }

    public static SVector3 CilindricalToCartesian(float r, float t, float h)
    {
        t *= Mathf.Deg2Rad;

        SVector3 cartesian = new SVector3();
        cartesian.x = r * Mathf.Cos(t);
        cartesian.z = r * Mathf.Sin(t);
        cartesian.y = h;

        return cartesian;
    }

    public static SVector3 SphericalToCartesian(float r, float t, float a)
    {
        t *= -1;
        a *= Mathf.Deg2Rad;
        t *= Mathf.Deg2Rad;

        SVector3 cartesian = new SVector3();
        cartesian.x = r * Mathf.Sin(a) * Mathf.Cos(t);
        cartesian.z = r * Mathf.Sin(a) * Mathf.Sin(t);
        cartesian.y = r * Mathf.Cos(a);

        return cartesian;
    }

    public static Vector3 CartesianToSpherical(float x, float y, float z)
    {
        Vector3 spherical = new Vector3();
        spherical.x = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2) + Mathf.Pow(z, 2));
        spherical.z = Mathf.Acos(z / spherical.x);
        spherical.y = Mathf.Asin(y / spherical.x * Mathf.Cos(spherical.y));

        return spherical;
    }

    public static float PointsDistance(SVector3 point1, SVector3 point2) {
        float distance = MathF.Sqrt(MathF.Pow(point2.x - point1.x, 2) + MathF.Pow(point2.y - point1.y, 2));
        return distance;
    }

    /// <summary>
    /// S for simpler
    /// </summary>
    public struct SVector3
    {
        public float x;
        public float y;
        public float z;

        public static implicit operator SVector3(UnityEngine.Vector3 vector) {
            SVector3 newVector = new SVector3 {
                x = vector.x,
                y = vector.y,
                z = vector.z
            };
            return newVector;
        }

        public static implicit operator UnityEngine.Vector3(SVector3 vector) {
            UnityEngine.Vector3 newVector = new UnityEngine.Vector3 {
                x = vector.x,
                y = vector.y,
                z = vector.z
            };
            return newVector; 
        }

        public static SVector3 operator +(SVector3 a, SVector3 b)
        {
            SVector3 finalVector = new SVector3();
            finalVector.x = a.x + b.x;
            finalVector.y = a.y + b.y;
            finalVector.z = a.z + b.z;

            return finalVector;
        }

        public static Vector3 operator +(SVector3 a, Vector3 b)
        {
            Vector3 finalVector = new Vector3();
            finalVector.x = a.x + b.x;
            finalVector.y = a.y + b.y;
            finalVector.z = a.z + b.z;

            return finalVector;
        }

        public static Vector3 operator +(Vector3 a, SVector3 b)
        {
            SVector3 finalVector = new SVector3();
            finalVector.x = a.x + b.x;
            finalVector.y = a.y + b.y;
            finalVector.z = a.z + b.z;

            return finalVector;
        }

        public static SVector3 operator -(SVector3 a) {
            SVector3 finalVector = new SVector3();
            finalVector.x = a.x * -1;
            finalVector.y = a.y * -1;
            finalVector.z = a.z * -1;

            return finalVector;
        }

        public static Vector3 operator -(SVector3 a, Vector3 b) {
            SVector3 finalVector = new SVector3();
            finalVector.x = a.x - b.x;
            finalVector.y = a.y - b.y;
            finalVector.z = a.z - b.z;

            return finalVector;
        }

        public static SVector3 operator *(float d, SVector3 a) {
            SVector3 finalVector = new SVector3();
            finalVector.x = a.x * d;
            finalVector.y = a.y * d;
            finalVector.z = a.z * d;

            return finalVector;
        }
        public static SVector3 operator *(SVector3 a, float d) {
            SVector3 finalVector = new SVector3();
            finalVector.x = a.x * d;
            finalVector.y = a.y * d;
            finalVector.z = a.z * d;

            return finalVector;
        }
        public static SVector3 operator /(SVector3 a, float d) {
            SVector3 finalVector = new SVector3();
            finalVector.x = a.x / d;
            finalVector.y = a.y / d;
            finalVector.z = a.z / d;

            return finalVector;
        }
        public static bool operator ==(SVector3 a, SVector3 b) {
            bool passedComparison = true;

            if (a.x != b.x) {
                passedComparison = false;
            }

            if (a.y != b.y) {
                passedComparison = false;
            }

            if (a.z != b.z) {
                passedComparison = false;
            }

            return passedComparison;
        }
        public static bool operator !=(SVector3 a, SVector3 b) {
            return !(a == b);
        }
    }
}
