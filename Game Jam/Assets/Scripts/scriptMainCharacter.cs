using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scriptMainCharacter : MonoBehaviour
{
    private Rigidbody2D rbd;
    private Animator anim;
    public GameObject pe;
    public float velocidade = 3;
    public float distancia = 0.2f;
    private bool direita = true;
    private float jumpForce = 500;
    public LayerMask mascara;
    public LayerMask maskEnemy;
    private float x;
    RaycastHit2D hit;
    RaycastHit2D hitEnemy;

    private bool floor;
    //Pausar o jogo
    private bool pausado = false;

    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void mover()
    {
        x = Input.GetAxis("Horizontal");
        rbd.velocity = new Vector2(x * velocidade, rbd.velocity.y);
        virar();
    }

    private void virar()
    {
        /*andar para esquerda*/
        if (direita && x < 0 || !direita && x > 0)
        {
            /*0 Posi��o X e 180 Posi��o Y*/
            transform.Rotate(new Vector2(0, 180));
            direita = !direita;
        }
    }

  

    private void pular()
    {
        //Pular
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (hit.collider != null)
                rbd.AddForce(new Vector2(0, jumpForce));


        }
    }


    // Update is called once per frame
    void Update()
    {
        mover();
        //anima();
       // pisarPlataformaSemMover();
        pular();
        //eleminarInimigo();



        //pausar o jogo
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (pausado)
            {
                pausado = false;
                Time.timeScale = 1;

            }
            else
            {
                pausado = true;
                Time.timeScale = 0;

            }

        }

    }
}
