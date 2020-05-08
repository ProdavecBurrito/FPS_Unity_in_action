using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShoot : MonoBehaviour
{
    Camera cam;

    int crossSize = 12;

    void Start()
    {
        cam = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);
            Ray ray = cam.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 50f))
            {
                GameObject hitObj = hit.transform.gameObject;
                ReactiveTarget target = hitObj.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    target.ReactToRit();
                }
                else
                {
                    StartCoroutine(CreateSphire(hit.point));
                }
            }
        }
    }

    void OnGUI()
    {
        float posX = cam.pixelWidth / 2 - crossSize / 4;
        float posY = cam.pixelHeight / 2 - crossSize / 2;
        GUI.Label(new Rect(posX, posY, crossSize, crossSize), "*");
    }

    IEnumerator CreateSphire(Vector3 hitPoint)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = hitPoint;

        yield return new WaitForSeconds(1f);

        Destroy(sphere);
    }
}
