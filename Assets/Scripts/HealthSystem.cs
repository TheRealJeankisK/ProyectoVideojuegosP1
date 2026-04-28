using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [Header("Estadísticas de Vida")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Requisito de Instanciación")]
    [Tooltip("Arrastra aquí el Prefab del item 2D que quieres que suelte al morir")]
    public GameObject itemPrefab; 

    void Start()
    {
        // Inicializamos la vida al empezar el juego
        currentHealth = maxHealth;
    }

    // Método público que llama el script de combate
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(gameObject.name + " recibió daño. Vida: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " ha sido eliminado.");

        // Lógica de Instanciación para el proyecto
        if (itemPrefab != null)
        {
            // Crea el objeto en la misma posición del enemigo
            Instantiate(itemPrefab, transform.position, Quaternion.identity);
        }

        // Destruye el objeto (el cubo o enemigo)
        Destroy(gameObject);
    }
}