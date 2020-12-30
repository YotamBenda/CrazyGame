﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("Inits")]
    private Camera cam;
    private GameManager gm;
    private Lean.Touch.LeanDragTranslate lean;
    [SerializeField] private Rigidbody rb;

    [Header("Player Attributes")]
    [SerializeField] private float speed = 20f;
    [SerializeField] private float pushForce = 10;
    private bool shouldMove;

    [Header("ClampMovement")]
    [SerializeField] private float Y_MAX;
    [SerializeField] private float Y_MIN;


    private void Start()
    {
        lean = gameObject.GetComponent<Lean.Touch.LeanDragTranslate>();
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
                    lean.enabled = false;
                    rb.constraints = RigidbodyConstraints.None;
                    cam.transform.SetParent(null);
                    gm.GameLostInvoke();
                    break;
                }
            case "FinishLine": //Win condition
                {
                    shouldMove = false;
                    lean.enabled = false;
                    rb.constraints = RigidbodyConstraints.None;
                    cam.transform.SetParent(null);
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
            rb.AddForce(Vector3.forward * pushForce, ForceMode.Acceleration);
            return;
        }

        else
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
    }

}
