using UnityEngine;

public class CapsaOpenStart : MonoBehaviour
{
    public Animator animator; // Referencia al Animator
    public ParticleSystem particleSystem; // Referencia al sistema de part�culas
    public GameObject[] prefabsToShow; // Array de prefabs para mostrar
    public string animationTriggerName; // Nombre del trigger de animaci�n

    private void OnTriggerEnter(Collider other)
    {
        // Verifica que el objeto que entra en el trigger es el jugador (puedes usar tags o layers)
        if (other.CompareTag("Player"))
        {
            // Activar la animaci�n
            if (animator != null)
            {
                animator.SetTrigger(animationTriggerName);
            }

            // Activar las part�culas
            if (particleSystem != null)
            {
                particleSystem.Play();
            }

            // Mostrar los prefabs ocultos
            foreach (GameObject prefab in prefabsToShow)
            {
                prefab.SetActive(true);
            }
        }
    }
}
