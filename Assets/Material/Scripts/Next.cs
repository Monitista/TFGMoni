using UnityEngine;

public class Next : MonoBehaviour
{
    public GameObject initialPrefab; // Prefab que se mostrará inicialmente
    public GameObject mainGamePrefab; // Prefab que se mostrará al pulsar el botón

    // Función para cambiar de Prefab
    public void SwitchPrefabs()
    {
        initialPrefab.SetActive(false); // Ocultar el prefab inicial
        mainGamePrefab.SetActive(true); // Mostrar el prefab principal
    }
}
