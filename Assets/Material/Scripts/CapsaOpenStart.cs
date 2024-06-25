using UnityEngine;

public class CapsaOpenStart : MonoBehaviour
{
    public Animator animator; // Referencia al Animator
    public new ParticleSystem particleSystem; // Referencia al sistema de partículas
    public GameObject[] prefabsToShow; // Array de prefabs para mostrar
    public string animationTriggerName; // Nombre del trigger de animación
    public Timer[] timer; // Referencia al script Timer

    // Función para cambiar de Prefab y activar animaciones, partículas y mostrar otros prefabs
    public void OpenBox()
    {
        // Activar la animación
        if (animator != null)
        {
            animator.SetTrigger(animationTriggerName);
        }

        // Activar las partículas
        if (particleSystem != null)
        {
            var emission = particleSystem.emission;
            emission.enabled = true;
            particleSystem.Play();
        }

        // Mostrar los prefabs ocultos
        foreach (GameObject prefab in prefabsToShow)
        {
            prefab.SetActive(true);
        }

        // Iniciar el temporizador
        foreach (Timer prefab in timer)
        {
            prefab.StartTimer();
        }
    }

    // Función para desactivar la emisión de partículas al inicio
    void Start()
    {
        if (particleSystem != null)
        {
            var emission = particleSystem.emission;
            emission.enabled = false;
        }
    }
}
