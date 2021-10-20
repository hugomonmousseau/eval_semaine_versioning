using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crown : MonoBehaviour
{
    public Color[] Colors;
    public int index = 0;
    public SpriteRenderer sr;

    void Update()
    {

        sr.color = Colors[index];
    }

    public int crown_index()
    {
        return index;
    }
}
