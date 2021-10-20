using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_color : MonoBehaviour
{
    public Color[] Colors;
    public int index;
    public SpriteRenderer sr;


    void Update()
    {
        sr.color = Colors[index];
    }

    public void self_destruction()
    {
        Destroy(gameObject);
    }
}
