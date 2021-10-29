using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placement : MonoBehaviour
{
    Rigidbody2D body;
    private bool drag_on = false;
    public Transform origines;
    public bool _Start = false;
    
    


    void Awake()
    {
        
    }
    
        
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public float DivisionEuclidienne(float diviseur, float quotient)
    {
        return ((diviseur - diviseur % quotient) / quotient);
    }


    void Update()
    {
        Vector3 souris_pos = Input.mousePosition;
 
        if (drag_on)
        {
            transform.position = new Vector2(souris_pos.x, souris_pos.y);
     
        }


        if (Input.GetMouseButtonDown(0))
        {

            if (drag_on)
            {
                drag_on = false;
                if (souris_pos.x < 416)
                {
                    transform.position = new Vector2(origines.transform.position.x, origines.transform.position.y);
                }
                else
                {
                    transform.position = new Vector2(DivisionEuclidienne((souris_pos.x / 128), 1) * 128 + 64, DivisionEuclidienne((souris_pos.y / 128), 1) * 128 + 64);
                }
                
            }

            else if (souris_pos.x > transform.position.x- 80 && souris_pos.x < transform.position.x + 64 && souris_pos.y > transform.position.y - 64 && souris_pos.y < transform.position.y + 80)
            {
                drag_on = true;
                
            }


            
        }
        if (Input.GetKeyDown("space"))
        {
            if (transform.position.x < 416)
            {
                Debug.Log("error");
            }
            else
            {
                _Start = true;
            }
        }
        
            

            





        }

    public bool _isStart()
    {
        return _Start;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "border" && !_Start)
        {
            transform.position = new Vector2(origines.transform.position.x, origines.transform.position.y);

        }
        if (collision.gameObject.tag == "crown_border" && !_Start)
        {
            transform.position = new Vector2(origines.transform.position.x, origines.transform.position.y);

        }
        if (collision.gameObject.tag == "box" && !_Start)
        {
            transform.position = new Vector2(origines.transform.position.x, origines.transform.position.y);

        }
    }
}
