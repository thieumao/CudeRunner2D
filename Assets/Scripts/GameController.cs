using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public GameObject obstacle;

    public float spawnTime;

    float m_spawnTime;

    int m_score;

    bool m_isGameover;

    UIManager m_ui;

    void Start() {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.SetScoreText("Score: " + m_score);
    }

    void Update() {
        if (m_isGameover) {
            m_spawnTime = 0;
            m_ui.ShowGameoverPanel(true);
            return;
        }

        m_spawnTime -= Time.deltaTime;

        if (m_spawnTime <= 0) {
            SpawnObstacle();
			m_spawnTime = spawnTime;
		}
    }

    public void SpawnObstacle() {
        float ranYPos = Random.Range(-4.0f, -2.0f);

        Vector2 spawnPos = new Vector2(11, ranYPos);

        if (obstacle) {
            Instantiate(obstacle, spawnPos, Quaternion.identity);
        }
    }

    public void Replay() {
        SceneManager.LoadScene("GamePlay");
    }

    public void SetScore(int value) {
        m_score = value;
    }

    public int GetScore() {
        return m_score;
    }

    public void ScoreIncrement() {
        if (m_isGameover) {
            return;
        }
        m_score++;
        m_ui.SetScoreText("Score: " + m_score);
    }

    public bool IsGameover() {
        return m_isGameover;
    }

    public void SetGameoverState(bool state) {
        m_isGameover = state;
    }
}
