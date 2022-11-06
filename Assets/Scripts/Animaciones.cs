using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animaciones : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    /*void Update()
    {
        bool walking = Input.GetKeyDown(KeyCode.LeftControl);
        animator.SetBool("walking", walking);
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetTrigger("Walk");
        }
    }*/
    [SerializeField]
    private float speed = 9f;
    [SerializeField]
    private float speedRotate = 150f;


    void Update()
    {
        {
            transform.Translate(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
            transform.Rotate(0, Input.GetAxis("Horizontal") * speedRotate * Time.deltaTime, 0);
        }
    }
}

