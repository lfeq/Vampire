using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    public static MusicManager s_instance;
    
    private void Awake() {
        if (s_instance != null && s_instance != this) {
            Destroy(gameObject);
        }
        s_instance = this;
        DontDestroyOnLoad(gameObject);
    }
}