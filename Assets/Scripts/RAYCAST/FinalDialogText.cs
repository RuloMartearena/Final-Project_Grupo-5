using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalDialogText : MonoBehaviour
{
    public TextMeshProUGUI dialogsTexts;
    private CamaraInteractiveRAYCAST hit;
    //Atributos del Script

    private FinalBossController propsBoss;
    public bool activeChat;

    //creamos un array de lineas(estos contendran los dialogos a mostrar)
    public string[] lineas;
    public float textSpeed = 0.1f;

    //Se usa para saber en que linea de codigo trabajamos
    int index;
    private Player props;
    public GameObject finalMision;

    void Start()
    {
        props = FindObjectOfType<Player>();
        dialogsTexts.text = string.Empty;

        propsBoss = FindObjectOfType<FinalBossController>();
        hit = FindObjectOfType<CamaraInteractiveRAYCAST>();


    }

    // Update is called once per frame
    void Update()
    {
        if (propsBoss.activeDialog)
        {
            activeChat = true;
            propsBoss.activeDialog = false;
        }
        if (activeChat)
        {

            StartDialogue();
            activeChat = false;
            
        }
        if (dialogsTexts.text == lineas[index])//si el texto es pantalla esta completo
        {

            nextLine();                        // muestra el siguiente texto
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
            dialogsTexts.text += letra;                    //se añade a nuestro cuadro de texto 
            yield return new WaitForSeconds(textSpeed);     //cada cierto tiempo

        }
    }
    public void nextLine()
    {
        if (index < lineas.Length - 1) // cuando quedan lineas por escribir
        {
            index++;
            dialogsTexts.text = string.Empty;
            StartCoroutine(EscribirLinea());
        }
        else
        {
            gameObject.SetActive(false);// se desactiva el cuadro de dialogo al que esta vinculado este script
            propsBoss.activePursue = true;
            finalMision.SetActive(true);

        }
    }
}
