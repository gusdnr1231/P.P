using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMagazine : MonoBehaviour
{
    Player player;

    void Start()
    {
        Destroy(gameObject, 3);
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.Score += 100;
            Destroy(gameObject);
            Reload.curMagazine++;
        }
    }
}
