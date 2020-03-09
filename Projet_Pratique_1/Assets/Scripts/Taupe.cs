using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Taupe : enemy
{
    [SerializeField] private PlayerController Player;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Rigidbody TaupeRBRef;
    [SerializeField] private Animator animatorRef;
    public Transform m_PlayerPos;
    public bool m_PlayerOnGround = false;
    private float m_distTaupe;
    public bool m_canKnockup = true;
    private float TimeChase = 3;
    private bool inCombat = false;

    [SerializeField]private List<Transform> m_WayPoint;

    private void Awake()
    {
        m_Health = 6;
        m_Speed = 4.5f;
        m_HaveInput = true;
        m_damage = 2;
    }

    private void Update()
    {


        if (inCombat)
        {
            Combat();
        }
        else
        {
            if (!navMeshAgent.pathPending)
            {
                if (!Player.m_OnGround)
                {
                    Patrol(Random.Range(0, 2));

                }
                else
                {
                    ChaseNavMesh();
                    Debug.Log("Chasing");
                }
            }
        }

    }


    private void ChaseNavMesh()
    {
        TimeChase -= Time.deltaTime;
        navMeshAgent.SetDestination(Player.transform.position);

        Vector3 NewPlayerPos = new Vector3(m_PlayerPos.position.x, transform.position.y, m_PlayerPos.position.z);
        m_distTaupe = Vector3.Distance(NewPlayerPos, transform.position);

        if (Player.m_OnGround && m_canKnockup && m_distTaupe <= 1.5 || TimeChase <= 0)
        {
            if(TimeChase <= 0 && m_canKnockup)
            {
                animatorRef.SetBool("AboveGround", true);
                Player.KnockUp();
                m_canKnockup = false;
                inCombat = true;
            }

            animatorRef.SetBool("AboveGround", true);
            Player.KnockUp();
            m_canKnockup = false;
            inCombat = true;
            
        }
    }

    private void Combat()
    {
        Vector3 NewPlayerPos = new Vector3(m_PlayerPos.position.x, transform.position.y, m_PlayerPos.position.z);
        m_distTaupe = Vector3.Distance(NewPlayerPos, transform.position);
        navMeshAgent.SetDestination(Player.transform.position);
        transform.LookAt(NewPlayerPos);

        if(m_distTaupe <= 5)
        {
            Leap(NewPlayerPos);
        }

    }

    private void Leap(Vector3 PlayerPos)
    {

        //TaupeRBRef.AddForce(PlayerPos);
        // leap not working
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player.GiveDamage(m_damage);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon" && inCombat)
        {
            GiveDamage(m_damage);
            
        }
    }

    private void Patrol(int index)
    {
        navMeshAgent.SetDestination(m_WayPoint[index].position);
    }



}
