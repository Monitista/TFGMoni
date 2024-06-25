using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance; // Instancia est�tica del PuzzleManager para acceso global

    public new ParticleSystem particleSystem; // Referencia al sistema de part�culas en el inspector
    public List<PuzzlePiece> puzzlePieces; // Lista de todas las piezas del rompecabezas en el inspector
    public GameObject rewardObject; // Referencia al objeto de recompensa en el inspector
    public Transform rewardSpawnPoint; // Punto de aparici�n del objeto de recompensa en el inspector

    private bool particlesActivated = false; // Bandera para controlar si las part�culas ya han sido activadas
    private bool rewardObjectActivated = false; // Bandera para controlar si el objeto de recompensa ya ha sido activado

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
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
        if (allPiecesCorrect && !particlesActivated && !rewardObjectActivated)
        {
            rewardObject.SetActive(true);
            rewardObjectActivated = true; // Marcar el objeto de recompensa como activado

            // Activar las part�culas
            if (particleSystem != null)
            {
                var emission = particleSystem.emission;
                emission.enabled = true;
                particleSystem.Play();
                particlesActivated = true; // Marcar las part�culas como activadas
            }
        }
    }
}
