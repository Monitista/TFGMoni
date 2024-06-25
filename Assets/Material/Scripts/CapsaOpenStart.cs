using UnityEngine;

public class CapsaOpenStart : MonoBehaviour
{
    public Animator animator; // Referencia al Animator
    public ParticleSystem particleSystem; // Referencia al sistema de partículas
    public GameObject[] prefabsToShow; // Array de prefabs para mostrar
    public string animationTriggerName; // Nombre del trigger de animación

    private void OnTriggerEnter(Collider other)
    {
        // Verifica que el objeto que entra en el trigger es el jugador (puedes usar tags o layers)
        if (other.CompareTag("Player"))
        {
            // Activar la animación
            if (animator != null)
            {
                animator.SetTrigger(animationTriggerName);
            }

            // Activar las partículas
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
