using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [Header("Configuración del Ítem")]
    public string nombreDelItem = "Batería";

    void Update()
    {
        // EFECTO BILLBOARD: Hace que el sprite siempre mire a la cámara.
        // Esto es clave para que tu ítem 2D no se vea como un papel plano en el mundo 3D.
        if (Camera.main != null)
        {
            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
                             Camera.main.transform.rotation * Vector3.up);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 1. Verificamos si lo que entró en el trigger es el Jugador
        // ¡IMPORTANTE!: Tu personaje debe tener el Tag "Player" en el Inspector.
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡" + nombreDelItem + " recogida!");

            // 2. Le avisamos al GameManager que sume una batería
            if (GameManager.instance != null)
            {
                GameManager.instance.RecogerBateria();
            }
            else
            {
                Debug.LogWarning("Ojo: No hay un GameManager en la escena o no tiene el script puesto.");
            }

            // 3. Destruimos el ítem de la escena
            Destroy(gameObject);
        }
    }
}