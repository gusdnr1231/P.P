using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMagazine : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject, 3);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            Reload.curMagazine++;
        }
    }
}
