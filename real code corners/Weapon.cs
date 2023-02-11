using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float forceFactor = 3.0f;
    [SerializeField] float cooldown = 1.0f;
    [SerializeField] GameObject muzzle;
    [SerializeField] GameObject muzzleEffect;

    private float lastTimeShot = 0f;


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
        if (Input.GetMouseButton(0) && Time.time > lastTimeShot + cooldown) {
            lastTimeShot = Time.time;

            var bullet = Instantiate(
                bulletPrefab,
                muzzle.transform.position,
                Quaternion.identity
            );

            var rb = bullet.GetComponent<Rigidbody>();

            var movDir = Quaternion.Euler(0, transform.eulerAngles.y, 0) * Vector3.forward;

            PlayMuzzleEffect();

            rb.AddForce(forceFactor * movDir, ForceMode.Impulse);
            Destroy(bullet, 2.0f);
        }
    }

    private void PlayMuzzleEffect()
    {
        var effect = Instantiate(
            muzzleEffect,
            muzzle.transform.position,
            Quaternion.identity
        );

        StartCoroutine(MoveEffectWithMuzzle(effect));
    }

    private IEnumerator MoveEffectWithMuzzle(GameObject effect)
    {
        float startTime = Time.time;

        while (Time.time < startTime + 0.5f) {
            effect.transform.position = muzzle.transform.position;
            yield return new WaitForFixedUpdate();
        }

        Destroy(effect);
    }
}