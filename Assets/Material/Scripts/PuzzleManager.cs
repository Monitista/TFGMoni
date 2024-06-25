using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance; // Instancia estática del PuzzleManager para acceso global

    public new ParticleSystem particleSystem; // Referencia al sistema de partículas
    public List<PuzzlePiece> puzzlePieces; // Lista de todas las piezas del rompecabezas
    public GameObject rewardPrefab; // Prefab del objeto que se activará como recompensa cuando se complete el rompecabezas
    public Transform rewardSpawnPoint; // Punto de aparición del objeto de recompensa

    private GameObject rewardObject; // Referencia al objeto de recompensa instanciado
    private bool particlesActivated = false; // Bandera para controlar si las partículas ya han sido activadas

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // Instanciar el objeto de recompensa en la posición especificada
        rewardObject = Instantiate(rewardPrefab, rewardSpawnPoint.position, rewardSpawnPoint.rotation);
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
        if (allPiecesCorrect && !particlesActivated)
        {
            rewardObject.SetActive(true);
            particlesActivated = true; // Marcar las partículas como activadas

            // Activar las partículas
            if (particleSystem != null)
            {
                var emission = particleSystem.emission;
                emission.enabled = true;
                particleSystem.Play();
            }
        }
    }
}
