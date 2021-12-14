using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_JsonBridge 
{
    public int id;
    public int x;
    public int y;
    public int width;
    public int height;
    public string picUrl;

    public Node_JsonBridge()
    {

    }

    public Node_JsonBridge(int _id,int _x,int _y,int _width,int _height,string _picUrl){
        id = _id;
        x = _x;
        y = _y;
        width = _width;
        height = _height;
        picUrl = _picUrl;
    }

}
