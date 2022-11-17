using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    [Header("Player Movement")]
    public float moveSpeed;
    public float jumpForce;

    [Header("Camera")]
    public float lookSensitivity;
    public float maxLookX;
    public float minLookX;
    private float rotationX;

    private Camera camera;
    private Rigidbody rb;


    void Awake()
    {
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Move();
        CameraLook();

        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        
        Vector3 dir = (transform.right * x) + (transform.forward * z);
        dir.y = rb.velocity.y;

        //rb.velocity = new Vector3(x, rb.velocity.y, z);
    }

    void CameraLook()
    {
        float y =  Input.GetAxis("Mouse X") * lookSensitivity;
        rotationX += Input.GetAxis("Mouse Y") * lookSensitivity;

        rotationX = Mathf.Clamp(rotationX, minLookX, maxLookX);

        camera.transform.localRotation = Quaternion.Euler(-rotationX,0,0);
        transform.eulerAngles += Vector3.up * y;
    }

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray, 1.1f))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
