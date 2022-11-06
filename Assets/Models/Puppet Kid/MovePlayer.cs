
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour

{
    [SerializeField]
    private float speed = 9f;
    [SerializeField]
    private float speedRotate = 150f;
    [SerializeField]
    public float contador =0;

    void Update()
    {
        {
        transform.Translate(0, 0,Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.Rotate(0,Input.GetAxis("Horizontal") * speedRotate * Time.deltaTime,0);
        }
        if(contador == 6)
        {
            transform.position = new Vector3(0,160,0);
        }
        
    } 
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Camion"){
            transform.position = new Vector3(0,4,-90);
        }
    }
}
    
