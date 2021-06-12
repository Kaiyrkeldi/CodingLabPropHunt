using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public static bool healing = false;
    private bool isheal = false;
    private Player healthScript;
    private float perktimer = 20f;
    private float currTimer = 0f;
    private Text perkText;

    void Start()
    {
        healthScript = GameManager.GetPlayer(this.gameObject.name);
        perkText = GameObject.Find("GM").GetComponent<GameManager_References>().Heal.GetComponent<Text>();
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
        else PropController.speed = 5f;
        if (jumpx2)
        {
            jumpForce = 4f;
        }

    }
    void Update()
    {
        if (wallHack) { GameObject.Find("GM").GetComponent<GameManager_References>().WH.SetActive(true);
            GameObject.Find("GM").GetComponent<GameManager_References>().Heal.SetActive(false);
            perkText = GameObject.Find("GM").GetComponent<GameManager_References>().WH.GetComponent<Text>();
        }
        if (healing)
        {
            perkText = GameObject.Find("GM").GetComponent<GameManager_References>().Heal.GetComponent<Text>();
            GameObject.Find("GM").GetComponent<GameManager_References>().WH.SetActive(false);
            GameObject.Find("GM").GetComponent<GameManager_References>().Heal.SetActive(true);
        }
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
            player.TakeDamage(5f);
        }

        if (Input.GetKeyDown(KeyCode.T) && !isBehind && wallHack)
        {
            isBehind = true;
            SetLayerRecursively(GameObject.FindGameObjectWithTag("Player"), 8);
            Invoke("WallHackOff", 5.0f);
        }

        if (isheal == false && Input.GetKeyDown(KeyCode.T) && healing)
        {
            isheal = true;
            currTimer = 0f;
            healthScript.ResetHealth();
        }

        if ((isheal || isBehind) && currTimer <= perktimer)
        {
            currTimer += 1 * Time.deltaTime;
            perkText.text = Math.Round((perktimer - currTimer), 2).ToString();
        }
        else
        {
            perkText.text = "Press T";
            isheal = false;
            isBehind = false;
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
    }
}
