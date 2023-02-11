using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject m_bulletPrefab;
    [SerializeField] float m_forceFactor = 3.0f;
    [SerializeField] float m_cooldown = 1.0f;
    [SerializeField] GameObject m_muzzle;
    [SerializeField] GameObject m_muzzleEffect;

    private float m_lastTimeShot = 0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButton(0) && Time.time > m_lastTimeShot + m_cooldown) {
            m_lastTimeShot = Time.time;

            GameObject bullet = Instantiate(
                m_bulletPrefab,
                m_muzzle.transform.position,
                Quaternion.identity
            );
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            Vector3 movDir = Quaternion.Euler(0, transform.eulerAngles.y, 0) * Vector3.forward;

            PlayMuzzleEffect();

            rb.AddForce(m_forceFactor * movDir, ForceMode.Impulse);
            Destroy(bullet, 2.0f);
        }
    }

    private void PlayMuzzleEffect()
    {
        GameObject effect = Instantiate(
            m_muzzleEffect,
            m_muzzle.transform.position,
            Quaternion.identity
        );

        StartCoroutine(MoveEffectWithMuzzle(effect));
    }

    private IEnumerator MoveEffectWithMuzzle(GameObject effect)
    {
        float startTime = Time.time;
        while (Time.time < startTime + 0.5f) {
            effect.transform.position = m_muzzle.transform.position;
            yield return new WaitForFixedUpdate();
        }

        Destroy(effect);
    }
}