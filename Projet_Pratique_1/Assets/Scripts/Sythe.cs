using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sythe : MonoBehaviour
{
    public Animator animatorRef;


    public void Swing()
    {
        animatorRef.SetBool("Swing", true);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
