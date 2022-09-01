using System;

public static class MathUtils
{
    public static float PointsDistance(Vector3 point1, Vector3 point2) {
        float distance = MathF.Sqrt(MathF.Pow(point2.x - point1.x, 2) + MathF.Pow(point2.y - point1.y, 2));
        return distance;
    }

    public struct Vector3
    {
        public float x;
        public float y;
        public float z;

        public static Vector3 operator +(Vector3 a, Vector3 b) {
            Vector3 finalVector = new Vector3();
            finalVector.x = a.x + b.x;
            finalVector.y = a.y + b.y;
            finalVector.z = a.z + b.z;

            return finalVector;
        }

        public static Vector3 operator -(Vector3 a) {
            Vector3 finalVector = new Vector3();
            finalVector.x = a.x * -1;
            finalVector.y = a.y * -1;
            finalVector.z = a.z * -1;

            return finalVector;
        }

        public static Vector3 operator -(Vector3 a, Vector3 b) {
            Vector3 finalVector = new Vector3();
            finalVector.x = a.x - b.x;
            finalVector.y = a.y - b.y;
            finalVector.z = a.z - b.z;

            return finalVector;
        }

        public static Vector3 operator *(float d, Vector3 a) {
            Vector3 finalVector = new Vector3();
            finalVector.x = a.x * d;
            finalVector.y = a.y * d;
            finalVector.z = a.z * d;

            return finalVector;
        }
        public static Vector3 operator *(Vector3 a, float d) {
            Vector3 finalVector = new Vector3();
            finalVector.x = a.x * d;
            finalVector.y = a.y * d;
            finalVector.z = a.z * d;

            return finalVector;
        }
        public static Vector3 operator /(Vector3 a, float d) {
            Vector3 finalVector = new Vector3();
            finalVector.x = a.x / d;
            finalVector.y = a.y / d;
            finalVector.z = a.z / d;

            return finalVector;
        }
        public static bool operator ==(Vector3 a, Vector3 b) {
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
        public static bool operator !=(Vector3 a, Vector3 b) {
            return !(a == b);
        }
    }
}
