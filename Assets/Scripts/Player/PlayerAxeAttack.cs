using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAxeAttack : MonoBehaviour {
    [SerializeField] private GameObject m_axe;
    private float m_nextSpawnTime;
    private float m_spawnAxeCooldown = 2f;

    private void Start() {
        spawnAxe();
    }
    
    private void Update() {
        cooldown();
    }

    public void setAxePrefab(GameObject t_axe) {
        m_axe = t_axe;
    }
    
    private void cooldown() {
        m_nextSpawnTime -= Time.deltaTime;
        if (m_nextSpawnTime <= 0) {
            spawnAxe();
            m_nextSpawnTime = m_spawnAxeCooldown;
        }
    }
    
    private void spawnAxe() {
        Instantiate(m_axe, transform.position, quaternion.identity);
    }
}
