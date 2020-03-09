using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerController : Character
{
    [SerializeField] private Taupe taupitaupe;
    [SerializeField] private Rigidbody m_PlayerRb;
    [SerializeField] private Transform ThirdCamView;
    [SerializeField] private ChestInteraction ChestInteraction;
    [SerializeField] private Animator animatorRef;

    public GameObject PlayerGO;
    private Vector3 pointA;
    private Vector3 pointB;
    private Vector3 m_Velocity;

    private float m_MoveSpeed = 4;
    private float m_JumpHeight = 300f;
    private float attackCD = 1;
    public float knockUpForce = 300f;
    private float timer = 1;
    

    private bool m_CanJump = true;
    public bool m_OnGround = false;
    private bool m_IsAttacking = false;
    public bool CanInteract = false;


    public void Awake()
    {
        m_Health = 8;
        m_Speed = 10;
        m_HaveInput = true;
        m_damage = 2;
    }

    void Update()
    {
        if (m_CanJump && Input.GetKeyDown(KeyCode.Space))
        {
            Jump(m_JumpHeight);
        }
        PlayerMove();
        Attack();
        Interaction();
    }

    void PlayerMove()
    {
        Vector3 NewCamPos = new Vector3(ThirdCamView.transform.position.x, transform.position.y, ThirdCamView.transform.position.z);
        transform.LookAt(NewCamPos);
        m_Velocity.x = 0;
        m_Velocity.y = 0;
        m_Velocity.z = 0;
        m_MoveSpeed = 4;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            m_Velocity += transform.right;
        }

        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            m_Velocity += -transform.right;
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            m_Velocity += -transform.forward;
        }

        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            m_Velocity += transform.forward;
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
        m_CanJump = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        m_CanJump = true;
        if(collision.gameObject.tag == "Dirt")
        {
            m_OnGround = true;
            
        }
        else if(collision.gameObject.tag != "Dirt")
        {
            m_OnGround = false;
        }

        if(collision.gameObject.tag == "Ennemy")
        {
            taupitaupe.GiveDamage(m_damage);
        }

        
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animatorRef.SetTrigger("Swing");
            
        }
        attackCD -= Time.deltaTime;
        if (attackCD <= 0.1)
        {
            m_IsAttacking = false;
            attackCD = 1;
        }

    }

    public void KnockUp()
    {
        if (taupitaupe.m_canKnockup)
        {
            Vector3 knockup = new Vector3(0, 50f, 0);
            m_PlayerRb.AddForce(knockup);
            taupitaupe.m_canKnockup = false;
        }

    }

    protected override void Die()
    {
        if (m_Health <= 0)
        {
            SceneManager.LoadScene("Gym");
        }
    }


    private void Interaction()
    {
        if (CanInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                ChestInteraction.Open();
            }
        }
    }

    

}