﻿//Script from CouchFerret's tutorial: https://www.youtube.com/watch?v=yfsqai3ivyA


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCont_2D : MonoBehaviour
{
    [Header("Character attributes:")]
    public float MOVEMENT_BASE_SPEED = 1.0f;

    [Space]
    [Header("Character statistics:")]
    public Vector2 movementDirection;
    public float movementSpeed;

    [Space]
    [Header("References")]
    public Rigidbody2D rb;
    public Animator animator;
  
    void Update()
    {
        ProcessInputs();
        Move();
        Animate();
    }

    void ProcessInputs()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input .GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
    }

    void Move()
    {
        rb.velocity = movementDirection * movementSpeed * MOVEMENT_BASE_SPEED; 
    }

    void Animate()
    {
        if (movementDirection != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movementDirection.x);
            animator.SetFloat("Vertical", movementDirection.y);
        }

        animator.SetFloat("Speed", movementSpeed);
    }
}



