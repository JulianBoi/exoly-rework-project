using UnityEngine;

public class MoveCamera3rdPerson : MonoBehaviour
{
    public Transform player; // R�f�rence � l'objet joueur
    public float smoothSpeed = 0.125f; // Vitesse de mouvement de la cam�ra

    public Vector3 offset; // Distance entre la cam�ra et le joueur

    public float rotateSpeed = 5f; // Vitesse de rotation de la cam�ra

    float mouseX, mouseY; // Stocker les mouvements de la souris

    void Start()
    {
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        // Mouvements de la souris pour faire pivoter la cam�ra
        mouseX += Input.GetAxis("Mouse X") * rotateSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotateSpeed;
        mouseY = Mathf.Clamp(mouseY, -35f, 60f);

        // Calculer la rotation de la cam�ra en fonction des mouvements de la souris
        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);

        // Calculer la position d�sir�e de la cam�ra en fonction de la rotation et de la position du joueur
        Vector3 desiredPosition = player.position + (rotation * offset);

        // V�rifier si la cam�ra entre en collision avec un objet et ajuster la position en cons�quence
        RaycastHit hit;
        if (Physics.Linecast(player.position, desiredPosition, out hit))
        {
            // Si la collision est d�tect�e, rapprocher la cam�ra de l'objet pour �viter la collision
            if (!hit.transform == player)
            {
                desiredPosition = hit.point + (hit.normal * 0.2f);
            }
        }

        // D�placer la cam�ra en douceur vers la position et la rotation d�sir�es
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, smoothSpeed);
    }
}
