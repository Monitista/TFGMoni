using UnityEngine;

public class CapsaOpenStart : MonoBehaviour
{
    public Animator animator; // Referencia al Animator
    public new ParticleSystem particleSystem; // Referencia al sistema de part�culas
    public GameObject[] prefabsToShow; // Array de prefabs para mostrar
    public string animationTriggerName; // Nombre del trigger de animaci�n
    public Timer[] timer; // Referencia al script Timer

    // Funci�n para cambiar de Prefab y activar animaciones, part�culas y mostrar otros prefabs
    public void OpenBox()
    {
        // Activar la animaci�n
        if (animator != null)
        {
            animator.SetTrigger(animationTriggerName);
        }

        // Activar las part�culas
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

    // Funci�n para desactivar la emisi�n de part�culas al inicio
    void Start()
    {
        if (particleSystem != null)
        {
            var emission = particleSystem.emission;
            emission.enabled = false;
        }
    }
}
