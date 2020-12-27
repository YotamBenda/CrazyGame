using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("Player Attributes")]
    [SerializeField] private float speed = 20f;

    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
}
