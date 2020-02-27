using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taupe : enemy
{
    
    public Transform m_PlayerPos;
    public bool m_PlayerOnGround = false;
    private float m_distTaupe;
    public bool m_canKnockup = true;


    private void Awake()
    {
        m_Health = 3;
        m_Speed = 4.5f;
        m_HaveInput = true;
        m_damage = 1;
    }

    private void Update()
    {
        Chase();
        
    }

    private void Chase()
    {
        Vector3 NewPlayerPos = new Vector3(m_PlayerPos.position.x, transform.position.y, m_PlayerPos.position.z);
        m_distTaupe = Vector3.Distance(NewPlayerPos, transform.position);
        if (Player.m_OnGround && m_distTaupe >= 0.8)
        {
            transform.LookAt(NewPlayerPos);
            transform.position += transform.forward * m_Speed * Time.deltaTime;
        }
        else if (Player.m_OnGround && m_canKnockup && m_distTaupe <= 0.8)
        {
            Player.KnockUp();
            Combat();
        }
    }

    private void Combat()
    {
        transform.position += transform.up;

    }







}
