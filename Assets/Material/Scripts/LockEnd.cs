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

                // Esperar 5 segundos antes de cargar la escena
                StartCoroutine(LoadNextSceneWithDelay(3.0f));
            }
        }
    }

    private IEnumerator LoadNextSceneWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Final_Bien");
    }
}
