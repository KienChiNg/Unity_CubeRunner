using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;
    public AudioSource aus;
    public AudioClip jumpSound;
    public AudioClip loseSound;

    GameController m_gc;
    Rigidbody2D m_rb;

    bool m_isGround;
    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_gc.GetGameOverState())
        {
            return;
        }
        bool iSJumpKeyPressed = Input.GetKeyDown(KeyCode.Space);
        if (iSJumpKeyPressed && m_isGround)
        {
            //Vector2.up = (0, 1)
            //(0, 1) * 5 = (0, 5)
            m_rb.AddForce(Vector2.up * jumpForce);
            m_isGround = false;
            if(aus && jumpSound)
            {
                aus.PlayOneShot(jumpSound);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_isGround = true;
        }
    }
}
