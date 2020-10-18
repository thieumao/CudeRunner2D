using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    public float moveSpeed;

    GameController m_gc;

    void Start() {
        m_gc = FindObjectOfType<GameController>();
    }

    void Update() {
        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;
    }

	private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("SceneLimit")) {
            m_gc.ScoreIncrement();
            Debug.Log("+1 Score");
            Destroy(gameObject);
            Debug.Log("Da ra ngoai khung");
        }
	}
}
