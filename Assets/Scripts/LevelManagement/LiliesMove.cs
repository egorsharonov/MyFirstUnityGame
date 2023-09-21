using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiliesMove : MonoBehaviour
{
    [SerializeField] private float verticalAmplitude = 1.0f; // Расстояние по вертикали
    [SerializeField] private float verticalSpeed = 1.0f; // Скорость по вертикали

    [SerializeField] private float horizontalAmplitude = 1.0f; // Расстояние по горизонтали
    [SerializeField] private float horizontalSpeed = 1.0f; // Скорость по горизонтали

    private Vector3 initialPosition;
    [SerializeField] private int verticalDirection = 1;
    [SerializeField] private int horizontalDirection = 1;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        float yPosition = transform.position.y;
        float xPosition = transform.position.x;
        if (yPosition >= initialPosition.y + verticalAmplitude)
            verticalDirection = -1;
        else if (yPosition <= initialPosition.y - horizontalAmplitude)
            verticalDirection = 1;

        if (xPosition >= initialPosition.x + horizontalAmplitude)
            horizontalDirection = -1;
        else if (xPosition <= initialPosition.x - horizontalAmplitude)
            horizontalDirection = 1;

        float yPositionNew = transform.position.y + Time.deltaTime*verticalSpeed * verticalDirection;
        float xPositionNew = transform.position.x + Time.deltaTime * horizontalSpeed * horizontalDirection;
        transform.position = new Vector3(xPositionNew,yPositionNew, transform.position.z);
    }
}
