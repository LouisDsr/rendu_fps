using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taget_controller : MonoBehaviour
{
    [SerializeField] private float timer_total = 3f;
    private Rigidbody rigid_body;
    [SerializeField] private float speed_modifier = 200f;
    
    void Start()
    {
        rigid_body = GetComponent<Rigidbody>();
        StartCoroutine(target_moves());
    }

    private IEnumerator target_moves()
    {
        while (true)
        {
            rigid_body.velocity = Vector3.zero;
            float timer = 0f;
            Vector3 deltaForce = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)) * speed_modifier;
            rigid_body.AddForce(deltaForce);
            while (timer < timer_total)
            {
                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
