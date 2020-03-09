using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected string m_Name;
    protected int m_Health;
    protected float m_Speed;
    protected bool m_HaveInput;
    protected int m_damage;
    protected float m_NoDamageTimer = 2;
    protected bool canTakeDmg = true;

    private void Update()
    {
        if (!canTakeDmg)
        {
            m_NoDamageTimer -= Time.deltaTime;
            if (m_NoDamageTimer <= 0)
            {
                canTakeDmg = true;
                m_NoDamageTimer = 2;
            }
        }
    }

    public void GiveDamage(int i_damage)
    {
        if (canTakeDmg)
        {
            m_Health -= m_damage;
        }


        if(m_Health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        this.gameObject.SetActive(false);
        Debug.Log("Died");
    }

}
