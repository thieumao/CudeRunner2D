using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float jumpForce;

    Rigidbody2D m_rb;

    bool m_isGround;

    GameController m_gc;

    public AudioSource aus;

    public AudioClip jumpSoud;
    public AudioClip loseSound;

    void Start() {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
    }

    void Update() {
        bool isJumpKeyPressed = Input.GetKeyDown(KeyCode.Space);
        if (isJumpKeyPressed && m_isGround) {
            m_rb.AddForce(Vector2.up * jumpForce);
            m_isGround = false;

            if (aus && jumpSoud) {
                aus.PlayOneShot(jumpSoud);
            }
        }
    }

	private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            m_isGround = true;
        }
	}

	private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Obstacle")) {
            if (aus && loseSound && !m_gc.IsGameover()) {
                aus.PlayOneShot(loseSound);
            }

            m_gc.SetGameoverState(true);
        }
	}
}
