using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;
using static System.Net.Mime.MediaTypeNames;
public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;
    float newW, newH;
    [SerializeField]
    RawImage rawImage;
    [SerializeField]
    Vector2 basicSize;//规定大小，记录初始大小，调用
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        LoadTexture();
    }

    // Update is called once per frame
    void LoadTexture()//加载图片
    {
        OpenFileDialog openfiledialog = new OpenFileDialog();
        openfiledialog.Filter = "JPG|*.jpg|PNG图片|*.png";//过滤器格式：图片文件
        if (openfiledialog.ShowDialog() == DialogResult.OK)//判断状态
        {
            string texPath = openfiledialog.FileName;//路径
            Debug.Log(texPath);
            Texture2D tex2d = new Texture2D(1, 1);
            byte[] texByte = File.ReadAllBytes(texPath);
            tex2d.LoadImage(texByte);
            rawImage.texture = tex2d;//界面显示
            TextureScalResize(tex2d);//调用缩放s函数
            //GetComponent<PuzzleImageFiller>().FillAllSlots(tex2d);
            rawImage.color = new Color(1, 1, 1, 0.5f);//颜色虚化做底图
            newW = (int)(newW / 300);
            newH = (int)(newH / 200);
            if (newW % 2 != 0)
            {
                newW += 1;
            }
            if (newH % 2 != 0)
            {
                newH += 1;
            }
            PuzzlePool.Instance.CreatePuzzle((int)newW, (int)newH);
            rawImage.GetComponent<RectTransform>().sizeDelta = new Vector2(newW*300 , newH*200 );//更换图片缩放
        }
    }
    void TextureScalResize(Texture2D tex)
    {
        bool isWidth = tex.width > tex.height ? true : false;//返回:两边值检测，横竖判断
        float longSide = isWidth == true ? tex.width : tex.height;//横d竖）赋值长边 
        bool expend;
        float ratio;//%比率
        if (isWidth)//横图
        {
            expend = longSide > basicSize.x ? false : true;//长边是否大于basic
            ratio = expend == true ? longSide / basicSize.x : basicSize.x / longSide; //？左边判断，：左边判断结果1；右边判断结果0
        }
        else
        {
            expend = longSide > basicSize.y ? false : true;
            ratio = expend == true ? longSide / basicSize.y : basicSize.y / longSide;
        }//调宽度

        newW = expend == true ? tex.width / ratio : tex.width * ratio;
        newH = expend == true ? tex.height / ratio : tex.height * ratio;
        if (newH > basicSize.y)
        {
            ratio = basicSize.y / newH;
            newW = newW * ratio;
            newH = newH * ratio;

        }//调高   



    }
}
