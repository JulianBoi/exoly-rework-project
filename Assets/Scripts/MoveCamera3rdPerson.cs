using UnityEngine;

public class MoveCamera3rdPerson : MonoBehaviour
{
    public Transform player; // Référence à l'objet joueur
    public float smoothSpeed = 0.125f; // Vitesse de mouvement de la caméra

    public Vector3 offset; // Distance entre la caméra et le joueur

    public float rotateSpeed = 5f; // Vitesse de rotation de la caméra

    float mouseX, mouseY; // Stocker les mouvements de la souris

    void Start()
    {
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        // Mouvements de la souris pour faire pivoter la caméra
        mouseX += Input.GetAxis("Mouse X") * rotateSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotateSpeed;
        mouseY = Mathf.Clamp(mouseY, -35f, 60f);

        // Calculer la rotation de la caméra en fonction des mouvements de la souris
        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);

        // Calculer la position désirée de la caméra en fonction de la rotation et de la position du joueur
        Vector3 desiredPosition = player.position + (rotation * offset);

        // Vérifier si la caméra entre en collision avec un objet et ajuster la position en conséquence
        RaycastHit hit;
        if (Physics.Linecast(player.position, desiredPosition, out hit))
        {
            // Si la collision est détectée, rapprocher la caméra de l'objet pour éviter la collision
            if (!hit.transform == player)
            {
                desiredPosition = hit.point + (hit.normal * 0.2f);
            }
        }

        // Déplacer la caméra en douceur vers la position et la rotation désirées
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, smoothSpeed);
    }
}
