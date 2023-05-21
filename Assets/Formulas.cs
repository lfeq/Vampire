using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Formulas {
    public float Magnitud(Vector3 v3) {
        float x = v3.x * v3.x;
        float y = v3.y * v3.y;
        float z = v3.z * v3.z;
        float sum = x + y + z;
        float resultado = Mathf.Sqrt(sum);

        return resultado;
    }

    public Vector3 Normalizar(Vector3 v3) {
        return v3 / Magnitud(v3);
    }

    public float Pow(float x) {
        return x * x;
    }

    public Vector3 Quaternion(Vector4 q, Vector3 pos) {
        float angle = q.w * Mathf.Deg2Rad;
        float w = Mathf.Cos(angle / 2);
        Vector3 v = new Vector3(q.x, q.y, q.z);
        Vector3 v_Normal = Normalizar(v);

        v.x = v_Normal.x * Mathf.Sin(angle / 2);
        v.y = v_Normal.y * Mathf.Sin(angle / 2);
        v.z = v_Normal.z * Mathf.Sin(angle / 2);

        Matrix4x4 matrix = Matrix4x4.identity;

        matrix.m00 = 1 - 2 * Pow(v.y) - 2 * Pow(v.z);
        matrix.m01 = 2 * v.x * v.y - 2 * w * v.z;
        matrix.m02 = 2 * v.x * v.z + 2 * w * v.y;

        matrix.m10 = 2 * v.x * v.y + 2 * w * v.z;
        matrix.m11 = 1 - 2 * Pow(v.x) - 2 * Pow(v.z);
        matrix.m12 = 2 * v.y * v.z - 2 * w * v.x;

        matrix.m20 = 2 * v.x * v.z - 2 * w * v.y;
        matrix.m21 = 2 * v.y * v.z + 2 * w * v.x;
        matrix.m22 = 1 - 2 * Pow(v.x) - 2 * Pow(v.y);

        Vector3 resultado = matrix.MultiplyPoint(pos);

        return resultado;
    }

    /// <summary>
    /// Calculates the rotation of a point around a center.
    /// <example>
    /// <code>
    /// <para/>// Rotates in x axis 45 degrees.
    /// <para/>transform.position = formulas.Quaternion(new Vector3(1, 0, 0), 45, transform.position, center.position);
    /// <para/>MethodExample(a);
    /// </code>
    /// </example>
    /// </summary>
    /// <returns>The new position of the rotated object</returns>
    public Vector3 Quaternion(Vector3 q, float angle, Vector3 pos, Vector3 centro) {
        Vector3 posicionActualTemp = pos;
        Vector3 centroTemp = centro;
        Vector3 distancia = posicionActualTemp - centroTemp;

        //Mover al centro
        centroTemp = Vector3.zero;
        posicionActualTemp = Vector3.zero + distancia;

        //Hacer calculos de cuaternion
        float angleInRad = angle * Mathf.Deg2Rad;

        float w = Mathf.Cos(angleInRad / 2);

        Vector3 v = new Vector3(q.x, q.y, q.z);

        Vector3 v_normal = Normalizar(v);

        v.x = v_normal.x * Mathf.Sin(angleInRad / 2);
        v.y = v_normal.y * Mathf.Sin(angleInRad / 2);
        v.z = v_normal.z * Mathf.Sin(angleInRad / 2);

        Matrix4x4 matrix = Matrix4x4.identity;

        matrix.m00 = 1 - 2 * Pow(v.y) - 2 * Pow(v.z);
        matrix.m01 = 2 * v.x * v.y - 2 * w * v.z;
        matrix.m02 = 2 * v.x * v.z + 2 * w * v.y;

        matrix.m10 = 2 * v.x * v.y + 2 * w * v.z;
        matrix.m11 = 1 - 2 * Pow(v.x) - 2 * Pow(v.z);
        matrix.m12 = 2 * v.y * v.z - 2 * w * v.x;

        matrix.m20 = 2 * v.x * v.z - 2 * w * v.y;
        matrix.m21 = 2 * v.y * v.z + 2 * w * v.x;
        matrix.m22 = 1 - 2 * Pow(v.x) - 2 * Pow(v.y);

        //Calcular cuanto se movio
        Vector3 resultado = matrix.MultiplyPoint(posicionActualTemp);
        Vector3 movimineto = resultado - posicionActualTemp;

        //Agregar movimiento a la posicion original
        return pos + movimineto;
    }

    public Vector3 Move(Vector3 pos, Vector3 moveVector) {
        Matrix4x4 matrix = Matrix4x4.identity;

        matrix.m03 = moveVector.x;
        matrix.m13 = moveVector.y;
        matrix.m23 = moveVector.z;

        Vector3 resultado = matrix.MultiplyPoint(pos);

        return resultado;
    }

    public float Distance(Vector3 pos1, Vector3 pos2) {
        float x = pos2.x - pos1.x;
        float y = pos2.y - pos1.y;
        float z = pos2.z - pos1.z;
        float result = Pow(x) + Pow(y) + Pow(z);

        return result;
    }

    public Vector3 Direction(Vector3 pos1, Vector3 pos2) {
        Vector3 direction = pos2 - pos1;
        return direction;
    }

    public float Hooke(float distance, float k) {
        float force = distance * k * -1;
        return force;
    }

    public float Aceleration(float force, float mass) {
        return force / mass;
    }
}
