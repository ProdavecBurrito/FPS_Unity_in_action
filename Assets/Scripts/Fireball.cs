using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    float speed = 10f;
    int dmg = 1;

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharactor player = other.GetComponent<PlayerCharactor>();
        if (player != null)
        {
            player.GetDmg(dmg);
        }
        Destroy(gameObject);
    }
}
