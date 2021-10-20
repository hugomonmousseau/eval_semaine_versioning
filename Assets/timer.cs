using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public GameObject _txtTime;
    public GameObject idbox_explosion;
    public GameObject box;

    public float _timer;
    private int affichage;
    public bool _start = false;

    void Start()
    {
        _timer++;
    }

    public void timer_start()
    {
        _start = true;
    }
    void Update()
    {
        if (_start)
        {
            _timer -= Time.deltaTime *3 / 1.28f;

            if (_timer < 0)
            {
                box.GetComponent<move>().box_explosee();
                idbox_explosion.SetActive(true);
            }
            affichage = (int)_timer;

            _txtTime.GetComponent<TextMesh>().text = affichage.ToString();
        }

        
    }
}
