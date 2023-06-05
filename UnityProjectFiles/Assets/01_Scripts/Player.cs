using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float spd;
    private Vector2 curPos;

    public static float x, y;


    void Start()
    {

    }

    void Update()
    {
        Move();
        Clamp();
    }

    private void Move() //이동
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        Vector3 playerVec = new Vector3(x, y, 0);
        transform.position += playerVec * spd * Time.deltaTime;
    }

    private void Clamp() //이동 범위 제한
    {
        curPos = transform.position;
        curPos.x = Mathf.Clamp(curPos.x, -7, 7);
        curPos.y = Mathf.Clamp(curPos.y,-4, 4);
        transform.position = curPos;
    }


}
