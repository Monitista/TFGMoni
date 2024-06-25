using UnityEngine;

public class LockGemma : MonoBehaviour
{
    public Transform correctSlot; // Referencia al slot correcto donde debe colocarse la pieza
    private bool isInCorrectPositionGem = false;

    void Start()
    {
        if (correctSlot == null)
        {
            Debug.LogError("Correct slot is not assigned.");
        }
        else
        {
            Debug.Log("Correct slot assigned.");
        }
    }

    void LateUpdate()
    {
        CheckPosition();
    }

    void CheckPosition()
    {
        if (correctSlot == null) return;

        // Verificar si la pieza est� en el slot correcto
        if (Vector3.Distance(transform.position, correctSlot.position) < 2f) // Ajustar el valor seg�n sea necesario
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
        isInCorrectPositionGem = value;
        // Llamar a una funci�n en el LockEnd para verificar la pieza espec�fica
        if (LockEnd.Instance != null)
        {
            Debug.Log("Calling CheckSpecificPiece from LockEnd.");
            LockEnd.Instance.CheckSpecificPiece();
        }
        else
        {
            Debug.LogError("LockEnd instance is not assigned.");
        }
    }

    public bool IsInCorrectPositionGema()
    {
        return isInCorrectPositionGem;
    }
}
