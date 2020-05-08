using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharactor : MonoBehaviour
{
    int health;
    void Start()
    {
        health = 5;
    }

    public void GetDmg(int dmg)
    {
        health -= dmg;
        Debug.Log("Health: " + health);
    }
}
