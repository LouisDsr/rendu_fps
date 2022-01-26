using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class spawn_player : MonoBehaviour
{
    [SerializeField] private List<Transform> walls;
    [SerializeField] private GameObject target;
    public static int nbTarget = 0;
    [SerializeField] float counterSpawnTarget = 0;
    [SerializeField] float timer = 5;
    [SerializeField] private bool canSpawn = false;
    [SerializeField] private Transform target_holder;
    private bool wall_exist = true;
    

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("spawn");
        if (wall_exist)
        {
            foreach (Transform w in walls)
            {
                Destroy(w.gameObject);
                wall_exist = false;
            }
            canSpawn = true;
        }
        
    }
    void Update()
    {
        if (canSpawn)
        {
            if (nbTarget < 10)
            {
                counterSpawnTarget += Time.deltaTime;
                if (counterSpawnTarget > timer)
                {
                    SpawnTarget();
                    //Debug.Log(nbTarget);
                }
            }
        }
    }
    
    private void SpawnTarget()
    {
        Vector3 vect_target;
        vect_target.y = Random.Range(3f, 10f);
        vect_target.x = Random.Range(-45f, 45);
        vect_target.z = Random.Range(-45f, 45);
        Instantiate(target, vect_target, transform.rotation, target_holder);
        //Debug.Log("target has spawn");
        nbTarget += 1;
    }
}
