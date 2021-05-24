using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseMovement : MonoBehaviour
{
    private CharacterController ch_controller;
    private Animator ch_animator;
    private float speed = 1f;
    Vector3 velocity;
    public float gravity = -9.81f;
    // Start is called before the first frame update
    void Start()
    {
        ch_controller = GetComponent<CharacterController>();
        ch_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        ch_controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        ch_controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            ch_animator.SetBool("Walk", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 4f;
                ch_animator.SetBool("Run", true);
            }
            else
            {
                speed = 1f;
                ch_animator.SetBool("Run", false);
            }
        }
        else
        {
            ch_animator.SetBool("Walk", false);
            ch_animator.SetBool("Run", false);
        }
    }
}
