using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed;
    GameController m_gc;

    
    // Start is called before the first frame update
    void Start()
    {
       m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_gc.SetGameOverState(true);
            /*Destroy(gameObject);*/
            Debug.Log("Va cham voi player");
        }else if (collision.gameObject.CompareTag("DestroyGameObj"))
        {
            Destroy(gameObject);
            if (!m_gc.GetGameOverState())
                m_gc.IncrementScore();
            Debug.Log("Va cham voi tuong");
        }
    }

}
