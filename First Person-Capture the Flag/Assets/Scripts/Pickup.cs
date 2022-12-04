using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public PickupType pickupType;
    public int healthAmount;
    public int ammoAmount;
    //public int addAmount;

    [Header ("Bobbing Motion")]
    public float rotateSpeed;
    public float bobSpeed;
    public float bobHeight;
    private bool bobbingUp;
    private Vector3 startPosition;
    //public AudioClip pickupSFX;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    public enum PickupType      //enums store categories, arrays store information
    {
        Health,
        Ammo/*,
        AddPlayer   */
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerControlls player = other.GetComponent<PlayerControlls>();

            switch(pickupType)
            {
                case PickupType.Health:
                player.GiveHealth(healthAmount);
                break;

                case PickupType.Ammo:
                player.GiveAmmo(ammoAmount);
                break;

             /* case PickupType.AddPlayer:
                player.AddPlayer(addAmount);
                break;    */

                default:
                print("Type not accepted.");
                break;
            }
            //other.GetComponent<AudioSource>().PlayOneShot(pickupSFX);
            Destroy(gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

        Vector3 offset = (bobbingUp == true ? new Vector3(0, bobHeight/2, 0) : new Vector3(0, -bobHeight/2, 0));

        transform.position = Vector3.MoveTowards(transform.position, startPosition + offset, bobSpeed * Time.deltaTime);

        if(transform.position == startPosition + offset)
        {
            bobbingUp = !bobbingUp;
        }
    }
}

/*
    public Inventory inventory;

    public emum Inventory
    {
        HealthPotion,
        Balloons,
        Powerup
    }

    switch(shopKeeper)
    {
        case Inventory.HealthPotion:
        player.GiveHealth(healthAmount)
        break;

        case Inventory.Balloons:
        player.GiveAmmo(ammoAmount);
        break;

        case Inventory.Powerup:
        player.GivePowerup(powerupType);
        break;
    }
*/