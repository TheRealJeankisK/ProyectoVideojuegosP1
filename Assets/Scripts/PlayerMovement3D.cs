using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    private Vector3 moveInput;
    private Animator anim;
    private AutoAimSystem autoAim;
    private PlayerCombat combat;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        autoAim = GetComponent<AutoAimSystem>();
        combat = GetComponent<PlayerCombat>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Si está atacando, no procesamos entrada de movimiento
        if (combat != null && combat.isAttacking)
        {
            moveInput = Vector3.zero;
            if (anim != null) anim.SetFloat("Speed", 0);
            return;
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        moveInput = new Vector3(moveX, 0f, moveZ).normalized;

        if (anim != null) anim.SetFloat("Speed", moveInput.magnitude);
    }

    void FixedUpdate()
    {
        if (combat != null && combat.isAttacking)
        {
            // Frenamos el Rigidbody por completo durante el ataque
            rb.linearVelocity = Vector3.zero;
            return;
        }

        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);

        bool aiming = (autoAim != null && autoAim.isAiming);
        if (moveInput != Vector3.zero && !aiming)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveInput);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.2f);
        }
    }
}