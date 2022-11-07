using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcVendedor : Interactable
{
    public bool take; // indica que el jugador ya tiene la bolsa
    public bool buyActive; // activa la compra, si esta en true te da la bolsa
    private DialogText3 Dialog; // contiene el texto de la mision 3
    [SerializeField]
    public GameObject Chips_Bag; // Objeto que se instancia una vez que se activa la compra
    private Transform Father; // Establece el objeto que sera padre de la bolsa
    private int chipBag = 0; // Se usa como contador para indicar la cantidad de "bolsa de papas" que se crean

    void Start()
    {
        // Extrae el transform del game object con tag "Player"
        Father = GameObject.FindWithTag("Player").GetComponent<Transform>();
        // Extrae el componenete DialogText3 del game object "DialogMisionThree"
        Dialog = GameObject.Find("DialogMisionThree").GetComponent<DialogText3>();
    }

    void Update()
    {
        // Si (la compra se activa y no hay ninguna bolsa)
        if(buyActive == true && chipBag == 0 )
        {
            // Crea una objeto Chips_Bag con la posicion del jugador, cambia el valor de buyActive para que no entre en bucle, valor de take para que no se instancie
            // infinitamente y aumenta el contador de chipBag en 1
            Instantiate(Chips_Bag, new Vector3(Father.transform.position.x, Father.transform.position.y+1, Father.transform.position.z), Father.transform.rotation);
            buyActive = false;
            take = true;
            chipBag++; // cantidad de bolsa de papas
        }
    }

    public override void Interact() // sobre escribe el metodo "interact" que esta siendo heredado de "Interactable"
    {
        // Cuando se aprieta la "e" en el vendedor {1}. Desde este script se controla la activacion del dialogo 3
        // Una vez que se termina con el dialogo desde DialogText3 se modifica el valor de la variable buyActive a true y se desactiva el dialogo
        base.Interact();
        Dialog.activeChat = true; // {1} activa el dialogo entre el player y el vendedor
    }
}
