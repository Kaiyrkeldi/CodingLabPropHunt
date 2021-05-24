using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController ch_controller;
    private Animator ch_animator;
    private float speed = 5f;
    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;
    Vector3 velocity;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    // Start is called before the first frame update
    void Start()
    {
        ch_controller = GetComponent<CharacterController>();
        ch_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ch_controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (ch_controller.isGrounded) { ch_animator.ResetTrigger("Jump");
            ch_animator.SetBool("Fall", false);
        }
        if (!ch_controller.isGrounded) ch_animator.SetBool("Fall", true);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        ch_controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        ch_controller.Move(velocity * Time.deltaTime);

        if (x != 0 || z != 0)
        {
            ch_animator.SetBool("Walk", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = sprintSpeed;
                ch_animator.SetBool("Run", true);
            }
            else
            {
                speed = moveSpeed;
                ch_animator.SetBool("Run", false);
            }
        }
        else
        {
            ch_animator.SetBool("Walk", false);
            ch_animator.SetBool("Run", false);
        }

        if (Input.GetButtonDown("Jump") && ch_controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            ch_animator.SetTrigger("Jump");
        }
    }
}
