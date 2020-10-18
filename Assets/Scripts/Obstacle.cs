using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    public float moveSpeed;

    void Start() {
        
    }

    void Update() {
        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;
    }

	private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("SceneLimit")) {
            Destroy(gameObject);
            Debug.Log("Da ra ngoai khung");
        }
	}
}
