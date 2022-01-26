using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target_destroy : MonoBehaviour
{
    [SerializeField] public float timer_target = 20;
    private static LayerMask bullet_layer;

    private void Awake()
    {
        bullet_layer = LayerMask.NameToLayer("bullet");
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.layer == bullet_layer)
        {
            var cubeRenderer = gameObject.GetComponent<Renderer>();
            if (cubeRenderer.material.color == Color.red)
            {
                spawn_player.nbTarget -= 1;
                Destroy(transform.gameObject);
            }
            else
            {
                cubeRenderer.material.SetColor("_Color", Color.red);
            }
        }
    }

    private void Start()
    {
        StartCoroutine(Dispawn());
    }

    private IEnumerator Dispawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer_target);
            spawn_player.nbTarget -= 1;
            Destroy(transform.gameObject);
        }
    }
}
