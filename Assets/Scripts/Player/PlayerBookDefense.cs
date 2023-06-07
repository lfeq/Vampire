using System.Collections.Generic;
using UnityEngine;

public class PlayerBookDefense : PlayerBaseAttack {
    public float damage = 20;
    
    private List<Transform> m_books = new List<Transform>();
    private float m_spawnBookCooldown = 2f;
    private int m_maxBooks = 1;
    private const float SPAWN_POSITION_OFFSET = 2f;
    private readonly Vector3 m_rotationDirection = new Vector3(0, 0, 1);
    private const float ANGLE = 0.5f;
    private float m_nextSpawnTime;
    private Formulas m_formulas;
    private GameObject m_bookPrefab;


    private void Start() {
        m_formulas = new Formulas();
        spawnBook();
    }

    private void Update() {
        cooldown();
        rotateBooks();
    }

    private void rotateBooks() {
        foreach (Transform book in m_books) {
            book.position = m_formulas.quaternion(m_rotationDirection, ANGLE, book.position, transform.position);
        }
    }

    private void cooldown() {
        m_nextSpawnTime -= Time.deltaTime;
        if (m_nextSpawnTime <= 0) {
            spawnBook();
            m_nextSpawnTime = m_spawnBookCooldown;
        }
    }

    private void spawnBook() {
        if (m_maxBooks <= m_books.Count) {
            return;
        }

        Vector2 spawnPosition = new Vector2(transform.position.x + SPAWN_POSITION_OFFSET, transform.position.y);
        GameObject tempBook = Instantiate(m_bookPrefab, spawnPosition, Quaternion.identity);
        tempBook.GetComponent<BookBehaviour>().setDamage((int)damage);
        tempBook.GetComponent<BookBehaviour>().setBookDefense(this);
        tempBook.transform.parent = transform;
        m_books.Add(tempBook.transform);

        float separation = 360 / m_books.Count;
        separation *= Mathf.Deg2Rad;
        Vector2 previousPosition = m_books[0].position;
        for (int i = 1; i < m_books.Count; i++) {
            Transform book = m_books[i];
            book.position = m_formulas.rotate(previousPosition, separation);
            previousPosition = book.position;
        }
    }

    public void setBookPrefab(GameObject t_gameObject) {
        m_bookPrefab = t_gameObject;
    }

    public void removeBook(Transform t_book)
    {
        m_books.Remove(t_book);
    }
}