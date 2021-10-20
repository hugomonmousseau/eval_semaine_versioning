using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mur_changement : MonoBehaviour
{
    private Animator anim;
    public GameObject manager;



    void Start()
    {
        anim = GetComponent<Animator>();

    }

    public void Fin_anim_monte()
    {
        anim.SetBool("mur_change", false);
        anim.SetBool("mur_bas", false);
        manager.GetComponent<mur_manager>().top();

    }
    public void Fin_anim_descente()
    {
        anim.SetBool("mur_change", false);
        anim.SetBool("mur_bas", true);

        manager.GetComponent<mur_manager>().descente();



    }


    public void mur_changement_start()
    {
        anim.SetBool("mur_change", true);
    }

}
