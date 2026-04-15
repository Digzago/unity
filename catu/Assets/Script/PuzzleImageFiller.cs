using UnityEngine;
using UnityEngine.UI;

public class PuzzleImageFiller : MonoBehaviour
{
    public GameObject puzzlePiecePrefab; // 拖你的 PuzzlePiece 预制体
    public int cols = 4;
    public int rows = 4;

    public void FillAllSlots(Texture2D fullTexture)
    {
        // 遍历 RawImage 下所有子物体（你的 16 个 Slot）
        foreach (Transform slotTrans in transform)
        {
            string slotName = slotTrans.name;
            // 只处理以 Slot 开头的物体
            if (!slotName.StartsWith("Slot")) continue;

            // 解析行号 y 和列号 x（适配你的命名：Slot行(列)）
            // 比如 Slot0 (0) → 提取 0 和 0
            string yStr = slotName.Replace("Slot", "").Split('(')[0].Trim();
            string xStr = slotName.Split('(')[1].Split(')')[0].Trim();

            if (!int.TryParse(yStr, out int y) || !int.TryParse(xStr, out int x))
            {
                Debug.LogWarning($"Slot 命名格式错误：{slotName}，跳过");
                continue;
            }

            // 生成拼图块
            GameObject piece = Instantiate(puzzlePiecePrefab, slotTrans);
            piece.name = $"Piece_{x}_{y}";

            // 1. 大小完全匹配 Slot
            RectTransform pieceRt = piece.GetComponent<RectTransform>();
            RectTransform slotRt = slotTrans.GetComponent<RectTransform>();
            pieceRt.sizeDelta = slotRt.sizeDelta;
            pieceRt.anchorMin = new Vector2(0.5f, 0.5f);
            pieceRt.anchorMax = new Vector2(0.5f, 0.5f);
            pieceRt.anchoredPosition = Vector2.zero;

            // 2. 给 RawImage 贴对应区域的图（不拉伸、不变形）
            RawImage img = piece.GetComponent<RawImage>();
            img.texture = fullTexture;
            img.uvRect = new Rect(
                x / (float)cols,
                1f - (y + 1) / (float)rows,
                1f / cols,
                1f / rows
            );
        }
    }
}