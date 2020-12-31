using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars_Movement : MonoBehaviour
{
    [Header("Car's Attributes")]
    public float speed = 8f;
    [SerializeField] private GameObject startPoint;
    private Cars_Manager carManager;

    private void Start()
    {
        carManager = GameObject.FindObjectOfType<Cars_Manager>();
        carManager.changeSpeed += ChangeSpeed;
        speed = carManager.carSpeed;
    }

    void Update()
    {
        transform.localPosition += Vector3.back * speed * Time.deltaTime;
    }

    public void ChangeSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
