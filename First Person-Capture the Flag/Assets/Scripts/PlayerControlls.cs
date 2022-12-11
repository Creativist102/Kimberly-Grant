using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    [Header("Status")]
    public float curHp;
    public float maxHp;
    public float curAmmo;
    public float maxAmmo;

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

    //private Weapon balloon;


    void Awake()
    {
        curHp = maxHp;
        camera = Camera.main;
        rb = GetComponent<Rigidbody>(); 
        //balloon = GetComponent<Weapon>();
    }

    void Start()
    {

    }

    void Update()
    {
        Move();
        CameraLook();

        /*
        if(input.GetButton("Fire1"))
        {
            if(weapon.CanShoot())
            weapon.Shoot();
        }
        */

        if(Input.GetButtonDown("Jump"))
            Jump();
        
        /*
        if(GameManager.instance.gamePaused == true)
            return;
        */
    }

    void CameraLook()
    {
        float y =  Input.GetAxis("Mouse X") * lookSensitivity;
        rotationX += Input.GetAxis("Mouse Y") * lookSensitivity;

        rotationX = Mathf.Clamp(rotationX, minLookX, maxLookX);

        camera.transform.localRotation = Quaternion.Euler(-rotationX,0,0);
        transform.eulerAngles += Vector3.up * y;
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        
        Vector3 dir = (transform.right * x) + (transform.forward * z);

        dir.y = rb.velocity.y;
        rb.velocity = dir;
    }

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray, 1.1f))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        curHp -= damageAmount;

        if (curHp <= 0)
            Expire();
    }

    public void Expire()
    {
        Debug.Log("Player has died! Game over!");
    }

    public void GiveHealth(int healthAmount)
    {
        Debug.Log("Player has collected health!");
    }

    public void GiveAmmo(int ammoAmount)
    {
        Debug.Log("Player has collected balloons!");
    }
}