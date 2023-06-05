using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullScript : MonoBehaviour
{
    [SerializeField] GameObject LazerRange;
    [SerializeField] GameObject Lazer;
    [SerializeField] int poolSize;

    List<GameObject> lazerRange = new List<GameObject>();
    List<GameObject> lazer = new List<GameObject>();


    void Awake()
    {
        for(int i = 0; i < poolSize; i++)
		{
            lazer.Add(Instantiate(Lazer));
            lazer[i].SetActive(false);
            lazerRange.Add(Instantiate(LazerRange));
            lazerRange[i].SetActive(false);
		}
    }
    
    public GameObject SpawnLazer(Vector3 pos, Quaternion rotate)
	{
        GameObject lr; //레이저 범위
        GameObject l; //레이저

        if(lazerRange.Count > 0)
		{
            lr = lazerRange[0];
            lazerRange.RemoveAt(0);
		}
		else
		{
            lr = Instantiate(LazerRange);
		}
        if (lazer.Count > 0)
        {
            l = lazer[0];
            lazer.RemoveAt(0);
        }
        else
        {
            l = Instantiate(Lazer);
        }

        return lr;
        return l;
    }

    IEnumerator FireLazer(GameObject laz, GameObject lazR) //레이저 발사하기
	{
        lazR.SetActive(true);
        ReturnLazerRange(lazR);
        yield return new WaitForSeconds(3f);
        laz.SetActive(true);
        ReturnLazer(laz);
	}

    public void ReturnLazer(GameObject obj)
	{
        obj.SetActive(false);
        lazer.Add(obj);
	}

    public void ReturnLazerRange(GameObject obj)
	{
        obj.SetActive(false);
        lazerRange.Add(obj);
	}
}
