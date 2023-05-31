using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float radius = 5f;
    [SerializeField] private int maxEnemiesSpawn = 10;
    [SerializeField] private float spawnCooldown = 3f;

    private float m_nextSpawnTime;
    private float m_nextChangeAngleTime;
    private float m_angle;

    private void Start() {
        ResetAngle();
        SpawnEnemies();
    }

    private void Update() {
        m_nextSpawnTime -= Time.deltaTime;
        m_nextChangeAngleTime -= Time.deltaTime;
        if (m_nextSpawnTime <= 0) {
            SpawnEnemies();
        }
        if (m_nextChangeAngleTime <= 0) {
            ResetAngle();
        }
    }

    /// <summary>
    /// Instantiate an enemy in a random position around the player
    /// </summary>
    private void SpawnEnemy() {
        m_angle = m_angle * Mathf.Deg2Rad;
        float angleGap = 5 * Mathf.Deg2Rad;
        Vector3 center = transform.position;
        m_angle = Random.Range(m_angle - angleGap, m_angle + angleGap);
        Vector3 pos = new Vector3(Mathf.Cos(m_angle), Mathf.Sin(m_angle), 0) * radius;
        Instantiate(enemyPrefab, center + pos, Quaternion.identity);
    }

    private void ResetAngle() {
        m_angle = Random.Range(0f, 360f);
        m_nextChangeAngleTime = 10f;
    }

    private void SpawnEnemies() {
        for (int i = 0; i < maxEnemiesSpawn; i++) {
            SpawnEnemy();
        }
        m_nextSpawnTime = spawnCooldown;
    }

    private void OnDrawGizmosSelected() {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.forward, radius);
    }
}