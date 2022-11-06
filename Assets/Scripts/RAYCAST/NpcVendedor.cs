using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcVendedor : Interactable
{
    public bool take;
    public bool buyActive;
    private DialogText3 Dialog;
    [SerializeField]
    public GameObject Chips_Bag;
    private Transform Father;
    private int chipBag = 0;

    // Start is called before the first frame update
    void Start()
    {
        Father = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Dialog = GameObject.Find("DialogMisionThree").GetComponent<DialogText3>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(buyActive == true && chipBag == 0 )
        {
            Instantiate(Chips_Bag, new Vector3(Father.transform.position.x, Father.transform.position.y+1, Father.transform.position.z), Father.transform.rotation);
            
            buyActive = false;
            take = true;
            chipBag++;
        }
        
    }
    public override void Interact()// sobre escrive el metodo "interact" que esta siendo heredado de "Interactable"
    {
        base.Interact();
        Dialog.activeChat = true;
        
        
    }
}
