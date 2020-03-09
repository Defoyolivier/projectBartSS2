using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    private void Awake()
    {
        m_Health = 5;
        m_Speed = 10;
        m_HaveInput = true;
        m_damage = 1;
    }

    private void Update()
    {
        
    }

}
