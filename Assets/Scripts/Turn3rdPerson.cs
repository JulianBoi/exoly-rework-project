using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn3rdPerson : MonoBehaviour
{
    public Transform cameraTransform;
    public float turnSpeed = 5f;

    void Update()
    {
        // R�cup�re la direction de la cam�ra sans la hauteur
        Vector3 cameraDirection = cameraTransform.forward;
        cameraDirection.y = 0f;
        cameraDirection = cameraDirection.normalized;



        // Calcule la rotation � appliquer au personnage
        Quaternion targetRotation = Quaternion.LookRotation(cameraDirection);

        // Applique la rotation au personnage avec une interpolation douce
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);


    }
}
