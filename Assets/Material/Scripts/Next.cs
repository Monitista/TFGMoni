using UnityEngine;

public class Next : MonoBehaviour
{
    public GameObject Menu1; // Prefab que se mostrar� inicialmente
    public GameObject Menu2; // Prefab que se mostrar� al pulsar el bot�n

    private GameObject initialInstance; // Instancia del prefab inicial
    private GameObject mainGameInstance; // Instancia del prefab principal

    void Start()
    {
        // Instanciar los prefabs
        initialInstance = Instantiate(Menu1);
        mainGameInstance = Instantiate(Menu2);

        // Asegurarse de que el prefab inicial est� visible y el principal est� oculto al inicio
        initialInstance.SetActive(true);
        mainGameInstance.SetActive(false);
    }

    // Funci�n para cambiar de prefab
    public void SwitchPrefab()
    {
        initialInstance.SetActive(false); // Ocultar el prefab inicial
        mainGameInstance.SetActive(true); // Mostrar el prefab principal
    }
}
