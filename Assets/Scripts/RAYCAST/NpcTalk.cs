using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcTalk : Interactable
{
    public bool cheapShare; // Se activa con la "e" y determina si se "compartio" papas con los personajes
    public bool active = false; // determina si se interacciono con un personaje teniendo la bolsa de papas
    private NpcVendedor propsV; // se usa para llamar a los componentes del script NpcVendedor
    private Player props; // se usa para llamar a los componentes del script Player
    [SerializeField]
    // se usa para instanciar un game object de tipo chip en los personajes una vez que se interactua con ellos mientras se sostiene la bolsa de papas
    public GameObject Chip; 
    
    void Start()
    {
        // define a props y propsV como objetos de tipo Player y NpcVendedor para poder manejar sus atributos desde este script
        props = FindObjectOfType<Player>();
        propsV = FindObjectOfType<NpcVendedor>();
    }

    void Update()
    {
        // si (se comparte la papa y no se interactuo con el personaje y estas sosteniendo la bolsa de papas)
        if (cheapShare == true && active == false && propsV.take == true)
        {
            // Se instancia un papa en el personaje con el que se interactua mientras tengas la bolsa de papas
            Instantiate(Chip, new Vector3(transform.position.x,transform.position.y + 2.1f, transform.position.z),transform.rotation);
            cheapShare = false;
            active = true; // cambia su valor haciendo que no se pueda interactuar con ese personaje y por ende que no se pueda compartir papas con el
            props.missionThreeCount++; // aumenta el contador de la mision para que esta se complete
        }
    }

    public override void Interact() // sobre escribe el metodo "interact" que esta siendo heredado de "Interactable"
    {
        base.Interact();
        cheapShare = true; // hace que la variable cheapShare del personaje con el que se esta interactuando cambie a true
    }
}
