using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanMovement : MonoBehaviour {

    Animator animator;
    Rigidbody rb;
    public float speed = 1f;
    public float turnSpeed = 1f;

	void Start () {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        float velocity = y * speed;
        float turnVelocity = x * turnSpeed;

        if (Mathf.Abs(velocity) > float.Epsilon)
        {
            animator.SetBool("isMoving", true);
            animator.SetFloat("Velocity", y);
            //Vector3 velocityToApply = new Vector3(0, turnVelocity, 0);
            rb.velocity = transform.forward * velocity;
        }
        else
            animator.SetBool("isMoving", false);

        //if (Mathf.Abs(turnVelocity) > float.Epsilon)
        {
            animator.SetFloat("TurnRate", x);
            Vector3 rotationToApply = new Vector3(0, turnVelocity, 0);
            rb.rotation = Quaternion.Euler(rb.rotation.eulerAngles + rotationToApply);
        }
    }
}
