using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    private void Awake()
    {
        base.m_Health = 5;
        base.m_Speed = 10;
        base.m_HaveInput = true;
        base.m_damage = 1;
    }

    private void Update()
    {
        
    }

}
