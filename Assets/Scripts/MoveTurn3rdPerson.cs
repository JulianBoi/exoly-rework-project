using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTurn3rdPerson : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        // Déplacer l'objet de jeu
        Vector3 movement = (transform.forward * verticalInput + transform.right * horizontalInput) * movementSpeed * Time.deltaTime;
        transform.position += movement;

        // Arrêter l'animation lorsque la touche est relâchée

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
