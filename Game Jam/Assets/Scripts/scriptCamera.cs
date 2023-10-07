using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptCamera : MonoBehaviour
{
    //MainCharacter � o meu personagem principal estou fazendo uma refer�ncia ele aqui para camera o seguir
    public GameObject MainCharacter;
    //Posi��o da c�mera para o personagem principal
    private float offsetY = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Mantendo a profundidade da c�mera para o personagem
        Vector3 posicao = new Vector3(MainCharacter.transform.position.x, MainCharacter.transform.position.y + offsetY, -10);
        transform.position = posicao;
    }
}
