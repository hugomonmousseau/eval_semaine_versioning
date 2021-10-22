using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed = 3.0f;
    public Collider2D collision;
    public int multiplicateur = 1;

    public float MaxCooldownEchangeur = 1f;
    private float CooldownEchangeur = 0f;

    public List<GameObject> fleches;
    public List<GameObject> autre_cube;


    public GameObject direction_depart_fleches;
    public int _direction;
    public GameObject timer;
    public GameObject idbox_explosion;
    private bool _isExplosed = false;

    public GameObject _cube_explosion;

    public GameObject _start_manager;

    public int direction_cube()
    {
        return _direction;
    }
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        horizontal = 0;
        vertical = 0;

        direction_depart_fleches.GetComponent<direction>().rotation_fleche();
    }

    public float DivisionEuclidienne(float diviseur, float quotient)
    {
        return ((diviseur - diviseur % quotient) / quotient);
    }

    public float ValeurAbsolue(float chiffre)
    {
        return Mathf.Sqrt(chiffre * chiffre);
    }
    // Use this for initialization

    void Update()
    {
       if (GetComponent<placement>()._isStart())
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        if (runSpeed > 300f)
        {
            runSpeed -= (runSpeed / 100);

        }
        if (GetComponent<placement>()._isStart())
        {
            direction_depart_fleches.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "border")
        {
            runSpeed = 0f;

            if (GetComponent<placement>()._isStart())
            {
                _isExplosed = true;
                idbox_explosion.SetActive(true);
            }
            
        }
        if (collision.gameObject.tag == "box")
        {
            Debug.Log("oui");

            if (GetComponent<placement>()._isStart())
            {
                Destroy(gameObject);

                GameObject explosion_cube = Instantiate(_cube_explosion, transform.position, Quaternion.Euler(0, 0, 0));
                explosion_cube.GetComponent<explosion_color>().index = GetComponent<colorscript>().cube_index();
            }

        }



    }
    public void box_explosee()
    {
        runSpeed = 0;
        _isExplosed = true;
    }
    public void start_timer()
    {
        timer.GetComponent<timer>().timer_start();
    }
    public void start_direction()
    {
        runSpeed = 300f;
        if (_direction == 0)
        {
            horizontal = 1;
            vertical = 0;
        }
        if (_direction == 1)
        {
            horizontal = 0;
            vertical = 1;
        }
        if (_direction == 2)
        {
            horizontal = -1;
            vertical = 0;
        }
        if (_direction == 3)
        {
            horizontal = 0;
            vertical = -1;
        }

    }

    void OnTriggerStay2D(Collider2D collision)
    {
<<<<<<< HEAD
        if (GetComponent<placement>()._isStart())
        {
            if (collision.gameObject.tag == "fleche haut")
            {
                if (ValeurAbsolue(transform.position.x % 128) > 60 && ValeurAbsolue(transform.position.x % 128) < 68 && ValeurAbsolue(transform.position.y % 128) > 60 && ValeurAbsolue(transform.position.y % 128) < 68 && CooldownEchangeur <= 0)
                {
                    vertical = 1 * multiplicateur;
                    horizontal = 0;
                    transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y);

                }
            }
            if (collision.gameObject.tag == "fleche gauche")
            {
                if (ValeurAbsolue(transform.position.x % 128) > 60 && ValeurAbsolue(transform.position.x % 128) < 68 && ValeurAbsolue(transform.position.y % 128) > 60 && ValeurAbsolue(transform.position.y % 128) < 68 && CooldownEchangeur <= 0)
                {
                    vertical = 0;
                    horizontal = -1 * multiplicateur;
                    transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y);
                }

            }
            if (collision.gameObject.tag == "fleche bas")
            {
                //Debug.Log(transform.position.x % 128);
                if (ValeurAbsolue(transform.position.x % 128) > 60 && ValeurAbsolue(transform.position.x % 128) < 68 && ValeurAbsolue(transform.position.y % 128) > 60 && ValeurAbsolue(transform.position.y % 128) < 68 && CooldownEchangeur <= 0)
                {
                    vertical = -1 * multiplicateur;
                    horizontal = 0;
                    transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y);

                }



            }
            if (collision.gameObject.tag == "fleche droite")
            {
                if (ValeurAbsolue(transform.position.x % 128) > 60 && ValeurAbsolue(transform.position.x % 128) < 68 && ValeurAbsolue(transform.position.y % 128) > 60 && ValeurAbsolue(transform.position.y % 128) < 68 && CooldownEchangeur <= 0)

                {
                    vertical = 0;
                    horizontal = 1 * multiplicateur;
                    transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y);


                }
            }
            if (collision.gameObject.tag == "echangeur")
            {
                //Debug.Log("yes");
                if (ValeurAbsolue(transform.position.x % 128) > 60 && ValeurAbsolue(transform.position.x % 128) < 68 && ValeurAbsolue(transform.position.y % 128) > 60 && ValeurAbsolue(transform.position.y % 128) < 68 && CooldownEchangeur <= 0)

                {
                    multiplicateur *= -1;
                    //Debug.Log(multiplicateur);
                    CooldownEchangeur = MaxCooldownEchangeur;

                    int i = 0;
                    while (fleches.Count != i)
                    {
                        if (multiplicateur < 0)
                        {
                            fleches[i].GetComponent<fleche_rotation>().switch_fleche();
                        }
                        else
                        {
                            fleches[i].GetComponent<fleche_rotation>().switch_fleche_retour();
                        }
                        i++;
                    }

                    int j = 0;
                    while (autre_cube.Count != j)
                    {
                        Debug.Log(j);
                        autre_cube[j].GetComponent<move>().switch_multiplicateur();

                        j++;
                    }

                }

            }
            if (collision.gameObject.tag == "levier_mur")
            {

                if (ValeurAbsolue(transform.position.x % 128) > 60 && ValeurAbsolue(transform.position.x % 128) < 68 && ValeurAbsolue(transform.position.y % 128) > 60 && ValeurAbsolue(transform.position.y % 128) < 68 && CooldownEchangeur <= 0)
                {
                    collision.GetComponent<levier_mural>().switch_levier();
                }
            }
=======
        if (collision.gameObject.tag == "fleche haut")
        {
            if (ValeurAbsolue(transform.position.x % 128) > 60 && ValeurAbsolue(transform.position.x % 128) < 68 && ValeurAbsolue(transform.position.y % 128) > 60 && ValeurAbsolue(transform.position.y % 128) < 68 && CooldownEchangeur <= 0)
            {
                vertical = 1 * multiplicateur;
                horizontal = 0;
                transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y);

            }
        }
        if (collision.gameObject.tag == "fleche gauche")
        {
            if (ValeurAbsolue(transform.position.x % 128) > 60 && ValeurAbsolue(transform.position.x % 128) < 68 && ValeurAbsolue(transform.position.y % 128) > 60 && ValeurAbsolue(transform.position.y % 128) < 68 && CooldownEchangeur <= 0)
            {
                vertical = 0;
                horizontal = -1 * multiplicateur;
                transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y);
            }

        }
        if (collision.gameObject.tag == "fleche bas")
        {
            //Debug.Log(transform.position.x % 128);
            if (ValeurAbsolue(transform.position.x % 128) > 60 && ValeurAbsolue(transform.position.x % 128) < 68 && ValeurAbsolue(transform.position.y % 128) > 60 && ValeurAbsolue(transform.position.y % 128) < 68 && CooldownEchangeur <= 0)
            {
                vertical = -1 * multiplicateur;
                horizontal = 0;
                transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y);

            }



        }
        if (collision.gameObject.tag == "fleche droite")
        {
            if (ValeurAbsolue(transform.position.x % 128) > 60 && ValeurAbsolue(transform.position.x % 128) < 68 && ValeurAbsolue(transform.position.y % 128) > 60 && ValeurAbsolue(transform.position.y % 128) < 68 && CooldownEchangeur <= 0)

            {
                vertical = 0;
                horizontal = 1 * multiplicateur;
                transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y);


            }
        }
        if (collision.gameObject.tag == "echangeur")
        {
            //Debug.Log("yes");
            if (ValeurAbsolue(transform.position.x % 128) > 60 && ValeurAbsolue(transform.position.x % 128) < 68 && ValeurAbsolue(transform.position.y % 128) > 60 && ValeurAbsolue(transform.position.y % 128) < 68 && CooldownEchangeur <= 0)

            {
                multiplicateur *= -1;
                Debug.Log(multiplicateur);
                CooldownEchangeur = MaxCooldownEchangeur;

                int i = 0;
                while(fleches.Count != i)
                {                    
                    if (multiplicateur < 0)
                    {
                        fleches[i].GetComponent<fleche_rotation>().switch_fleche();
                    }
                    else
                    {
                        fleches[i].GetComponent<fleche_rotation>().switch_fleche_retour();
                    }
                    i++;
                }

                int j = 0;
                while (autre_cube.Count != j)
                {
                    Debug.Log(j);
                    autre_cube[j].GetComponent<move>().switch_multiplicateur();

                    j++;
                }

            }

        }
        if (collision.gameObject.tag == "levier_mur")
        {
            
            if (ValeurAbsolue(transform.position.x % 128) > 60 && ValeurAbsolue(transform.position.x % 128) < 68 && ValeurAbsolue(transform.position.y % 128) > 60 && ValeurAbsolue(transform.position.y % 128) < 68 && CooldownEchangeur <= 0)
            {
                collision.GetComponent<levier_mural>().switch_levier();
            }
        }
>>>>>>> 68380a7... Init projet




<<<<<<< HEAD
            if (CooldownEchangeur > 0)
            {
                CooldownEchangeur -= Time.deltaTime;
            }


            if (collision.gameObject.tag == "teleport")
            {
                if (ValeurAbsolue(transform.position.x % 128) > 60 && ValeurAbsolue(transform.position.x % 128) < 68 && ValeurAbsolue(transform.position.y % 128) > 60 && ValeurAbsolue(transform.position.y % 128) < 68 && CooldownEchangeur <= 0)
                {

                }
            }
            if (collision.gameObject.tag == "crown" && _isExplosed)
            {
                Debug.Log("ici");
                if (collision.GetComponent<crown>().crown_index() == GetComponent<colorscript>().cube_index())
                {
                    _start_manager.GetComponent<start_manager>().points();
                    GameObject explosion_cube = Instantiate(_cube_explosion, transform.position, Quaternion.Euler(0, 0, 0));
                    explosion_cube.GetComponent<explosion_color>().index = GetComponent<colorscript>().cube_index();

                    Destroy(gameObject);


                }
            }

            else if (_isExplosed)
            {

                Destroy(gameObject);

                GameObject explosion_cube = Instantiate(_cube_explosion, transform.position, Quaternion.Euler(0, 0, 0));
                explosion_cube.GetComponent<explosion_color>().index = GetComponent<colorscript>().cube_index();
            }



        }
=======
                if (CooldownEchangeur > 0)
        {
            CooldownEchangeur -= Time.deltaTime;
        }


        if (collision.gameObject.tag == "teleport")
        {
            if (ValeurAbsolue(transform.position.x % 128) > 60 && ValeurAbsolue(transform.position.x % 128) < 68 && ValeurAbsolue(transform.position.y % 128) > 60 && ValeurAbsolue(transform.position.y % 128) < 68 && CooldownEchangeur <= 0)
            {

            }
        }
        if (collision.gameObject.tag == "crown" && _isExplosed)
        {
            Debug.Log("ici");
            if (collision.GetComponent<crown>().crown_index() == GetComponent<colorscript>().cube_index())
            {
                _start_manager.GetComponent<start_manager>().points();
                GameObject explosion_cube = Instantiate(_cube_explosion, transform.position, Quaternion.Euler(0, 0, 0));
                explosion_cube.GetComponent<explosion_color>().index = GetComponent<colorscript>().cube_index();

                Destroy(gameObject);
                

            }
        }

        else if (_isExplosed)
        {

            Destroy(gameObject);

            GameObject explosion_cube = Instantiate(_cube_explosion, transform.position, Quaternion.Euler(0, 0, 0));
            explosion_cube.GetComponent<explosion_color>().index = GetComponent<colorscript>().cube_index();
        }



>>>>>>> 68380a7... Init projet


    }
    public void switch_multiplicateur()
    {
        multiplicateur *= -1;
    }

}
