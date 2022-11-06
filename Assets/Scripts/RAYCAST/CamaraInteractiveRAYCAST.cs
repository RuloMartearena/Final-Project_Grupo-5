using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraInteractiveRAYCAST : MonoBehaviour
{
    private new Transform camera;
    private bool sostiene = false;
    private bool dejar;
    public float rayDistance=2;
    public RaycastHit hit;
    private RaycastHit hit2;
    void Start()
    {
        camera = transform.Find("Camera");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(camera.position,camera.forward*rayDistance, Color.red);
        if (Input.GetButtonDown("Interactable"))
        {
            if (Physics.Raycast(camera.position, camera.forward, out hit, rayDistance, LayerMask.GetMask("Interactable2")))
            {
                Debug.Log(hit.transform.name);
                hit.transform.GetComponent<Interactable>().Interact();//con este codigo activara el codigo "interact" del scritp "Interactable"
            }
            if (Physics.Raycast(camera.position, camera.forward, out hit, rayDistance, LayerMask.GetMask("Interactable")))
            {
                Debug.Log(hit.transform.name);
                hit.transform.GetComponent<Interactable>().Interact();//con este codigo activara el codigo "interact" del scritp "Interactable"
                
            }
            //Debug.Log(sostiene);
        }
        if (Input.GetButtonDown("Interactable"))
        {
            if (Physics.Raycast(camera.position, camera.forward, out hit, rayDistance, LayerMask.GetMask("Interactable2")) )
            {
                //Debug.Log(hit.transform.name);
                hit.transform.GetComponent<Interactable>().Unnteract();//con este codigo activara el codigo "Unnteract" del scritp "Interactable"
                
            }
            
        }
    }
}
