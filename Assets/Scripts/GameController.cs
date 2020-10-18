using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject obstacle;

    public float spawnTime;

    float m_spawnTime;

    int m_score;

    bool m_isGameover;

    void Start() {
        m_spawnTime = 0;
    }

    void Update() {
        if (m_isGameover) {
            m_spawnTime = 0;
            return;
        }

        m_spawnTime -= Time.deltaTime;

        if (m_spawnTime <= 0) {
            SpawnObstacle();
			m_spawnTime = spawnTime;
		}
    }

    public void SpawnObstacle() {
        float ranYPos = Random.Range(-2.75f, -1f);

        Vector2 spawnPos = new Vector2(11, ranYPos);

        if (obstacle) {
            Instantiate(obstacle, spawnPos, Quaternion.identity);
        }
    }

    public void SetScore(int value) {
        m_score = value;
    }

    public int GetScore() {
        return m_score;
    }

    public void ScoreIncrement() {
        m_score++;
    }

    public bool IsGameover() {
        return m_isGameover;
    }

    public void SetGameoverState(bool state) {
        m_isGameover = state;
    }
}
