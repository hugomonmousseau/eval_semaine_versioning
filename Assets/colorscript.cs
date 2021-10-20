using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorscript : MonoBehaviour
{
    public Color[] Colors;
    public int index = 0;
    public SpriteRenderer sr;
    public SpriteRenderer sr_top;
    

    void Update()
    {
        sr.color = Colors[index];
        sr_top.color = Colors[index];


    }

    public float ValeurAbsolue(float chiffre)
    {
        return Mathf.Sqrt(chiffre * chiffre);
    }

    public int cube_index()
    {
        return index;
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "color_chager" && GetComponent<placement>()._isStart())
        {
            
            if (ValeurAbsolue(transform.position.x % 128) > 60 && ValeurAbsolue(transform.position.x % 128) < 68 && ValeurAbsolue(transform.position.y % 128) > 60 && ValeurAbsolue(transform.position.y % 128) < 68)
            {
                
                index = collision.GetComponent<color_manager>().test();
            }
        }
    }
}
