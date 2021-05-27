using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PropMotor : MonoBehaviour
{

    [SerializeField]
    private Camera cam;
    public Camera flyCamera;
    private Rigidbody rb;
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 camRotation = Vector3.zero;
    private Vector3 jump;
    public float jumpForce = 2f;
    private bool isGrounded;
    private bool isBehind = false;
    public static bool wallHack = false;
    public static bool speedx2 = false;
    public static bool jumpx2 = false;

    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Prop");
        foreach (GameObject player in players)
        {
            SetLayerRecursively(player, 7);
        }
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        flyCamera.enabled = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Length > 0)
        {
            ContactPoint contact = collision.contacts[0];
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.5)
            {
                isGrounded = true;           //collision was from below
            }
        }
    }
    public void Move(Vector3 _vel)
    {
        velocity = _vel;
    }

    public void Rotate(Vector3 _rot)
    {
        rotation = _rot;
    }

    public void RotateCam(Vector3 _camRot)
    {
        camRotation = _camRot;
    }

    void FixedUpdate()
    {
        PerformMove();
        PerformRotation();
        if (speedx2)
        {
            PropController.speed = 10f;   
        }
        if (jumpx2)
        {
            jumpForce = 4f;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Player player = GameManager.GetPlayer(this.gameObject.name);
            player.TakeDamage(100f);
        }

        if (Input.GetKeyDown(KeyCode.T) && !isBehind && wallHack)
        {
            isBehind = true;
            SetLayerRecursively(GameObject.FindGameObjectWithTag("Player"), 8);
            Invoke("WallHackOff", 2.0f);
        }

    }
    void PerformMove()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam != null)
        {
            cam.transform.Rotate(camRotation);
        }
    }

    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        if (null == obj)
        {
            return;
        }

        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            if (null == child)
            {
                continue;
            }
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }

    void WallHackOff()
    {
        SetLayerRecursively(GameObject.FindGameObjectWithTag("Player"), 7);
        //isBehind = false;
        Invoke("SetBH", 10.0f);
    }
    void SetBH()
    {
        isBehind = false;
    }
}
