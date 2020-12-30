using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("InitInfo")]
    private Camera cam;

    [Header("Player Attributes")]
    [SerializeField] private float speed = 20f;
    private bool shouldMove = true;

    [Header("ClampMovement")]
    [SerializeField] private float X_MAX;
    [SerializeField] private float X_MIN;
    [SerializeField] private float Y_MAX;
    [SerializeField] private float Y_MIN;


    private void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        Movement();
        ClampMovement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            //enter lose condition
            shouldMove = false;
            UI_Manager.gameOver = true;
        }
    }

    private void ClampMovement()
    {
        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, X_MIN, X_MAX);
        clampedPos.y = Mathf.Clamp(clampedPos.y, Y_MIN, Y_MAX);
        transform.position = clampedPos;
    }

    private void Movement()
    {
        if (shouldMove)
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
            cam.transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        else
            return;
    }

}
