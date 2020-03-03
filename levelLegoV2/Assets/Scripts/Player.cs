using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject flashLight;


    public void FlashLightOn()
    {
        flashLight.SetActive(true);
    }

}
