using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars_Movement : MonoBehaviour
{
    [Header("Car's Attributes")]
    [SerializeField] private float speed = 5f; //debug
    [SerializeField] private GameObject startPoint;

    void Update()
    {
        transform.localPosition += Vector3.back * speed * Time.deltaTime;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("hit" + other.gameObject.name);
    //    if(other.gameObject.tag == "CarsRoadEnd")
    //    {
    //        transform.position = startPoint.transform.position;
    //    }
    //}
}
