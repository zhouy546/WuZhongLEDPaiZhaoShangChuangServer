using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    #region json
    public int id;
    public int x;
    public int y;
    public int width;
    public int height;

    public string picUrl;


    #endregion
    public GameObject debugUI;

    public Image m_image;
    public void ini(Node_JsonBridge node_JsonBridge)
    {
        id = node_JsonBridge.id;
        x = node_JsonBridge.x;
        y = node_JsonBridge.y;
        width = node_JsonBridge.width;
        height = node_JsonBridge.height;
        picUrl = node_JsonBridge.picUrl;
        ValueSheet.id_NODE_dic.Add(id, this);

        SetImageCanvas();
    }

    public void Start()
    {
        EventCenter.AddListener<int>(EventDefine.onSelected, IsOnselected);
    }

    public void SetImageCanvas()
    {
        this.transform.localPosition = new Vector3(x, y);

        this.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);

         LoadImage();
    }

    public async void LoadImage()
    {

        string path = "D://¹²ÏíÎÄ¼þ/" + picUrl;


        Texture2D _texture = await m_Utility.GetRemoteTexture(path);

        m_image.sprite = Sprite.Create(_texture, new Rect(0, 0, _texture.width, _texture.height), new Vector2(0.5f, 0.5f));
    }

    public void UP()
    {
        y += 1;
        this.transform.localPosition = new Vector3(x, y);
    }

    public void Down()
    {
        y-= 1;
        this.transform.localPosition = new Vector3(x, y);
    }

    public void Left()
    {
        x -= 1;
        this.transform.localPosition = new Vector3(x, y);
    }

    public void Right()
    {
        x += 1;
        this.transform.localPosition = new Vector3(x, y);
    }

    public void widthIncrease()
    {
        width += 1;
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
    }
    public void widthdecrease()
    {
        width -= 1;
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
    }

    public void heightincrease()
    {
        height += 1;
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
    }

    public void heightdecrease()
    {
        height -= 1;
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
    }

    void IsOnselected(int _id)
    {
        if(id == _id)
        {
            ValueSheet.currentOnSelect = this;
            debugUI.SetActive(true);
        }
        else
        {
            debugUI.SetActive(false);
        }
    }
}
