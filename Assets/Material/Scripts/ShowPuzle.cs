using UnityEngine;

public class ShowPuzle : MonoBehaviour
{
    public new ParticleSystem particleSystem; // Referencia al sistema de partículas
    public GameObject[] prefabsToShow; // Array de prefabs para mostrar
    public GameObject[] peces; // Array de prefabs para mostrar
    public GameObject boton; // Referencia al botón para ocultar
    public Animator animator; // Referencia al Animator
    public string animationTriggerName; // Nombre del trigger de animación

    // Función para cambiar de Prefab y activar animaciones, partículas y mostrar otros prefabs
    public void ShowPuzzle()
    {
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

        // Mostrar las piezas ocultas
        foreach (GameObject prefab in peces)
        {
            prefab.SetActive(true);
        }

        // Ocultar el botón
        if (boton != null)
        {
            boton.SetActive(false);
        }

        // Activar la animación
        if (animator != null)
        {
            animator.SetTrigger(animationTriggerName);
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
