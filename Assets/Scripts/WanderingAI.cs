using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] GameObject fireballPrefab;
    GameObject fireball;

    float speed = 2f;
    float obstacleRange = 5f;
    bool alive;

    float botRadius = 0.75f;

    private void Start()
    {
        alive = true;
    }

    void Update()
    {
        if (alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, botRadius, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharactor>())
                {
                    if (fireball == null)
                    {
                        fireball = Instantiate(fireballPrefab) as GameObject;
                        fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        fireball.transform.rotation = transform.rotation;
                    }
                }

                else if (hit.distance <= obstacleRange)
                {
                    float angle = Random.Range(-100, 100);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }

    public void isAlive(bool _alive)
    {
        alive = _alive;
    }
}
