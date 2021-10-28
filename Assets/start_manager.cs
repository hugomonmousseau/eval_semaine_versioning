using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class start_manager : MonoBehaviour
{
    public List<GameObject> blocs;
    private int points_lvl;
    private int pixels;
    private int Level = 1;
    public GameObject bouton_niveau;
    

    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            int i = 0;
            int j = 0;
            while (blocs.Count != i)
            {
                if (!(blocs[i].transform.position.x > 416))
                {
                    j++;
                }

                i++;
            }
            int k = 0;
            if (j == 0)
            {
                while (blocs.Count != k)
                {
                    blocs[k].GetComponent<move>().start_direction();
                    blocs[k].GetComponent<move>().start_timer();
                    k++;
                }
            }  
        }

        Debug.Log(points_lvl);
        Debug.Log(blocs.Count);

        if (points_lvl == blocs.Count *2)
        {
            bouton_niveau.SetActive(true);
        }
    }

    public void points()
    {
        points_lvl++;
        Debug.Log(points_lvl);

    }


}
