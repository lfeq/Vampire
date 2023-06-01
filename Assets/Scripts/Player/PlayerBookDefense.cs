using System.Collections.Generic;
using UnityEngine;

public class PlayerBookDefense : PlayerBaseAttack {
    [SerializeField] private GameObject bookPrefab;
    [SerializeField] private List<Transform> books = new List<Transform>();
    [SerializeField] private float spawnBookCooldown;
    [SerializeField] private float spawnPositionOffset = 1.5f;
    [SerializeField] private Vector3 rotationDirection;
    [SerializeField] private float angle = 1f;
    [SerializeField] private int maxBooks = 1;

    private float m_nextSpawnTime;
    private Formulas m_formulas;

    private void Start() {
        m_formulas = new Formulas();
        SpawnBook();
    }

    private void Update() {
        Cooldown();
        RotateBooks();
    }

    private void RotateBooks() {
        foreach (Transform book in books) {
            book.position = m_formulas.quaternion(rotationDirection, angle, book.position, transform.position);
        }
    }

    private void Cooldown() {
        m_nextSpawnTime -= Time.deltaTime;
        if (m_nextSpawnTime <= 0) {
            SpawnBook();
        }
    }

    private void SpawnBook() {
        if (maxBooks <= books.Count) {
            return;
        }
        Vector2 spawnPosition = new Vector2(transform.position.x + spawnPositionOffset, transform.position.y);
        GameObject tempBook = Instantiate(bookPrefab, spawnPosition, Quaternion.identity);
        tempBook.transform.parent = transform;
        books.Add(tempBook.transform);
        m_nextSpawnTime = spawnBookCooldown;

        float separation = 360 / books.Count;
        separation *= Mathf.Deg2Rad;
        Vector2 previousPosition = books[0].position;
        for (int i = 1; i < books.Count; i++) {
            Transform book = books[i];
            book.position = m_formulas.rotate(previousPosition, separation);
            previousPosition = book.position;
        }
    }
}