using UnityEngine;

public class LockGemma : MonoBehaviour
{
    public Transform correctSlot; // Referencia al slot correcto donde debe colocarse la pieza
    private bool isInCorrectPositionGem = false;

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
            Debug.Log("Bieen");
        }
        else
        {
            SetIsInCorrectPosition(false);
        }
    }

    public void SetIsInCorrectPosition(bool value)
    {
        isInCorrectPositionGem = value;
        // Llamar a una función en el PuzzleManager para verificar todas las piezas
        PuzzleManager.Instance.CheckAllPieces();
    }

    public bool isInCorrectPositionGema()
    {
        return isInCorrectPositionGem;
    }
}
