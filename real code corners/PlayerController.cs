using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Fields
    [SerializeField] private float speed = 1.0f;
    [SerializeField] Transform camera;
    private Rigidbody rigidbody;
    private Animator animator;
    private bool isFiring = false;

    // Start is called before the first frame update
    // Methods
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        Shooting();
    }

    void FixedUpdate()
    {
        Movements();
    }

     private void Shooting()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) {
            isFiring = true;
        } else {
            isFiring = false;
        }

        PlayFiringAnimation();
    }

    private void PlayFiringAnimation()
    {
        if (isFiring) {
            animator.SetTrigger("FireTrigger");
            animator.SetBool("IsFiring", isFiring);
        } else {
            animator.SetBool("IsFiring", false);
        }

    }

   private void Movements()
    {
        Vector3 input = new(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 direction = input.normalized;

        if (input.magnitude > 0) {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;

            rigidbody.MoveRotation(Quaternion.Euler(0, targetAngle, 0));

            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            rigidbody.MovePosition(rigidbody.position + speed * Time.fixedDeltaTime * moveDir);

            isRunning = true;
        } else {
            isRunning = false;
        }

        PlayRunAnimation();
    }

    private void PlayRunAnimation()
    {
        animator.SetBool("IsRun", isRunning);
    }
}