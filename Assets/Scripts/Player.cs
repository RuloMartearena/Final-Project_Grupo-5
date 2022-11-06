using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speedMovement = 5.0f;
    public float speedRotation = 200.0f;
    private Animator anim;
    public float x, y;
    public bool missionOne = false;
    public bool missionTwo = false;
    public bool missionThree = false;
    public int missionThreeCount = 0;
    public bool missionFour = false;
    public bool soundOne = false;
    public bool soundTwo = false;
    public bool soundThree = false;
    public bool soundFour = false;
    [SerializeField]
    public AudioClip soundWin;
    private AudioSource sound;
    private bool activeSound;
   
  
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * speedRotation, 0);
        transform.Translate(0, 0, y * Time.deltaTime * speedMovement);

        anim.SetFloat("SpeedX", x);
        anim.SetFloat("SpeedY", y);
        //instrucciones del sonido

        if (missionOne == true && soundOne == false)
        {
            sound.PlayOneShot(soundWin, 1f);
            soundOne = true;
        }
        if (missionTwo == true && soundTwo == false)
        {
            sound.PlayOneShot(soundWin, 1f);
            soundTwo = true;
        }
        if (missionThree == true && soundThree == false)
        {
            sound.PlayOneShot(soundWin, 1f);
            soundThree = true;
        }
        if (missionFour == true && soundFour == false)
        {
            sound.PlayOneShot(soundWin, 1f);
            soundFour = true;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Salida")
        {
            SceneManager.LoadScene(4);
        }
    }
    
}
