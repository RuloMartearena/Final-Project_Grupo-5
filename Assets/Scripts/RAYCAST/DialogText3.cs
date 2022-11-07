using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Adicionar
using UnityEngine.UI;
using TMPro;

public class DialogText3 : MonoBehaviour
{
    public TextMeshProUGUI dialogsTexts;
    public bool activeChat; // --- chat activo ---
    private CamaraInteractiveRAYCAST hit;

    //Atributos del Script
    private NpcVendedor propsBuy;

    //creamos un array de lineas(estos contendran los dialogos a mostrar)
    public string[] lineas;
    public float textSpeed = 0.1f;

    //Se usa para saber en que linea de codigo trabajamos
    int index;
    private Player props;
    
    void Start()
    {
        props = FindObjectOfType<Player>();
        dialogsTexts.text = string.Empty;
        propsBuy = FindObjectOfType<NpcVendedor>();
        hit = FindObjectOfType<CamaraInteractiveRAYCAST>();
    }

    void Update()
    {
        if (activeChat)
        {
            StartDialogue();
            activeChat = false;
        }

        if (Input.GetKeyDown(KeyCode.X) && hit.hit.transform.name == "Vendedor") // si se oprime X
        {
            if(dialogsTexts.text == lineas[index]) //si el texto es pantalla esta completo
            { 
                nextLine();                        // muestra el siguiente texto
            }
            else
            {
                StopAllCoroutines();               // detiene la corrutina escribir linea
                dialogsTexts.text = lineas[index]; //Completa de forma automatica el texto
            }
        }
    }

    //Cuando se llame este metodo se activara la corrutina
    private void StartDialogue()
    {
        index = 0;
        StartCoroutine(EscribirLinea());
    }

    IEnumerator EscribirLinea()
    {
        foreach (var letra in lineas[index].ToCharArray()) // Para cada letra dentro de nuestras lineas de texto
        {
            dialogsTexts.text += letra;                    //se agrega a nuestro cuadro de texto 
            yield return new WaitForSeconds(textSpeed);    //cada cierto tiempo
        }
    }

    public void nextLine()
    {
        if(index < lineas.Length - 1) // cuando quedan lineas por escribir
        {
            index++;
            dialogsTexts.text = string.Empty;
            StartCoroutine(EscribirLinea());
        }
        else
        {
            propsBuy.buyActive = true; // --- setea el valor de buyActive a true ---
            gameObject.SetActive(false); // se desactiva el cuadro de dialogo al que esta vinculado este script
        }
    }
}
