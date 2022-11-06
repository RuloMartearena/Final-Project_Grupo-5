using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavePickable : Interactable
{
    
    private Transform libro1;
    private Transform libro2;
    private Transform libro3;
    private Transform libro4;
    private Transform libro5;

    private Pickable grabBook1;
    private Pickable grabBook2;
    private Pickable grabBook3;
    private Pickable grabBook4;
    private Pickable grabBook5;

    private Transform otroPadre;
    private Transform anteriorPadre;

    private Transform sobreMesa1;
    private Transform sobreMesa2;
    private Transform sobreMesa3;
    private Transform sobreMesa4;
    private Transform sobreMesa5;

    private GameObject childToFind;

    public int numDeObjectivos;
    void Start()
    {
        libro1 = GameObject.Find("Libro1").GetComponent<Transform>();
        libro2 = GameObject.Find("Libro2").GetComponent<Transform>();
        libro3 = GameObject.Find("Libro3").GetComponent<Transform>();
        libro4 = GameObject.Find("Libro4").GetComponent<Transform>();
        libro5 = GameObject.Find("Libro5").GetComponent<Transform>();

        grabBook1 = GameObject.Find("Libro1").GetComponent<Pickable>();
        grabBook2 = GameObject.Find("Libro2").GetComponent<Pickable>();
        grabBook3 = GameObject.Find("Libro3").GetComponent<Pickable>();
        grabBook4 = GameObject.Find("Libro4").GetComponent<Pickable>();
        grabBook5 = GameObject.Find("Libro5").GetComponent<Pickable>();


        numDeObjectivos = GameObject.FindGameObjectsWithTag("Book").Length;

        //DATOS DEL OBJETIVO
        otroPadre = GameObject.Find("Mesa").GetComponent<Transform>();
        sobreMesa1 = GameObject.Find("SobreMesa1").GetComponent<Transform>();
        sobreMesa2 = GameObject.Find("SobreMesa2").GetComponent<Transform>();
        sobreMesa3 = GameObject.Find("SobreMesa3").GetComponent<Transform>();
        sobreMesa4 = GameObject.Find("SobreMesa4").GetComponent<Transform>();
        sobreMesa5 = GameObject.Find("SobreMesa5").GetComponent<Transform>();
        anteriorPadre = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        try
        {
            childToFind = anteriorPadre.GetChild(14).gameObject;
        }catch(UnityException ex)
        {
        }

    }

    public override void Unnteract()// sobre escrive el metodo "interact" que esta siendo heredado de "Interactable"
    {
        base.Unnteract();
        numDeObjectivos--;
        if (childToFind.name == "Libro1")
        {
            libro1.transform.SetParent(otroPadre);
            libro1.transform.position = sobreMesa1.position;
            libro1.transform.rotation = sobreMesa1.rotation;
            grabBook1.grab = false;
            grabBook1.giro = 30;

        }
        else if (childToFind.name == "Libro2")
        {
            libro2.transform.SetParent(otroPadre);
            libro2.transform.position = sobreMesa2.position;
            libro2.transform.rotation = sobreMesa2.rotation;
            grabBook2.grab = false;
            grabBook2.giro = 30;
        }
        else if (childToFind.name == "Libro3")
        {
            libro3.transform.SetParent(otroPadre);
            libro3.transform.position = sobreMesa3.position;
            libro3.transform.rotation = sobreMesa3.rotation;
            grabBook3.grab = false;
            grabBook3.giro = 30;
        }
        else if (childToFind.name == "Libro4")
        {
            libro4.transform.SetParent(otroPadre);
            libro4.transform.position = sobreMesa4.position;
            libro4.transform.rotation = sobreMesa4.rotation;
            grabBook4.grab = false;
            grabBook4.giro = 30;
        }
        else if (childToFind.name == "Libro5")
        {
            libro5.transform.SetParent(otroPadre);
            libro5.transform.position = sobreMesa5.position;
            libro5.transform.rotation = sobreMesa5.rotation;
            grabBook5.grab = false;
            grabBook5.giro = 30;
        }
    }
}
