using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Formulas
{
    public float Magnitud(Vector3 v3)
    {
        float x = v3.x * v3.x;
        float y = v3.y * v3.y;
        float z = v3.z * v3.z;
        float sum = x + y + z;
        float resultado = Mathf.Sqrt(sum);

        return resultado;
    }

    public Vector3 Normalizar(Vector3 v3)
    {
        return v3 / Magnitud(v3);
    }

    public float Pow(float x)
    {
        return x * x;
    }

    public Vector3 Quaternion(Vector4 q, Vector3 pos)
    {
        float angle = q.w * Mathf.Deg2Rad;
        float w = Mathf.Cos(angle / 2);
        Vector3 v = new Vector3(q.x, q.y, q.z);
        Vector3 v_Normal = Normalizar(v);

        v.x = v_Normal.x * Mathf.Sin(angle/ 2);
        v.y = v_Normal.y * Mathf.Sin(angle/ 2);
        v.z = v_Normal.z * Mathf.Sin(angle/ 2);

        Matrix4x4 matrix = Matrix4x4.identity;

        matrix.m00 = 1 - 2 * Pow(v.y) - 2 * Pow(v.z);
        matrix.m01 = 2 * v.x * v.y - 2 * w * v.z;
        matrix.m02 = 2 * v.x * v.z + 2 * w *v.y;

        matrix.m10 = 2 * v.x * v.y + 2 * w * v.z;
        matrix.m11 = 1 - 2 * Pow(v.x) - 2 * Pow(v.z);
        matrix.m12 = 2 * v.y * v.z - 2 * w * v.x;

        matrix.m20 = 2 * v.x * v.z - 2 * w * v.y;
        matrix.m21 = 2 * v.y * v.z + 2 * w * v.x;
        matrix.m22 = 1 - 2 * Pow(v.x) - 2 * Pow(v.y);

        Vector3 resultado = matrix.MultiplyPoint(pos);

        return resultado;
    }

    public Vector3 Move(Vector3 pos,  Vector3 moveVector)
    {
        Matrix4x4 matrix = Matrix4x4.identity;

        matrix.m03 = moveVector.x;
        matrix.m13 = moveVector.y;
        matrix.m23 = moveVector.z;

        Vector3 resultado = matrix.MultiplyPoint(pos);

        return resultado;
    }

    public float Distance(Vector3 pos1, Vector3 pos2)
    {
        float x = pos2.x - pos1.x;
        float y = pos2.y - pos1.y;
        float z = pos2.z - pos1.z;
        float result = Pow(x) + Pow(y) + Pow(z);

        return result;
    }

    public float Hooke(float distance, float k)
    {
        float force = distance * k * -1;
        return force;
    }

    public float Aceleration(float force, float mass)
    {
        return force / mass;
    }
}
