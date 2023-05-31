using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float radius = 5f;
    [SerializeField] private int maxEnemiesSpawn = 10;
    [SerializeField] private float spawnCooldown = 3f;
    [SerializeField] private FloatReference maxEnemiesMultipliyer;
    
    private float m_nextSpawnTime;
    private float m_nextChangeAngleTime;
    private float m_angle;
    private float m_angleDelta = 5;

    private void Start() {
        resetAngle();
        spawnEnemies();
    }

    private void Update() {
        m_nextSpawnTime -= Time.deltaTime;
        m_nextChangeAngleTime -= Time.deltaTime;
        if (m_nextSpawnTime <= 0) {
            spawnEnemies();
        }
        if (m_nextChangeAngleTime <= 0) {
            resetAngle();
        }
    }

    /// <summary>
    /// Instantiate an enemy in a random position around the player
    /// </summary>
    private void spawnEnemy() {
        float maxAngle = m_angle + m_angleDelta;
        float minAngle = m_angle - m_angleDelta;
        Vector3 center = transform.position;
        m_angle = Random.Range(minAngle, maxAngle);
        float angleInRadian = m_angle * Mathf.Deg2Rad;
        Vector3 pos = new Vector3(Mathf.Cos(angleInRadian), Mathf.Sin(angleInRadian), 0) * radius;
        Instantiate(enemyPrefab, center + pos, Quaternion.identity);
    }

    private void resetAngle() {
        m_angle = Random.Range(0f, 360f);
        m_nextChangeAngleTime = 10f;
    }

    private void spawnEnemies() {
        for (int i = 0; i < maxEnemiesSpawn; i++) {
            spawnEnemy();
        }
        m_nextSpawnTime = spawnCooldown;
    }

    public void setNewMaxEnemiesAmount() {
        maxEnemiesSpawn *= (int)maxEnemiesMultipliyer.value;
    }

    private void OnDrawGizmosSelected() {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.forward, radius);
    }
}