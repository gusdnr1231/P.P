using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursur : MonoBehaviour
{

    void Start()
    {
        Cursor.visible = false;
    }


    void Update()
    {
        objectMove(gameObject);
    }

    void objectMove(GameObject obj)
	{
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 vec = new Vector3(mousepos.x, mousepos.y, 0);
        obj.transform.position = vec;
	}


}
