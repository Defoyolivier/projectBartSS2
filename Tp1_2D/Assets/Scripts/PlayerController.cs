using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 m_Velocity;

    private float speed = 3;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D PlayerRb;
    [SerializeField] private Dialogue dialogueRef;
    [SerializeField] private Animator animatorRef;
    [SerializeField] private AudioSource kirbySong;
    [SerializeField] private AudioSource BackStreetSong;
    [SerializeField] private AudioSource Encounter;
    private int direction;
    bool isRunning = false;
    bool hasChange = false;


    private void Update()
    {
        if (!dialogueRef.triggered)
        {
            CheckInput();
        }
        else
        {
            direction = 0;
            isRunning = false;
            animatorRef.SetInteger("direction", direction);
            animatorRef.SetBool("isRunning", isRunning);
            kirbySong.Stop();
            BackStreetSong.Stop();
            Encounter.Play();

        }
    }

    private void CheckInput()
    {

        hasChange = false;
        m_Velocity = PlayerRb.velocity;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (direction != -1)
            {
                direction = -1;
                hasChange = true;
                spriteRenderer.flipX = true;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (direction != 1)
            {
                direction = 1;
                hasChange = true;
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            direction = 0;
            hasChange = true;
        }
        m_Velocity.x = direction * speed;
        PlayerRb.velocity = m_Velocity;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
            hasChange = true;
            speed = 4;
            kirbySong.Play();
        }
        else
        {
            isRunning = false;
            hasChange = true;
            speed = 2;
            BackStreetSong.Play();
        }

        if (hasChange)
        {
            animatorRef.SetInteger("direction", direction);
            animatorRef.SetBool("isRunning", isRunning);

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogueRef.triggered = true;
    }



}
