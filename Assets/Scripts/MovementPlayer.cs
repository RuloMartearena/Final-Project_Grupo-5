using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float speedMovement = 5.0f;
    public float speedRotation = 200.0f;

    private Animator anim;
    public float x, y;
    
    public Rigidbody rb;
    public float jumpForce = 5f;
    public bool isJump;    


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        transform.Rotate(0, x * Time.deltaTime * speedRotation, 0);
        transform.Translate(0, 0, y * Time.deltaTime * speedMovement);
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");        

        anim.SetFloat("SpeedX", x);
        anim.SetFloat("SpeedY", y);

        if (isJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("Salto", true);
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
            anim.SetBool("TocoSuelo", true);
        }
        else
        {
            EstoyCayendo();
        }
    }

    public void EstoyCayendo()
    {
        anim.SetBool("TocoSuelo", false);
        anim.SetBool("Salto", false);
    }
}
