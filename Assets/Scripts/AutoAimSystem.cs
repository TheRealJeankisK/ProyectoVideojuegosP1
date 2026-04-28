using UnityEngine;

public class AutoAimSystem : MonoBehaviour
{
    public Camera mainCamera;
    public LayerMask detectionLayer; 
    public float rotationSpeed = 15f;
    public string colorPropertyName = "_Color"; 
    public Color highlightColor = Color.yellow;

    [HideInInspector] public bool isAiming = false;
    private Transform currentTarget;
    private PlayerCombat combat;
    private Renderer[] storedRenderers;
    private Color[] storedColors;

    void Start()
    {
        combat = GetComponent<PlayerCombat>();
    }

    void Update()
    {
        if (mainCamera == null) return;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, detectionLayer))
        {
            if (hit.collider.CompareTag("Target"))
            {
                if (currentTarget != hit.collider.transform)
                {
                    UnhighlightCurrent(); 
                    currentTarget = hit.collider.transform;
                    HighlightTarget(currentTarget, true);
                    isAiming = true;
                }
            }
            else { ResetAim(); }
        }
        else { ResetAim(); }

        // Si estamos atacando, bloqueamos la rotación del auto-aim
        if (isAiming && currentTarget != null && (combat == null || !combat.isAttacking))
        {
            RotateTowardsTarget();
        }
    }

    void ResetAim()
    {
        UnhighlightCurrent();
        currentTarget = null;
        isAiming = false;
    }

    void RotateTowardsTarget()
    {
        Vector3 direction = currentTarget.position - transform.position;
        direction.y = 0; 
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void HighlightTarget(Transform target, bool enable)
    {
        storedRenderers = target.GetComponentsInChildren<Renderer>();
        if (storedRenderers == null) return;
        storedColors = new Color[storedRenderers.Length];
        for (int i = 0; i < storedRenderers.Length; i++)
        {
            if (storedRenderers[i].material.HasProperty(colorPropertyName))
            {
                storedColors[i] = storedRenderers[i].material.GetColor(colorPropertyName);
                if (enable) storedRenderers[i].material.SetColor(colorPropertyName, highlightColor);
            }
        }
    }

    void UnhighlightCurrent()
    {
        if (storedRenderers != null)
        {
            for (int i = 0; i < storedRenderers.Length; i++)
            {
                if (storedRenderers[i] != null && storedRenderers[i].material.HasProperty(colorPropertyName))
                    storedRenderers[i].material.SetColor(colorPropertyName, storedColors[i]);
            }
            storedRenderers = null;
        }
    }
}