using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float spd;


    void Update()
    {
        transform.Translate(Vector2.right * spd * Time.deltaTime);

    }






}
