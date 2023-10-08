using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newDialogo : MonoBehaviour
{
    public Image dialogo;
    private GameObject NPC;
    [Range(0.1f, 10.0f)] public float distancia = 3;
    void Start()
    {
        dialogo.enabled = false;
        NPC = GameObject.FindWithTag("Player");
    }

 
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, NPC.transform.position) < distancia)
        {
            dialogo.enabled = true;
        }
        else
        {
            dialogo.enabled = false;
        }

    }
}
