using UnityEngine;

public class ShowPuzle : MonoBehaviour
{
    public new ParticleSystem particleSystem; // Referencia al sistema de partículas
    public GameObject[] prefabsToShow; // Array de prefabs para mostrar
    public GameObject[] peces; // Array de prefabs para mostrar
    public GameObject boton; // Array de prefabs para mostrar

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

        // Mostrar las piezas ocultos
        foreach (GameObject prefab in peces)
        {
            prefab.SetActive(true);
        }

        if (boton != null)
        {
            boton.gameObject.SetActive(false);
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
