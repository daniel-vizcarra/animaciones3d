using System.Collections.Generic;
using UnityEngine;

public class ObjectAnimationController : MonoBehaviour
{
    // Lista para almacenar las animaciones disponibles
    private List<System.Action> animations;

    // Índice actual de la animación en la lista
    private int currentAnimationIndex = 0;

    // Bandera para verificar si la animación está activa
    private bool isAnimating = false;

    // Transform para manejar el movimiento y rotación
    private Transform objectTransform;

    void Start()
    {
        objectTransform = GetComponent<Transform>();

        // Inicializar la lista de animaciones
        animations = new List<System.Action>
        {
            MoveAnimation, // Animación de movimiento
            RotateAnimation // Animación de rotación
        };
    }

    void Update()
    {
        // Interacción con teclas para controlar las animaciones

        // Cambiar a la siguiente animación (tecla derecha)
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentAnimationIndex = (currentAnimationIndex + 1) % animations.Count;
        }

        // Cambiar a la animación anterior (tecla izquierda)
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentAnimationIndex = (currentAnimationIndex - 1 + animations.Count) % animations.Count;
        }

        // Activar o desactivar la animación (tecla espacio)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isAnimating = !isAnimating;
        }

        // Ejecutar la animación actual si está activa
        if (isAnimating)
        {
            animations[currentAnimationIndex]?.Invoke();
        }
    }

    // Animación de movimiento
    void MoveAnimation()
    {
        // Mover el objeto de ida y vuelta en el eje Z
        float speed = 2f;
        float movement = Mathf.PingPong(Time.time * speed, 2f) - 1f;
        objectTransform.position = new Vector3(0, 0, movement);
    }

    // Animación de rotación
    void RotateAnimation()
    {
        // Rotar el objeto continuamente
        float rotationSpeed = 50f;
        objectTransform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
