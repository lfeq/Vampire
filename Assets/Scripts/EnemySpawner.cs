using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float radius = 5f;

    /// <summary>
    /// Instantiate an enemy in a random position around the player
    /// </summary>
    private void SpawnEnemy()
    {
        Vector3 center = transform.position;
        float angle = Random.Range(0f, 360f);
        Vector3 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
        Instantiate(enemyPrefab, center + pos, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.forward, radius);
    }
}
