using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactuar : Interactable
{
    [SerializeField]
    public GameObject luzObjeto;
    public bool luz;
    public bool luzOnOff = true;
    public Player propsPlayer;

    public void Start()
    {
        propsPlayer = FindObjectOfType<Player>();
    }
    public void onOffLuz()
{
    propsPlayer.missionFour = true;
    luzObjeto.SetActive(true);
    }
    public override void Interact()
    {
        base.Interact();
        onOffLuz();
    }
}
