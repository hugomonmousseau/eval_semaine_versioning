using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public Transform end;

    public float ValeurAbsolue(float chiffre)
    {
        return Mathf.Sqrt(chiffre * chiffre);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "box" && (ValeurAbsolue(collision.transform.position.x % 128) > 60 && ValeurAbsolue(collision.transform.position.x % 128) < 68 && ValeurAbsolue(collision.transform.position.y % 128) > 60 && ValeurAbsolue(collision.transform.position.y % 128) < 68)
)
        {
            collision.transform.position = new Vector2(end.transform.position.x, end.transform.position.y);
            
        }
    }
}
