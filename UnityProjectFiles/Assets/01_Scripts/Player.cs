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

    private void Move() //�̵�
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        Vector3 playerVec = new Vector3(x, y, 0);
        transform.position += playerVec * spd * Time.deltaTime;
    }

    private void Clamp() //�̵� ���� ����
    {
        curPos = transform.position;
        curPos.x = Mathf.Clamp(curPos.x, -7, 7);
        curPos.y = Mathf.Clamp(curPos.y,-4, 4);
        transform.position = curPos;
    }


}
