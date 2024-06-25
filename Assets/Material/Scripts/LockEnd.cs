using System.Collections.Generic;
using UnityEngine;

public class LockEnd : MonoBehaviour
{
    public LockGemma specificPiece; // Pieza espec�fica para verificar
    private bool rewardShown = false; // Bandera para controlar si la recompensa ya se ha mostrado

    void Start()
    {
        // Asegurarse de que la pieza espec�fica est� desactivada al inicio
        specificPiece.gameObject.SetActive(false);
    }

    void Update()
    {
        CheckSpecificPiece();
    }

    private void CheckSpecificPiece()
    {
        // Verificar si la pieza espec�fica est� en su posici�n correcta
        if (specificPiece.isInCorrectPositionGema() && !rewardShown)
        {
            // Mostrar la pieza espec�fica
            specificPiece.gameObject.SetActive(true);
            rewardShown = true; // Marcar la recompensa como mostrada
        }
    }
}
