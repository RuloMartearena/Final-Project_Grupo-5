using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class FinalBossController : MonoBehaviour
{
    public Transform objective;
    private NavMeshAgent agente;
    public bool follow = false;
    public bool activeMov = false;
    private Player propsPlayer;
    private Animator anim;
    private int y;
    public bool activeDialog = false;
    public bool activePursue = false;
    public bool activeMissionFive = false;
    [SerializeField]
    public GameObject videoPlay;
    private AudioSource sound;
    [SerializeField]
    public AudioClip Run;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        propsPlayer = FindObjectOfType<Player>();
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(propsPlayer.missionOne == true && propsPlayer.missionTwo == true && propsPlayer.missionThree == true && propsPlayer.missionFour == true && activeMissionFive == false)
        {
            activeMissionFive = true;
            activeDialog = true;
            
            
        }
        if (activePursue == true)
        {
            follow = true;
            activeMov = true;
            activePursue = false;
            sound.PlayOneShot(Run, 1f);
        }
        if (follow)
        {
            agente.destination = objective.position;
        }
        if (activeMov)
        {
            y = 1;
        }
        else
        {
            y = 0;
        }
        anim.SetFloat("SpeedY", y);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name ==("Christian"))
        {
            SceneManager.LoadScene(3);
        }
    }
}
