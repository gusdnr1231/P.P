using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMove : MonoBehaviour
{
    
    private Vector2 curPos;



    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.transform.position = Vector2.MoveTowards(transform.transform.position, mousePos, Time.deltaTime * 20);
        }
        Clamp();
    }

    private void Clamp() //이동 범위 제한
    {
        curPos = transform.position;
        curPos.x = Mathf.Clamp(curPos.x, -7, 7);
        curPos.y = Mathf.Clamp(curPos.y, -4, 4);
        transform.position = curPos;
    }
}
