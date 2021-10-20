using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fleche_rotation : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void switch_fleche()
    {
        anim.SetBool("contre_sens", true);
    }
    public void switch_fleche_retour()
    {
        anim.SetBool("contre_sens", false);
    }
}
