using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public Transform correctSlot; // Referencia al slot correcto donde debe colocarse la pieza
    private bool isInCorrectPositionPiece = false;

    void LateUpdate()
    {
        CheckPosition();
    }

    void CheckPosition()
    {
        // Verificar si la pieza está en el slot correcto
        if (Vector3.Distance(transform.position, correctSlot.position) < 0.1f)
        {
            SetIsInCorrectPosition(true);
        }
        else
        {
            SetIsInCorrectPosition(false);
        }
    }

    public void SetIsInCorrectPosition(bool value)
    {
        isInCorrectPositionPiece = value;
        // Llamar a una función en el PuzzleManager para verificar todas las piezas
        PuzzleManager.Instance.CheckAllPieces();
    }

    public bool isInCorrectPositionPieces()
    {
        return isInCorrectPositionPiece;
    }
}
