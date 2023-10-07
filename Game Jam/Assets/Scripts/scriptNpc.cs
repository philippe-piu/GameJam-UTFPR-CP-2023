using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class scriptNpc : MonoBehaviour
{
    public float velocidade = 2;
    private Rigidbody2D rbd;
    public LayerMask mascara;
    public LayerMask maskCharacter;
    private float distancia = 0.6f;    
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //rbd.velocity = new Vector2(-1, 0) * velocidade;
        rbd.velocity = new Vector2(velocidade, 0);

        RaycastHit2D hit;
        RaycastHit2D hitCharacter;
        hit = Physics2D.Raycast(transform.position, transform.right, distancia, mascara);
        hitCharacter = Physics2D.Raycast(transform.position, transform.right, distancia, maskCharacter);

        if (hit.collider != null)
        {
            velocidade = velocidade * -1;
            //rbd.velocity = rbd.velocity * -1;
            // Debug.Log("entrou");
            rbd.velocity = new Vector2(velocidade, 0);
            transform.Rotate(new Vector2(0, 180));
        }

        if (hitCharacter.collider != null)
        {
            Destroy(hitCharacter.collider.gameObject);
            SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
        }
    }
}

