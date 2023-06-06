using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/BookBuff")]
public class BookBuff : PowerUpEffects {
    public float damageMultiplier = 1.5f;
    
    [SerializeField] private GameObject book;
    
    public override void apply(GameObject t_target) {
        PlayerBookDefense tempPlayerBookDefense = t_target.GetComponent<PlayerBookDefense>();
        if (tempPlayerBookDefense == null) {
            tempPlayerBookDefense = t_target.AddComponent<PlayerBookDefense>();
            tempPlayerBookDefense.setBookPrefab(book);
        }
        tempPlayerBookDefense.damage *= damageMultiplier;
        currentLevel++;
    }
}
