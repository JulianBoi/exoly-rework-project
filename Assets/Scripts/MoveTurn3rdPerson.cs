using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTurn3rdPerson : MonoBehaviour
{
    public float movementSpeed = 5f;

    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * verticalInput * movementSpeed * Time.deltaTime;
        transform.position += movement;
    }
}
