using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Npc : MonoBehaviour
{
    public float speedMovement = 5.0f;
    public float speedRotation = 200.0f;
    private Animator anim;
    public NpcConstroller atributosDelGuardia;
    private int y;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        atributosDelGuardia = FindObjectOfType<NpcConstroller>();
            
    }

    // Update is called once per frame
    void Update()
    {
        if (atributosDelGuardia.activeMov )
        {
            y = 1;
        }
        else
        {
            y = 0;
        }
        anim.SetFloat("SpeedY", y);
    }
}
