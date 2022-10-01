using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fiveIFstatements : MonoBehaviour
{
    int dragonFire = 5;
    bool attack = false;
    string noAttackToday = "Such a lovely day.";
    string attackToday = "We are under attack from dragons!";

    void Update()
    {
        if(attack == false)
        {
            Console.Write(noAttackToday);
        }

        if(Console.Write(noAttackToday))
        {
            dragonFire;
        }

        if(dragonFire)
        {
            attack = true;
        }

        if(attack == true)
        {
            Console.Write(attackToday);
        }
    }

   void OnMouseDown()
    {
        if(attackToday)
        {
            dragonFire -= 1;
        }

        if(dragonFire < 1)
        {
            attack = false;
        }
    }
}
