using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс для управления взглядом с помощью мыши
/// </summary>
public class CharController : MonoBehaviour
{

    enum RotationAxis
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }

    [SerializeField]
    RotationAxis axes = RotationAxis.MouseXandY;

    [SerializeField]
    float sensitivity = 3f;

    float maxVert = 45f;
    float minVert = -45f;

    float rotationX = 0;
    float rotationY;

    Rigidbody rBody;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        if (rBody != null)
        {
            rBody.freezeRotation = true;
            Debug.Log("RB_true");
        }
    }


    void Update()
    {
        if (axes == RotationAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        }
        else if (axes == RotationAxis.MouseY)
        {
            rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
            rotationX = Mathf.Clamp(rotationX, minVert, maxVert);

            //Сохранение одинакогово угла поворота вокруг Y
            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
        else
        {
            rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
            rotationX = Mathf.Clamp(rotationX, minVert, maxVert);

            float delta = Input.GetAxis("Mouse X") * sensitivity;
            rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
    }
}
