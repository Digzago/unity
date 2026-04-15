using UnityEngine;
using UnityEngine.EventSystems;

public class SlotDrop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedPiece = eventData.pointerDrag;
        if (draggedPiece == null) return;

        // 把拼图块吸附到 Slot 正中心
        RectTransform pieceRt = draggedPiece.GetComponent<RectTransform>();
        pieceRt.anchoredPosition = Vector2.zero;
    }
}