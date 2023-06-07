using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float radius = 5f;
    [SerializeField] private int maxEnemiesSpawn = 10;
    [SerializeField] private float spawnCooldown = 5f;
    [SerializeField] private FloatReference maxEnemiesMultipliyer;
    [SerializeField] private PlayerController playerController;

    private float m_nextSpawnTime;
    private float m_nextChangeAngleTime;
    private float m_angle;
    private const float ANGLE_DELTA = 5;

    private void Start() {
        resetAngle();
        m_nextSpawnTime = spawnCooldown;
    }

    private void Update() {
        m_nextSpawnTime -= Time.deltaTime;
        m_nextChangeAngleTime -= Time.deltaTime;
        if (m_nextSpawnTime <= 0) {
            StartCoroutine(spawnEnemies());
        }

        if (m_nextChangeAngleTime <= 0) {
            resetAngle();
        }
    }

    /// <summary>
    /// Instantiate an enemy in a random position around the player
    /// </summary>
    private void spawnEnemy() {
        float maxAngle = m_angle + ANGLE_DELTA;
        float minAngle = m_angle - ANGLE_DELTA;
        Vector3 center = transform.position;
        m_angle = Random.Range(minAngle, maxAngle);
        float angleInRadian = m_angle * Mathf.Deg2Rad;
        Vector3 pos = new Vector3(Mathf.Cos(angleInRadian), Mathf.Sin(angleInRadian), 0) * radius;
        Instantiate(enemyPrefab, center + pos, Quaternion.identity);
    }

    private void resetAngle() {
        switch (playerController.playerDirection) {
            case PlayerDirection.East:
                m_angle = Random.Range(0 - ANGLE_DELTA, 0 + ANGLE_DELTA);
                break;
            case PlayerDirection.West:
                m_angle = Random.Range(180 - ANGLE_DELTA, 180 + ANGLE_DELTA);
                break;
            case PlayerDirection.North:
                m_angle = Random.Range(90 - ANGLE_DELTA, 90 + ANGLE_DELTA);
                break;
            case PlayerDirection.South:
                m_angle = Random.Range(270 - ANGLE_DELTA, 270 + ANGLE_DELTA);
                break;
        }
        m_nextChangeAngleTime = 10f;
    }

    private IEnumerator spawnEnemies() {
        m_nextSpawnTime = spawnCooldown;
        for (int i = 0; i < maxEnemiesSpawn; i++) {
            spawnEnemy();
            yield return new WaitForSeconds(0.6f);
        }
    }

    public void setNewMaxEnemiesAmount() {
        maxEnemiesSpawn *= (int)maxEnemiesMultipliyer.value;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}