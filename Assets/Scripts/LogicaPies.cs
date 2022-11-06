using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPies : MonoBehaviour
{
    public MovementPlayer movementPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        movementPlayer.isJump = true;
    }

    private void OnTriggerExit(Collider other)
    {
        movementPlayer.isJump = false;

    }
}
