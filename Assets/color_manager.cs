using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color_manager : MonoBehaviour
{
    public Color[] Colors;
    public int index = 0;
    public SpriteRenderer sr;

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            index++;
            if (index == Colors.Length)
            {
                index = 0;
            }
        }
        sr.color = Colors[index];
    }

    public int test()
    {
        return index;
    }
}
