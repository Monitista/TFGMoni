using System.Collections.Generic;
using UnityEngine;

public class LockEnd : MonoBehaviour
{
    public LockGemma specificPiece; // Pieza específica para verificar
    private bool rewardShown = false; // Bandera para controlar si la recompensa ya se ha mostrado

    void Start()
    {
        // Asegurarse de que la pieza específica está desactivada al inicio
        specificPiece.gameObject.SetActive(false);
    }

    void Update()
    {
        CheckSpecificPiece();
    }

    private void CheckSpecificPiece()
    {
        // Verificar si la pieza específica está en su posición correcta
        if (specificPiece.isInCorrectPositionGema() && !rewardShown)
        {
            // Mostrar la pieza específica
            specificPiece.gameObject.SetActive(true);
            rewardShown = true; // Marcar la recompensa como mostrada
        }
    }
}
