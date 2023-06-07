using UnityEngine;

public class BookBehaviour : MonoBehaviour {
    private int m_maxHits = 3;
    private int m_damage;
    private PlayerBookDefense m_bookDefense;

    private void OnTriggerEnter2D(Collider2D t_collision) {
        if (!t_collision.CompareTag("Enemy")) return;
        t_collision.GetComponent<TakeDamage>()?.takeDamage(m_damage);
        m_maxHits--;
        if (m_maxHits == 0) {
            Destroy(gameObject);
            m_bookDefense.removeBook(transform);
        }
    }

    public void setDamage(int t_damage) {
        m_damage = t_damage;
    }

    public void setBookDefense(PlayerBookDefense t_bookDefense) {
        m_bookDefense = t_bookDefense;
    }
}