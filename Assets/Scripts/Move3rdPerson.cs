using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move3rdPerson : MonoBehaviour
{
    public float jumpForce = 10.0f;
    public float gravity = 20.0f;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    public bool jumping = false;

    public Animator animator;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
        

    private void Update()
    {
        if (jumping)
        {
            if (controller.isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    // Si le personnage est sur le sol et que la touche "Barre d'espacement" est pressée, ajouter une force de saut verticale
                    moveDirection.y = jumpForce;
                }
            }
            else
            {
                animator.SetBool("Jump", false);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {

                if (controller.isGrounded)
                {
                    animator.SetBool("Jump", true);
                }
            }

        }

        // Appliquer la gravité
        moveDirection.y -= gravity * Time.deltaTime;

        // Déplacer le personnage
        controller.Move(moveDirection * Time.deltaTime);
    }
}
