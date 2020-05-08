using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    WanderingAI behavior;

    private void Start()
    {
        behavior = GetComponent<WanderingAI>();
    }

    public void ReactToRit()
    {
        if (behavior != null)
        {
            behavior.isAlive(false);
        }
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);

        Destroy(gameObject);
    }
}
