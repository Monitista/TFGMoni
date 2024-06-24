using UnityEngine;

public class Next : MonoBehaviour
{
    public GameObject initialPrefab; // Prefab que se mostrar� inicialmente
    public GameObject mainGamePrefab; // Prefab que se mostrar� al pulsar el bot�n

    // Funci�n para cambiar de Prefab
    public void SwitchPrefabs()
    {
        initialPrefab.SetActive(false); // Ocultar el prefab inicial
        mainGamePrefab.SetActive(true); // Mostrar el prefab principal
    }
}
