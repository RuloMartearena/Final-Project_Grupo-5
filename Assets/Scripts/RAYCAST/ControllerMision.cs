using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Adicionar
using UnityEngine.UI;
using TMPro;

public class ControllerMision : MonoBehaviour
{
    //Inicializacion para mision1
    [SerializeField]
    public TextMeshProUGUI textoMision_1;
    private NpcConstroller atributoDelNpc;

    //Inicializacion para mision2
    [SerializeField]
    public TextMeshProUGUI textoMision_2;
    private LeavePickable mision_2;
    public int numDeObjectivos;

    //Inicializacion para mision3
    private Player props;
    [SerializeField]
    public TextMeshProUGUI textoMision_3;

    public Player propsPlayer;

    //Inicializacion para mision4

    [SerializeField]
    public TextMeshProUGUI textoMision_4;


    // Start is called before the first frame update
    void Start()
    {
        //Declaraciones para mision 1
        textoMision_1.text = "Busca al guardia para que abra tu aula";
        atributoDelNpc = GameObject.Find("Guardia").GetComponent<NpcConstroller>();

        //Declaraciones para mision 2
        mision_2 = GameObject.Find("Mesa").GetComponent<LeavePickable>();
        textoMision_2.text = "solo un punto" + "(restantes: " + mision_2.numDeObjectivos;

        //Declaraciones para mision 3
        propsPlayer = FindObjectOfType<Player>();
        
        textoMision_3.text = "Compra y comparte tus chips con amigos"+ propsPlayer.missionThreeCount;
    }
    
    void Update()
    {
        //Condicionales de mision 1
        if (atributoDelNpc.finishMision == true)
        {
            textoMision_1.text = "Mission 1 Complete";
            propsPlayer.missionOne = true;
        }

        //Condicionales de mision 2
        if(mision_2.numDeObjectivos > 0)
        {
            textoMision_2.text = "Encuentra los libros" + "(restantes: " + mision_2.numDeObjectivos+" )";
        }
        if (mision_2.numDeObjectivos == 0)
        {
            textoMision_2.text = "Mission 2 Complete";
            propsPlayer.missionTwo = true;
        }
        //Condicionales de mision 3
        if(propsPlayer.missionThreeCount <= 5)
        {
            textoMision_3.text = "Compra y comparte tus chips con (" + propsPlayer.missionThreeCount+"/5 amigos)";
        }
        if(propsPlayer.missionThreeCount == 5)
        {
            textoMision_3.text = "Mission 3 Complete";
            propsPlayer.missionThree = true;
            GameObject childToFind = propsPlayer.transform.GetChild(14).gameObject;
            if(childToFind.name == "Chips_Bag(Clone)")
            {
                Destroy(childToFind);
            }
            

        }
        //Condicionales de mision 4
        if(propsPlayer.missionFour == false)
        {
            textoMision_4.text = "Enciende el proyector del Anfiteatro";
        }
        else
        {
            textoMision_4.text = "Mission 4 Complete";
        }
    }
}
