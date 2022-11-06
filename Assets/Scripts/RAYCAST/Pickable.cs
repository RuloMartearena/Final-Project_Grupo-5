using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : Interactable
{
    private Transform Padre;
    private Transform palma;
    public float giro = 30;
    public bool grab;
    
    void Start()
    {
        //DATOS DE PLAYER
        Padre = GameObject.FindWithTag("Player").GetComponent<Transform>();
        palma = GameObject.Find("PalmaChris").GetComponent<Transform>();
    }
    private void Update()
    {
        if(grab == true)
        {
            transform.position = palma.position;
            transform.rotation = palma.rotation;
        }
        transform.Rotate(0, giro * Time.deltaTime, 0); //hacemos que gire el item en el eje Y
    }
    public override void Interact()// sobre escrive el metodo "interact" que esta siendo heredado de "Interactable"
    {
        base.Interact();
        transform.SetParent(Padre);
        grab = true;
        
    }

}
