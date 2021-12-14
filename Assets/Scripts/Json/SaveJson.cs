using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class SaveJson : MonoBehaviour
{
    public static SaveJson instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WriteJson()
    {
        List<Node_JsonBridge> jsonNode = new List<Node_JsonBridge>();

        foreach (var device in ValueSheet.id_NODE_dic)
        {
            Node node = device.Value;
            // Debug.Log(device.Name);
            Node_JsonBridge nodejson = new Node_JsonBridge(node.id,node.x,node.y,node.width,node.height,node.picUrl);

            jsonNode.Add(nodejson);
        }

        string json = ConvertClassToJsonData(jsonNode).ToJson();


        string informationJsonURL = Application.streamingAssetsPath + "/information.json";

        CreatJsonFile(json, informationJsonURL);

    }

    JsonData ConvertClassToJsonData(object obj)
    {


        return JsonMapper.ToObject(JsonMapper.ToJson(obj));
      
    }

    void CreatJsonFile(string jsonStr, string url)
    {
        string spath = url;
        StringBuilder sb = new StringBuilder();
        StreamWriter sw;
        FileInfo info = new FileInfo(spath);
        if (!info.Exists)
        {
            sw = info.CreateText();
            print("文件不存在，创建数据");
        }
        else
        {
            info.Delete();
            print("文件已经存在，删除数据");
            sw = info.CreateText();
        }

        sw.Write(jsonStr);
        sw.Close();

#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }
}
