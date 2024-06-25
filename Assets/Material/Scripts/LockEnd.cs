using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockEnd : MonoBehaviour
{
    public static LockEnd Instance; // Instancia est�tica del LockEnd para acceso global
    public LockGemma specificPiece; // Pieza espec�fica para verificar

    public Animator animator; // Referencia al Animator
    public string animationTriggerName; // Nombre del trigger de animaci�n

    private bool hasTriggeredAnimation = false; // Bandera para controlar la activaci�n de la animaci�n

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (specificPiece == null)
        {
            Debug.LogError("Specific piece is not assigned.");
        }

        if (animator == null)
        {
            Debug.LogError("Animator is not assigned.");
        }
    }

    void Update()
    {
        CheckSpecificPiece();
    }

    public void CheckSpecificPiece()
    {
        if (specificPiece == null)
            return;

        if (specificPiece.IsInCorrectPositionGema())
        {

            if (!hasTriggeredAnimation && animator != null)
            {
                animator.SetTrigger(animationTriggerName);
                hasTriggeredAnimation = true;
            }

            if (hasTriggeredAnimation)
            {
                SceneManager.LoadScene("Final_Bien");
            }
        }
    }

  
}
