using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс для передвижения персонажа
/// </summary>
/// 
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Scripts/FPSInput")]
public class FPSInput : MonoBehaviour
{
    [SerializeField]
    float speed = 0.2f;

    CharacterController charController;

    float deltaX;
    float deltaZ;

    Vector3 movement;

    float gravity = -5f;

    private void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        deltaX = Input.GetAxis("Horizontal") * speed;
        deltaZ = Input.GetAxis("Vertical") * speed;
        movement = new Vector3(deltaX, 0, deltaZ);
        //Ограничение максимальной скорости
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;

        movement *= Time.deltaTime;
        // Перевод в глобальные координаты
        movement = transform.TransformDirection(movement);
        charController.Move(movement);
    }
}
