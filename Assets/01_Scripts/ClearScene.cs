using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScene : MonoBehaviour
{
    [SerializeField] Transform buttonsTrans;
    int count = 0;
    float x, y;

    public void ChangeTransform()
	{
        if (count == 4)
            Application.Quit();
        else if (count != 4)
        {
            x = Random.Range(-8, 8);
            y = Random.Range(-5, 5);
            buttonsTrans.position = new Vector2(x, y);
            count++;
		}
	} 
    
}
