using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] private Player playerRef;
    private bool notPickup = true;


    private void Update()
    {
        Rotate();
    }

    public void Rotate()
    {
        transform.Rotate(0, 1, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        playerRef.FlashLightOn();
    }

}
