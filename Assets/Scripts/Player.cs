using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float jumpForce;

    Rigidbody2D m_rb;

    bool m_isGround;

    void Start() {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        bool isJumpKeyPressed = Input.GetKeyDown(KeyCode.Space);
        if (isJumpKeyPressed && m_isGround) {
            m_rb.AddForce(Vector2.up * jumpForce);
            m_isGround = false;
        }
    }

	private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            m_isGround = true;
        }
	}
}
