using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTurn3rdPerson : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float animationSpeed = 1f;
    public Animator animator;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // D�placer l'objet de jeu
        Vector3 movement = (transform.forward * verticalInput + transform.right * horizontalInput) * movementSpeed * Time.deltaTime;
        transform.position += movement;

        // Passer la vitesse d'animation � l'animator
        animator.SetFloat("Speed", movement.magnitude * animationSpeed);

        // Arr�ter l'animation lorsque la touche est rel�ch�e
        if (Input.GetKey(KeyCode.Z))
        {
            animator.SetBool("WalkForward", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("WalkBackward", true);
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            animator.SetBool("WalkForward", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("WalkBackward", false);
        }
    }
}
