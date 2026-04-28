using UnityEngine;

public class CameraFollowSimple : MonoBehaviour
{
    public Transform target; // Arrastra aquí al astronauta
    public Vector3 offset = new Vector3(0, 5, -10); // Esto la aleja para que no desaparezca
    public float smoothTime = 0.3f; // MÁS ALTO = MÁS PESADA

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target == null) return;

        // Calculamos a dónde debería ir la cámara
        Vector3 targetPosition = target.position + offset;

        // Movemos la cámara con "amortiguación" (el efecto de arrastre)
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}