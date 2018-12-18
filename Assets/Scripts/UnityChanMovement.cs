using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanMovement : MonoBehaviour {

    Animator animator;
    Rigidbody rb;
    public float speed = 1f;
    public float velocity = 0f;

	void Start () {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
        float y = Input.GetAxis("Vertical");
        velocity = y * speed;
        if (Mathf.Abs(velocity) > float.Epsilon) //if (y != 0)
        {
            animator.SetBool("isMoving", true);
            animator.SetFloat("Velocity", y);
            rb.velocity = transform.forward * velocity;
        }
        else
            animator.SetBool("isMoving", false);
    }
}
