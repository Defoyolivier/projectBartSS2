using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drunk : MonoBehaviour
{
    public Transform camTransform;
    public GameObject vomit;

    public float shakeDuration = 0f;

    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
            vomit.SetActive(true);
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
            vomit.SetActive(false);
        }
    }
}
