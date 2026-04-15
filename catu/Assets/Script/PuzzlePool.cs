using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePool : MonoBehaviour
{
    // Start is called before the first frame update
    public static PuzzlePool Instance;
    [SerializeField ]//反射
    GameObject K0_0,K0_1,K0_2,K0_3,K1_0,K1_1,K1_2,K1_3,K2_0,K2_1,K2_2,K2_3,K3_0,K3_1,K3_2,K3_3,Grid;
    [SerializeField]
    Transform puzzlePanel;//加入输入s 
       
    private void Awake()
    {
        Instance = this;
    }
    public void CreatePuzzle(int row,int col)
    {
        int totalGridNum = row * col;
        for(int i=0;i< totalGridNum; i++)
        {
            Instantiate(Grid, puzzlePanel);  
        }
        CreatePieces();
    }
   
    void CreatePieces()
    {
        float w = 300f;
        float h = 200f;

        // 第一行
        K0_0.GetComponent<RectTransform>().anchoredPosition = new Vector2(0 * w, 0);
        K0_1.GetComponent<RectTransform>().anchoredPosition = new Vector2(1 * w, 0);
        K0_2.GetComponent<RectTransform>().anchoredPosition = new Vector2(2 * w, 0);
        K0_3.GetComponent<RectTransform>().anchoredPosition = new Vector2(3 * w, 0);

        // 第二行
        K1_0.GetComponent<RectTransform>().anchoredPosition = new Vector2(0 * w, -1 * h);
        K1_1.GetComponent<RectTransform>().anchoredPosition = new Vector2(1 * w, -1 * h);
        K1_2.GetComponent<RectTransform>().anchoredPosition = new Vector2(2 * w, -1 * h);
        K1_3.GetComponent<RectTransform>().anchoredPosition = new Vector2(3 * w, -1 * h);

        // 第三行
        K2_0.GetComponent<RectTransform>().anchoredPosition = new Vector2(0 * w, -2 * h);
        K2_1.GetComponent<RectTransform>().anchoredPosition = new Vector2(1 * w, -2 * h);
        K2_2.GetComponent<RectTransform>().anchoredPosition = new Vector2(2 * w, -2 * h);
        K2_3.GetComponent<RectTransform>().anchoredPosition = new Vector2(3 * w, -2 * h);

        // 第四行
        K3_0.GetComponent<RectTransform>().anchoredPosition = new Vector2(0 * w, -3 * h);
        K3_1.GetComponent<RectTransform>().anchoredPosition = new Vector2(1 * w, -3 * h);
        K3_2.GetComponent<RectTransform>().anchoredPosition = new Vector2(2 * w, -3 * h);
        K3_3.GetComponent<RectTransform>().anchoredPosition = new Vector2(3 * w, -3 * h);
    }
}
