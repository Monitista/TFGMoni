using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance; // Instancia estática del PuzzleManager para acceso global

    public new ParticleSystem particleSystem; // Referencia al sistema de partículas en el inspector
    public List<PuzzlePiece> puzzlePieces; // Lista de todas las piezas del rompecabezas en el inspector
    public GameObject rewardObject; // Referencia al objeto de recompensa en el inspector
    public Transform rewardSpawnPoint; // Punto de aparición del objeto de recompensa en el inspector

    private bool particlesActivated = false; // Bandera para controlar si las partículas ya han sido activadas
    private bool rewardObjectActivated = false; // Bandera para controlar si el objeto de recompensa ya ha sido activado

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // Asegurarse de que el objeto de recompensa está desactivado al inicio
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

        // Si todas las piezas están en su posición correcta y las partículas no se han activado aún, activar la recompensa y las partículas
        if (allPiecesCorrect && !particlesActivated && !rewardObjectActivated)
        {
            rewardObject.SetActive(true);
            rewardObjectActivated = true; // Marcar el objeto de recompensa como activado

            // Activar las partículas
            if (particleSystem != null)
            {
                var emission = particleSystem.emission;
                emission.enabled = true;
                particleSystem.Play();
                particlesActivated = true; // Marcar las partículas como activadas
            }
        }
    }
}
