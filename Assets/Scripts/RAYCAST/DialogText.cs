using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Adicionar
using UnityEngine.UI;
using TMPro;

public class DialogText : MonoBehaviour
{
    public TextMeshProUGUI dialogsTexts;
    public bool activeChat;
    //Atributos del Script
    private NpcConstroller Atributo;
    private CamaraInteractiveRAYCAST hit;
    

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
        Atributo = FindObjectOfType<NpcConstroller>();
        hit = FindObjectOfType<CamaraInteractiveRAYCAST>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activeChat)
        {
            
            StartDialogue();
            activeChat = false;
        }
        if (Input.GetKeyDown(KeyCode.X) && hit.hit.transform.name == "Guardia")// si se oprime X
        {
            if(dialogsTexts.text == lineas[index])//si el texto es pantalla esta completo
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
        foreach (var letra in lineas[index].ToCharArray())// Para cada letra dentro de nuestras lineas de texto
        {
            dialogsTexts.text += letra;                    //se a?ade a nuestro cuadro de texto 
            yield return new WaitForSeconds(textSpeed);     //cada cierto tiempo

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
            gameObject.SetActive(false);// se desactiva el cuadro de dialogo al que esta vinculado este script
            Atributo.follow = true;
        }
    }
}
