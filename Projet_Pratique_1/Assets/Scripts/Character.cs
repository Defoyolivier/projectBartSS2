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


    public void GiveDamage(int i_damage)
    {
        m_Health -= i_damage;
        if(m_Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Died");
    }

}
