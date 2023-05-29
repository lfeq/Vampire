using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBookDefense : PlayerBaseAttack {
    [SerializeField] private GameObject bookPrefab;
    [SerializeField] private List<Transform> books = new List<Transform>();
    [SerializeField] private float spawnBookCooldown;
    [SerializeField] private float spawnPositionOffset = 1.5f;
    [SerializeField] private Vector3 rotationDirection;
    [SerializeField] private float angle = 1f;

    private int maxBooks = 1;
    private float nextSpawnTime;
    private Formulas formulas;

    private void Start() {
        formulas = new Formulas();
        SpawnBook();
    }

    private void Update() {
        Cooldown();
        RotateBooks();
    }

    private void RotateBooks() {
        foreach (Transform book in books) {
            print("Hola");
            book.position = formulas.Quaternion(rotationDirection, angle, book.position, transform.position);
        }
    }

    private void Cooldown() {
        nextSpawnTime -= Time.deltaTime;
        if (nextSpawnTime <= 0) {
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
        nextSpawnTime = spawnBookCooldown;
    }
}
