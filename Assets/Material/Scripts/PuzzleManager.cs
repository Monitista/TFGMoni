using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance; // Instancia est�tica del PuzzleManager para acceso global

    public new ParticleSystem particleSystem; // Referencia al sistema de part�culas
    public List<PuzzlePiece> puzzlePieces; // Lista de todas las piezas del rompecabezas
    public GameObject rewardPrefab; // Prefab del objeto que se activar� como recompensa cuando se complete el rompecabezas
    public Transform rewardSpawnPoint; // Punto de aparici�n del objeto de recompensa

    private GameObject rewardObject; // Referencia al objeto de recompensa instanciado
    private bool particlesActivated = false; // Bandera para controlar si las part�culas ya han sido activadas

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // Instanciar el objeto de recompensa en la posici�n especificada
        rewardObject = Instantiate(rewardPrefab, rewardSpawnPoint.position, rewardSpawnPoint.rotation);
        // Asegurarse de que el objeto de recompensa est� desactivado al inicio
        rewardObject.SetActive(false);

        if (particleSystem != null)
        {
            var emission = particleSystem.emission;
            emission.enabled = false;
        }
    }

    public void CheckAllPieces()
    {
        bool allPiecesCorrect = true;

        // Verificar cada pieza del rompecabezas
        foreach (var piece in puzzlePieces)
        {
            if (!piece.isInCorrectPositionPieces())
            {
                allPiecesCorrect = false;
                break;
            }
        }

        // Si todas las piezas est�n en su posici�n correcta y las part�culas no se han activado a�n, activar la recompensa y las part�culas
        if (allPiecesCorrect && !particlesActivated)
        {
            rewardObject.SetActive(true);
            particlesActivated = true; // Marcar las part�culas como activadas

            // Activar las part�culas
            if (particleSystem != null)
            {
                var emission = particleSystem.emission;
                emission.enabled = true;
                particleSystem.Play();
            }
        }
    }
}
