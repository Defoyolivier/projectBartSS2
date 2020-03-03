using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : Character
{
    [SerializeField] private Sythe m_Syth;
    [SerializeField] private Taupe taupitaupe;
    [SerializeField] private Rigidbody m_PlayerRb;
    public GameObject PlayerGO;
    public Animator animatorRef;
    private Vector3 m_Velocity;
    private float m_MoveSpeed = 4;
    private float m_JumpHeight = 300f;
    private bool m_CanJump = true;
    public bool m_OnGround = false;
    private float attackCD = 2;
    public float knockUpForce = 300f;

    void Update()
    {
        if (m_CanJump && Input.GetKeyDown(KeyCode.Space))
        {
            Jump(m_JumpHeight);
        }
        PlayerMove();
        Attack();

    }

    void PlayerMove()
    {
        m_Velocity.x = 0;
        m_Velocity.y = 0;
        m_Velocity.z = 0;
        m_MoveSpeed = 4;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            m_Velocity += -transform.right;
        }

        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            m_Velocity += transform.right;
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            m_Velocity += transform.forward;
        }

        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            m_Velocity += -transform.forward;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_MoveSpeed = 10f;
        }

        m_Velocity.Normalize();
        m_Velocity *= m_MoveSpeed;
        m_Velocity.y = m_PlayerRb.velocity.y;
        m_PlayerRb.velocity = m_Velocity;
    }

    public void Jump(float i_JumpHauteur)
    {
         Vector3 monjump = new Vector3(0, m_JumpHeight, 0);
         m_PlayerRb.AddForce(monjump);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Dirt")
        {
            m_OnGround = true;
        }
        else if(collision.gameObject.tag != "Dirt")
        {
            m_OnGround = false;
        }
    }

    private void Attack()
    {
        if (Input.GetKey(KeyCode.Mouse0) && attackCD >= 2)
        {
            Debug.Log("Attack");
            animatorRef.SetBool("Swing", true);
            attackCD = 0;
        }
        else
        {
            attackCD += Time.deltaTime;
        }
    }

    public void KnockUp()
    {
        if (taupitaupe.m_canKnockup)
        {
            Vector3 knockup = new Vector3(0, 150f, 0);
            m_PlayerRb.AddForce(knockup);
            taupitaupe.m_canKnockup = false;
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        
    }

    

}