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
        var collTag = collision.gameObject.tag;
        switch (collTag)
        {
            case "Obstacle": //Lose condition
                {
                    shouldMove = false;
                    UI_Manager.gameOver = true;
                    break;
                }
            case "FinishLine": //Win condition
                {
                    shouldMove = false;
                    UI_Manager.gameWon = true;
                    break;
                }
        }
    }

    private void ClampMovement()
    {
        Vector3 clampedPos = transform.position;
        clampedPos.y = Mathf.Clamp(clampedPos.y, Y_MIN, Y_MAX);
        transform.position = clampedPos;
    }

    private void Movement()
    {
        if (shouldMove == false)
            return;

        else
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
            //cam.transform.position += Vector3.forward * speed * Time.deltaTime; 
        }
    }

}
