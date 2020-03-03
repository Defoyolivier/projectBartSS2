using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alcool : MonoBehaviour
{
    [SerializeField] private Drunk DrunkRef;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(0, 1, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        DrunkRef.shakeDuration = 10f;
    }
}
