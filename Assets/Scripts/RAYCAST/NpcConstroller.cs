using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Adicionar
using UnityEngine.UI;
using TMPro;

public class NpcConstroller : MonoBehaviour
{
    public Transform objective;
    private NavMeshAgent agente;
    public bool follow = false;
    public bool activeMov;
    public bool finishMision;
    public Transform objective2;
    public GameObject puerta1;
    public GameObject puerta2;
    [SerializeField]
    public AudioClip sonidoWin;
    private AudioSource sound;      

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        sound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            agente.destination = objective.position;
        }
        if (finishMision == true)
        {
            agente.destination = objective2.position;
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name==("Righthand")&& follow == true && finishMision == false)
        {
            activeMov = false;
        }
        if (other.gameObject.name == ("Puerta28")&& follow == true && finishMision == false)
        {
            finishMision = true;
            follow = false;

            puerta1.transform.Rotate(0, 90, 0);
            puerta2.transform.Rotate(0, -90, 0);
            

        }
        if (other.gameObject.name == ("casillaGuardia")&& follow == false && finishMision == true)
        {
            activeMov = false;
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name ==("Righthand")&& follow == true && finishMision == false)
        {
            activeMov = true;

        }
        if (other.gameObject.name ==("casillaGuardia")&& follow == false && finishMision == true)
        {
            activeMov = true;
        }
        
    }
}

