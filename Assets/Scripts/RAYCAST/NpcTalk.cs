using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcTalk : Interactable
{
    public bool cheapShare;
    public bool active = false;
    private NpcVendedor propsV;
    [SerializeField]
    public GameObject Chip;
    private Player props;
    void Start()
    {
        props = FindObjectOfType<Player>();
        propsV = FindObjectOfType<NpcVendedor>();
    }
    // Update is called once per frame
    void Update()
    {
        if (cheapShare == true && active == false && propsV.take == true)
        {
            Instantiate(Chip, new Vector3(transform.position.x,transform.position.y + 2.1f, transform.position.z),transform.rotation);
            cheapShare = false;
            active = true;
            props.missionThreeCount++;
        }
    }
    public override void Interact()// sobre escrive el metodo "interact" que esta siendo heredado de "Interactable"
    {
        base.Interact();
        cheapShare = true;
    }
}
