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

    [SerializeField]private List<Transform> m_WayPoint;

    private void Awake()
    {
        m_Health = 3;
        m_Speed = 4.5f;
        m_HaveInput = true;
        m_damage = 5;
    }

    private void Update()
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
            }
        }
    }

    private void Chase()
    {
        Vector3 NewPlayerPos = new Vector3(m_PlayerPos.position.x, transform.position.y, m_PlayerPos.position.z);
        m_distTaupe = Vector3.Distance(NewPlayerPos, transform.position);
        if (Player.m_OnGround && m_distTaupe >= 0.8)
        {
            transform.LookAt(NewPlayerPos);
            
        }
        else if (Player.m_OnGround && m_distTaupe <= 1 )
        {
            Player.KnockUp();
            animatorRef.SetBool("AboveGround", true);
        }
    }

    private void ChaseNavMesh()
    {
        navMeshAgent.SetDestination(Player.transform.position);
        Vector3 NewPlayerPos = new Vector3(m_PlayerPos.position.x, transform.position.y, m_PlayerPos.position.z);
        m_distTaupe = Vector3.Distance(NewPlayerPos, transform.position);

        if (Player.m_OnGround && m_canKnockup && m_distTaupe <= 1)
        {
            Player.KnockUp();
            animatorRef.SetBool("AboveGround", true);
        }
    }

    private void Combat()
    {
        
        Player.GiveDamage(m_damage);
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
    }

    private void Patrol(int index)
    {
        navMeshAgent.SetDestination(m_WayPoint[index].position);
    }



}
