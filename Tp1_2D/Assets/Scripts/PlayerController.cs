using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 position;

    private float speed = 3;

    [SerializeField] private SpriteRenderer spriteRenderer;


    [SerializeField] private Animator animatorRef;
    private int direction;
    bool isRunning = false;

    private void Update()
    {
        CheckInput();
        MovePlayer();
    }

    private void CheckInput()
    {

        bool hasChange = false;
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

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
            hasChange = true;
            speed = 6;
        }
        else
        {
            isRunning = false;
            hasChange = true;
            speed = 3;
        }

        if (hasChange)
        {
            animatorRef.SetInteger("direction", direction);
            animatorRef.SetBool("isRunning", isRunning);

        }
    }

    private void MovePlayer()
    {

    }

    private void PlayEvent()
    {

    }



}
