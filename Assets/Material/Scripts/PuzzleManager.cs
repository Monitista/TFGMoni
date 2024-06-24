using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance; // Instancia estática del PuzzleManager para acceso global

    public List<PuzzlePiece> puzzlePieces; // Lista de todas las piezas del rompecabezas
    public GameObject rewardPrefab; // Prefab del objeto que se activará como recompensa cuando se complete el rompecabezas
    public Transform rewardSpawnPoint; // Punto de aparición del objeto de recompensa

    private GameObject rewardObject; // Referencia al objeto de recompensa instanciado

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
    }

    public void CheckAllPieces()
    {
        bool allPiecesCorrect = true;

        // Verificar cada pieza del rompecabezas
        foreach (var piece in puzzlePieces)
        {
            if (!piece.IsInCorrectPosition())
            {
                allPiecesCorrect = false;
                break;
            }
        }

        // Si todas las piezas están en su posición correcta, activar la recompensa
        if (allPiecesCorrect)
        {
            rewardObject.SetActive(true);
        }
    }
}
