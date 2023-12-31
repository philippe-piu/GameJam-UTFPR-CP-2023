using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scriptMainCharacter : MonoBehaviour
{
    
    public const int defautJump = 1;
    private float jumpCount = defautJump;

    public const int defautAtk = 1;
    private float atkCount = defautAtk;

    private Rigidbody2D rbd;
    private Animator anim;
    public GameObject pe;
    public float velocidade = 3;
    public float distancia = 0.2f;
    private bool direita = true;
    private int jumpForce = 500;

    public LayerMask mascara;
    public LayerMask inimigo;
    private float x;
  
    RaycastHit2D hit;
    RaycastHit2D hitEnemy;

    private bool floor;
    //Pausar o jogo
    private bool pausado = false;

    public Transform atkCheck;
    public float radiusAtk = 5;
    public LayerMask layerEnemy;
    float timeNextAtk;
    

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

    private void anima()
    {
        
        /*Anima��o para se mover*/
        if (x == 0)
            anim.SetBool("parar", true);

        else
            anim.SetBool("parar", false);
    }

    private void animaPulo()
    {
        
        if (jumpCount > 0)
        {
            anim.SetBool("pulo", false);
            Debug.Log(jumpCount);

        }
        else
        {
            anim.SetBool("pulo", true);
            Debug.Log(jumpCount);
        }
    }
   
    private void pular()
    {
        //Pular

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            rbd.AddForce(new Vector2(0, jumpForce));      
            jumpCount--;
        }

        
     
    }
    private void atacar()
    {
        //Pular

        if (Input.GetKeyDown(KeyCode.Z) )
        {
            anim.SetTrigger("atacar");
            atkCount--;

          
        }

        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            jumpCount = defautJump;


        }

        

    }

   


    // Update is called once per frame
    void Update()
    {
        mover();
        anima();
        animaPulo();
        //OnDrawGizmosSelected();
       // pisarPlataformaSemMover();
        pular();
        atacar();
        



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
