using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_tir : MonoBehaviour
{
    [SerializeField] Rigidbody projectile;
    [SerializeField] float speed = 100;
    [SerializeField] private Transform bullet_holder;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody p = Instantiate(projectile, transform.position + GetComponentInChildren<Camera>().transform.forward * 0.8f, transform.rotation);
            p.transform.SetParent(bullet_holder);
            p.velocity = transform.forward * speed;
            //Debug.Log("bang");
        }
    }
}
