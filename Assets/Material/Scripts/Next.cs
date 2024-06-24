using UnityEngine;

public class Next : MonoBehaviour
{
    public GameObject Menu1; // Prefab que se mostrará inicialmente
    public GameObject Menu2; // Prefab que se mostrará al pulsar el botón

    private GameObject initialInstance; // Instancia del prefab inicial
    private GameObject mainGameInstance; // Instancia del prefab principal

    void Start()
    {
        // Instanciar los prefabs
        initialInstance = Instantiate(Menu1);
        mainGameInstance = Instantiate(Menu2);

        // Asegurarse de que el prefab inicial esté visible y el principal esté oculto al inicio
        initialInstance.SetActive(true);
        mainGameInstance.SetActive(false);
    }

    // Función para cambiar de prefab
    public void SwitchPrefab()
    {
        initialInstance.SetActive(false); // Ocultar el prefab inicial
        mainGameInstance.SetActive(true); // Mostrar el prefab principal
    }
}
