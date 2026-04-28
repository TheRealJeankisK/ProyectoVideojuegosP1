using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour
{
    [Header("Referencias")]
    public Animator anim;
    public Transform attackPoint;
    public AutoAimSystem autoAim;

    [Header("Configuración de Daño")]
    public float attackRange = 1.2f;
    public LayerMask targetLayers;
    public int damage = 25;
    
    [Header("Tiempos de Animación")]
    public float attackRate = 1f; // Tasa de ataque general
    public float damageDelay = 0.4f; // NUEVO: Cuánto tarda el hacha en tocar al enemigo
    public float totalAttackTime = 1.2f; // NUEVO: Cuánto dura bloqueado el personaje en total

    [HideInInspector] public bool isAttacking = false;
    private float nextAttackTime = 0f;

    void Update()
    {
        if (isAttacking) return;

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1")) 
            {
                StartCoroutine(AttackRoutine());
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    IEnumerator AttackRoutine()
    {
        isAttacking = true;
        
        // 1. Inicia la animación
        if (anim != null) anim.SetTrigger("Attack");

        // 2. Esperamos hasta el momento exacto del impacto (ej. 0.4 segundos)
        yield return new WaitForSeconds(damageDelay);

        // 3. ¡BOOM! Aquí aplicamos el daño
        Collider[] hitTargets = Physics.OverlapSphere(attackPoint.position, attackRange, targetLayers);
        foreach (Collider target in hitTargets)
        {
            HealthSystem health = target.GetComponent<HealthSystem>();
            if (health != null) health.TakeDamage(damage);
        }

        // 4. Calculamos cuánto tiempo falta para terminar la animación y esperamos
        float timeRemaining = totalAttackTime - damageDelay;
        if (timeRemaining > 0)
        {
            yield return new WaitForSeconds(timeRemaining);
        }
        
        // 5. Devolvemos el control al jugador
        isAttacking = false;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}