using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class direction : MonoBehaviour
{
    public GameObject cube;
    public Vector3 rotationPoint;

    public void rotation_fleche()
    
    {
        int i = cube.GetComponent<move>().direction_cube();
        Debug.Log(i);
        if (i == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (i == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        else if (i == 2)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (i == 3)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }
}
