using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float spd;
    

    void Update()
    {

        transform.Translate(new Vector2(1, 0)* spd * Time.deltaTime);

    }






}
