using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpOrbs : MonoBehaviour
{
    [SerializeField] private GameObject PlayerGO;
    [SerializeField] private GameObject Pouch;

    Vector3 StartPos = new Vector3();
    Vector3 EndPos = new Vector3();
    Vector3 ScalePouch = new Vector3(2f, 2f, 2f);
    private float speed = 2;
    private float startTime;
    private float journeyLength;


    private void Start()
    {
        startTime = Time.time;

        journeyLength = Vector3.Distance(StartPos, EndPos);
        Rigidbody RbRef = GetComponent<Rigidbody>();
        RbRef.AddForce(0,50,0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Pouch.transform.localScale.Scale(ScalePouch * 2);
            gameObject.SetActive(false);

        }
    }

    private void Update()
    {
        journeyLength = Vector3.Distance(StartPos, EndPos);


        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;
        StartPos = transform.position;
        EndPos = PlayerGO.transform.position;
        transform.position = Vector3.Lerp(StartPos, EndPos, 1 * Time.deltaTime);

    }
}
