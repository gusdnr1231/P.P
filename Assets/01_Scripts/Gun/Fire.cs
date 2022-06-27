using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    [SerializeField] private GameObject bullet;
    public static Quaternion dir;

    void Update()
    {
        Rotate();
        if (Input.GetButtonDown("Fire1")) _Fire();
    }
    public void _Fire()
    {
        if (Reload.curAmmo > 0)
        {
            Reload.curAmmo--;
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
    private void Rotate() //위 아래로 총알 발사 가능
    {
        if (Player.x < 0) dir = Quaternion.Euler(0, 0, 180);
        if (Player.x > 0) dir = Quaternion.Euler(0, 0, 0);
        if (Player.y < 0) dir = Quaternion.Euler(0, 0, 270);
        if (Player.y > 0) dir = Quaternion.Euler(0, 0, 90);
    }


}
