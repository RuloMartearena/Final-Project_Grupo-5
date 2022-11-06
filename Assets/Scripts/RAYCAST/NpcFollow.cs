using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcFollow : Interactable
{
    
    private DialogText Dialog;

    void Start()
    {
        Dialog = FindObjectOfType<DialogText>();
    }
    public override void Interact()// sobre escrive el metodo "interact" que esta siendo heredado de "Interactable"
    {
        base.Interact();
        Dialog.activeChat = true;   
    }
    
}
