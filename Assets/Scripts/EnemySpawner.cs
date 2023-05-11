using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float radius = 5f;

    private float angle;

    private void Start()
    {
        angle = Random.Range(0f, 360f);

        for (int i = 0; i < 10; i++)
            SpawnEnemy();
    }

    /// <summary>
    /// Instantiate an enemy in a random position around the player
    /// </summary>
    private void SpawnEnemy()
    {
        angle = angle * Mathf.Deg2Rad;
        float angleGap = 5 * Mathf.Deg2Rad;
        Vector3 center = transform.position;
        angle = Random.Range(angle - angleGap, angle + angleGap);
        Vector3 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
        Instantiate(enemyPrefab, center + pos, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.forward, radius);
    }
}
