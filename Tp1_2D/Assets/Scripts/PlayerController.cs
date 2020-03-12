using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 velocity;

    private static float Speed = 3;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Dialogue dialogueRef;
    [SerializeField] private Animator animatorRef;
    [SerializeField] private AudioSource kirbySong;
    [SerializeField] private AudioSource BackStreetSong;
    [SerializeField] private AudioSource Encounter;
    private int direction;
    private bool isRunning = false;
    private bool hasChange = false;


    private void Update(){
        CheckTrigger();
    }

    private void CheckTrigger(){
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

        }
    }

    private void CheckInput(){

        hasChange = false;
        velocity = playerRb.velocity;
        if (Input.GetKey(KeyCode.LeftArrow)){
            if (direction != -1){
                direction = -1;
                hasChange = true;
                spriteRenderer.flipX = true;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow)){
            if (direction != 1){
                direction = 1;
                hasChange = true;
                spriteRenderer.flipX = false;
            }
        }
        else{
            direction = 0;
            hasChange = true;
        }
        velocity.x = direction * Speed;
        playerRb.velocity = velocity;

        if (Input.GetKey(KeyCode.LeftShift)){
            isRunning = true;
            hasChange = true;
            Speed = 4;
            kirbySong.Play();
        }
        else{
            isRunning = false;
            hasChange = true;
            Speed = 2;
            BackStreetSong.Play();
        }

        if (hasChange){
            animatorRef.SetInteger("direction", direction);
            animatorRef.SetBool("isRunning", isRunning);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision){
        dialogueRef.triggered = true;
    }



}
