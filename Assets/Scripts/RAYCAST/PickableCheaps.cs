using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableCheaps : MonoBehaviour
{
    private Transform Padre;
    private Transform palma;
    private float giro = 30;
    public bool grab;
    void Start()
    {
        //DATOS DE PLAYER
        Padre = GameObject.FindWithTag("Player").GetComponent<Transform>();
        palma = GameObject.Find("PalmaChris").GetComponent<Transform>();
    }
    private void Update()
    {
        if (grab == true)
        {
            transform.position = palma.position;
        }
        transform.Rotate(0, giro * Time.deltaTime, 0); //hacemos que gire el item en el eje Y
    }
}
