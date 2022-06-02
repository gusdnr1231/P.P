using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePos : MonoBehaviour
{
    [SerializeField] float a;
    private Vector3 mousePos;

    void Start()
    {
        
    }

    void Update()
    {
        Rotation();
    }

    void Rotation()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        a = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0f, 0f, a);
    }


}
