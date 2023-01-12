using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float spawnObstacle;
    public GameObject obstacle;
    UIManager m_ui;
    float m_spawnObstacle;
    bool isGameOver;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        m_ui = FindObjectOfType<UIManager>();
        score = 0;
        m_ui.setScore("Score: " + score);
        m_spawnObstacle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            m_ui.showGameOverPanel(true);
            Debug.Log("Game Over");
            return;
        }
        m_spawnObstacle -= Time.deltaTime;
        if (m_spawnObstacle <= 0)
        {
            SpawnObs();
            m_spawnObstacle = spawnObstacle;
        }
    }

    public void Replay()
    {
        score = 0;
        isGameOver = false;
        m_ui.setScore("Score: " + score);
        m_ui.showGameOverPanel(false);
    }
    public void SpawnObs()
    {
        Vector2 m_spawnObs = new Vector2(11.5f, -2.1272f);
        if (obstacle)
        {
            Instantiate(obstacle, m_spawnObs, Quaternion.identity);
        }
    }

    public void SetGameOverState(bool state)
    {
        isGameOver = state;
    }

    public bool GetGameOverState()
    {
        return isGameOver;
    }

    public void IncrementScore()
    {
        score++;
        m_ui.setScore("Score: " + score);
        Debug.Log(score);
    }
}
