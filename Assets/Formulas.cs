using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Formulas {
    public float magnitud(Vector3 t_v3) {
        float x = t_v3.x * t_v3.x;
        float y = t_v3.y * t_v3.y;
        float z = t_v3.z * t_v3.z;
        float sum = x + y + z;
        float resultado = Mathf.Sqrt(sum);

        return resultado;
    }

    public Vector3 normalizar(Vector3 t_v3) {
        return t_v3 / magnitud(t_v3);
    }

    public float pow(float t_x) {
        return t_x * t_x;
    }

    /// <summary>
    /// Rotate object x degrees
    /// </summary>
    /// <param name="t_previousPosition"></param>
    /// <param name="Degrees to be rotated in radians"></param>
    /// <returns>new position</returns>
    public Vector3 rotate(Vector3 t_previousPosition, float t_addAngle) {
        //x’ = x cos(θ) - y sin(θ)
        //y’ = x sin(θ) + y cos(θ)
        //Donde X y Y son la posicion original.
        float xPos = (t_previousPosition.x * Mathf.Cos(t_addAngle)) - (t_previousPosition.y * Mathf.Sin(t_addAngle));
        float yPos = (t_previousPosition.x * Mathf.Sin(t_addAngle)) + (t_previousPosition.y * Mathf.Cos(t_addAngle));
        return new Vector3(xPos, yPos, 0);
    }

    public Vector3 quaternion(Vector4 t_q, Vector3 t_pos) {
        float angle = t_q.w * Mathf.Deg2Rad;
        float w = Mathf.Cos(angle / 2);
        Vector3 v = new Vector3(t_q.x, t_q.y, t_q.z);
        Vector3 vNormal = normalizar(v);

        v.x = vNormal.x * Mathf.Sin(angle / 2);
        v.y = vNormal.y * Mathf.Sin(angle / 2);
        v.z = vNormal.z * Mathf.Sin(angle / 2);

        Matrix4x4 matrix = Matrix4x4.identity;

        matrix.m00 = 1 - 2 * pow(v.y) - 2 * pow(v.z);
        matrix.m01 = 2 * v.x * v.y - 2 * w * v.z;
        matrix.m02 = 2 * v.x * v.z + 2 * w * v.y;

        matrix.m10 = 2 * v.x * v.y + 2 * w * v.z;
        matrix.m11 = 1 - 2 * pow(v.x) - 2 * pow(v.z);
        matrix.m12 = 2 * v.y * v.z - 2 * w * v.x;

        matrix.m20 = 2 * v.x * v.z - 2 * w * v.y;
        matrix.m21 = 2 * v.y * v.z + 2 * w * v.x;
        matrix.m22 = 1 - 2 * pow(v.x) - 2 * pow(v.y);

        Vector3 resultado = matrix.MultiplyPoint(t_pos);

        return resultado;
    }

    /// <summary>
    /// Calculates the rotation of a point around a center.
    /// <example>
    /// <code>
    /// <para/>Rotates in x axis 45 degrees.
    /// <para/>transform.position = formulas.Quaternion(new Vector3(1, 0, 0), 45, transform.position, center.position);
    /// <para/>MethodExample(a);
    /// </code>
    /// </example>
    /// </summary>
    /// <returns>The new position of the rotated object</returns>
    public Vector3 quaternion(Vector3 t_q, float t_angle, Vector3 t_pos, Vector3 t_centro) {
        Vector3 posicionActualTemp = t_pos;
        Vector3 centroTemp = t_centro;
        Vector3 distancia = posicionActualTemp - centroTemp;

        //Mover al centro
        centroTemp = Vector3.zero;
        posicionActualTemp = Vector3.zero + distancia;

        //Hacer calculos de cuaternion
        float angleInRad = t_angle * Mathf.Deg2Rad;

        float w = Mathf.Cos(angleInRad / 2);

        Vector3 v = new Vector3(t_q.x, t_q.y, t_q.z);

        Vector3 vNormal = normalizar(v);

        v.x = vNormal.x * Mathf.Sin(angleInRad / 2);
        v.y = vNormal.y * Mathf.Sin(angleInRad / 2);
        v.z = vNormal.z * Mathf.Sin(angleInRad / 2);

        Matrix4x4 matrix = Matrix4x4.identity;

        matrix.m00 = 1 - 2 * pow(v.y) - 2 * pow(v.z);
        matrix.m01 = 2 * v.x * v.y - 2 * w * v.z;
        matrix.m02 = 2 * v.x * v.z + 2 * w * v.y;

        matrix.m10 = 2 * v.x * v.y + 2 * w * v.z;
        matrix.m11 = 1 - 2 * pow(v.x) - 2 * pow(v.z);
        matrix.m12 = 2 * v.y * v.z - 2 * w * v.x;

        matrix.m20 = 2 * v.x * v.z - 2 * w * v.y;
        matrix.m21 = 2 * v.y * v.z + 2 * w * v.x;
        matrix.m22 = 1 - 2 * pow(v.x) - 2 * pow(v.y);

        //Calcular cuanto se movio
        Vector3 resultado = matrix.MultiplyPoint(posicionActualTemp);
        Vector3 movimineto = resultado - posicionActualTemp;

        //Agregar movimiento a la posicion original
        return t_pos + movimineto;
    }

    public Vector3 move(Vector3 t_pos, Vector3 t_moveVector) {
        Matrix4x4 matrix = Matrix4x4.identity;

        matrix.m03 = t_moveVector.x;
        matrix.m13 = t_moveVector.y;
        matrix.m23 = t_moveVector.z;

        Vector3 resultado = matrix.MultiplyPoint(t_pos);

        return resultado;
    }

    public float distance(Vector3 t_pos1, Vector3 t_pos2) {
        float x = t_pos2.x - t_pos1.x;
        float y = t_pos2.y - t_pos1.y;
        float z = t_pos2.z - t_pos1.z;
        float result = pow(x) + pow(y) + pow(z);

        return result;
    }

    public Vector3 direction(Vector3 t_pos1, Vector3 t_pos2) {
        Vector3 direction = t_pos2 - t_pos1;
        return direction;
    }

    public float hooke(float t_distance, float t_k) {
        float force = t_distance * t_k * -1;
        return force;
    }

    public float aceleration(float t_force, float t_mass) {
        return t_force / t_mass;
    }
    
    /// <summary>
    /// vo = velocidad inicial
    /// t = tiempo
    /// g = gravedad
    /// x = vox * t
    /// y = voy * t - 0.5 * g * t^2
    /// </summary>
    /// <param name="t_time"></param>
    /// <param name="t_horizontalInitialVelocity"></param>
    /// <param name="t_verticalInitialVelocity"></param>
    /// <returns></returns>
    public Vector3 tiroParabolico(float t_time, float t_horizontalInitialVelocity, float t_verticalInitialVelocity, Vector2 t_currentPos) {
        const float gravity = 9.81f;
        float x = (t_horizontalInitialVelocity * t_time) * Time.deltaTime;
        float y = (t_verticalInitialVelocity * t_time - 0.5f * gravity * t_time * t_time) * Time.deltaTime;
        return new Vector2(x, y) + t_currentPos;
    }
}
