using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mur_manager : MonoBehaviour
{
    public GameObject mur;
    public GameObject motif;

    private bool start_top = true;

    public void descente()
    {
        mur.SetActive(false);
        motif.SetActive(true);
        start_top = true;
    }
    void Start()
    {

     
    }
    public void top()
    {
        start_top = true;
    }

    public void activation_murale()
    {
        if (start_top)
        {
            mur.SetActive(true);
            motif.SetActive(false);
            start_top = false;
            mur.GetComponent<mur_changement>().mur_changement_start();
        }
    }
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            



        }
        
    }
}
