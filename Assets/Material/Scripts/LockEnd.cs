using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockEnd : MonoBehaviour
{
    public static LockEnd Instance; // Instancia estática del LockEnd para acceso global
    public LockGemma specificPiece; // Pieza específica para verificar

    public Animator animator; // Referencia al Animator
    public string animationTriggerName; // Nombre del trigger de animación

    public new ParticleSystem particleSystem; // Referencia al sistema de partículas

    void Awake()
    {
        Instance = this;
        Debug.Log("LockEnd instance assigned.");
    }

    void Start()
    {
        if (particleSystem != null)
        {
            var emission = particleSystem.emission;
            emission.enabled = false;
            Debug.Log("Particle system initialized.");
        }
        else
        {
            Debug.LogError("Particle system is not assigned.");
        }

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
        {
            Debug.LogError("Specific piece is not assigned.");
            return;
        }

        if (specificPiece.IsInCorrectPositionGema())
        {
            Debug.Log("Specific piece is in the correct position");

            // Activar las partículas
            if (particleSystem != null)
            {
                var emission = particleSystem.emission;
                emission.enabled = true;
                particleSystem.Play();
                Debug.Log("Particle system activated");
            }
            else
            {
                Debug.LogError("Particle system is not assigned.");
            }

            // Activar la animación
            if (animator != null)
            {
                animator.SetTrigger(animationTriggerName);
                Debug.Log("Animation triggered");
            }
            else
            {
                Debug.LogError("Animator is not assigned.");
            }

            // Cambiar a otra escena después de un pequeño retraso
            StartCoroutine(LoadNextSceneWithDelay(2.0f)); // Cambia el tiempo de retraso según sea necesario
        }
        else
        {
            Debug.Log("Specific piece is not in correct position.");
            Debug.Log("Distance: " + Vector3.Distance(specificPiece.transform.position, specificPiece.correctSlot.position));
        }
    }



    private IEnumerator LoadNextSceneWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Final_Bien");
    }
}
