using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    private Animator ch_animator;
    // Start is called before the first frame update
    public Transform playerBody;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Transform camTransform;
    public Camera flyCam;

    float xRot = 0f;
    void Start()
    {
        ch_animator = GetComponent<Animator>();
        //flyCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -75f, 75f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ch_animator.SetLookAtWeight(.3f, .3f, .3f);
            ch_animator.SetLookAtPosition(camTransform.position);
            cam.fieldOfView = 15f;
            mouseSensitivity = 20f;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            mouseSensitivity = 100f;
            cam.fieldOfView = 60f;
        }
    }
}
