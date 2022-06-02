using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float spd;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.up * spd * Time.deltaTime;
    }

    



}
