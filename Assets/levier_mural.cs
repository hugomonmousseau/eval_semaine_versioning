using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levier_mural : MonoBehaviour
{
    public List<GameObject> murs;

    public void switch_levier()
    {
        int i = 0;
        while (murs.Count != i)
        {
            murs[i].GetComponent<mur_manager>().activation_murale();
            i++;
        }
    }
}
