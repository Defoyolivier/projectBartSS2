using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    [SerializeField] private PlayerController PlayerRef;
    [SerializeField] private Transform TopChest;
    [SerializeField] private GameObject ExpOrb1;
    [SerializeField] private GameObject ExpOrb2;
    [SerializeField] private GameObject TextInteraction;
    private bool isOpen = false;


    private void OnTriggerEnter(Collider other)
    {
        if (!isOpen)
        {
            PlayerRef.CanInteract = true;
            TextInteraction.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerRef.CanInteract = false;
        TextInteraction.SetActive(false);
    }
    public void Open()
    {
        if (!isOpen)
        {
            TopChest.transform.Rotate(-75, 0, 0);
            ExpOrb1.SetActive(true);
            ExpOrb2.SetActive(true);
            isOpen = true;
        }
    }
}
