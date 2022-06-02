using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    [SerializeField] private GameObject bullet;
    public static Quaternion dir;
    public void _Fire()
    {
        if (Reload.curAmmo > 0)
        {
            Reload.curAmmo--;
            Instantiate(bullet, transform.position, dir);
        }
    }
    void Update()
    {
        Rotate();
        if(Input.GetButtonDown("Fire1")) _Fire();
    }


    private void Rotate() //위 아래로 총알 발사 불가 수정하세요 시발련아
    {
        if (Player.x <= 0) dir = Quaternion.Euler(0, 0, 180);
        else if (Player.x >= 0) dir = Quaternion.Euler(0, 0, 0);
        else if (Player.y <= 0) dir = Quaternion.Euler(90, 0, 0);
        else if (Player.y >= 0) dir = Quaternion.Euler(270, 0, 0);
    }


}
