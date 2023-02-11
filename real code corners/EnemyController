using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class EnemyController : MonoBehaviour
{
    [SerializeField] float m_speed = 1.0f;
    [SerializeField] GameObject m_player;
    [SerializeField] float m_breakDistance = 2.0f;

    private bool m_isChasing = false;
    private Rigidbody m_rb;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyMovment();
    }

    private void EnemyMovment()
    {
        float distance = Vector3.Distance(transform.position, m_player.transform.position);

        if (distance > m_breakDistance)
        {
            transform.LookAt(m_player.transform);
            m_rb.position = Vector3.MoveTowards(transform.position, m_player.transform.position, m_speed * Time.fixedDeltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_isChasing = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_isChasing = false;
        }
    }
}