using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("Inits")]
    private Camera cam;
    private GameManager gm;

    [Header("Player Attributes")]
    [SerializeField] private float speed = 20f;
    private bool shouldMove;

    [Header("ClampMovement")]
    [SerializeField] private float Y_MAX;
    [SerializeField] private float Y_MIN;


    private void Start()
    {
        cam = Camera.main;
        shouldMove = true;
        gm = GameObject.FindObjectOfType<GameManager>();
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
                    gm.GameLostInvoke();
                    break;
                }
            case "FinishLine": //Win condition
                {
                    shouldMove = false;
                    gm.GameWonInvoke();
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
        {
            return;
        }

        else
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
    }

}
