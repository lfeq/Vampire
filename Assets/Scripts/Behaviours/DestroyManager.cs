using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyManager : MonoBehaviour
{
    public UnityEvent onDestroy;
    [SerializeField] private GameObject prefab;

    private void OnDestroy() {
        onDestroy.Invoke();
    }

    public void SpawnObject() {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }

    public void autoDestroy() {
        Destroy(gameObject);
    }
}
