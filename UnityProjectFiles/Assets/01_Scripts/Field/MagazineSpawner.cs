using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineSpawner : MonoBehaviour
{
    [SerializeField] GameObject magazine;
    [SerializeField] private float spawnTime;

    void Start()
    {
        StartCoroutine("DropMagazine");
    }
    
    private IEnumerator DropMagazine()
    {
        while (true)
        {
            float potisionX = Random.Range(-7, 7);
            float potisionY = Random.Range(-4, 4);
            Instantiate(magazine, new Vector3(potisionX, potisionY, 0), Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }
 
}
