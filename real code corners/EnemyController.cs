using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] GameObject player;
    [SerializeField] float breakDistance = 2.0f;

    private bool isChasing = false;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > breakDistance)
        {
            transform.LookAt(player.transform);
            rigidbody.position = Vector3.MoveTowards(
                transform.position,
                player.transform.position,
                speed * Time.fixedDeltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isChasing = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isChasing = false;
        }
    }
}