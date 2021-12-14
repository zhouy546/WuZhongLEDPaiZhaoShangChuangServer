using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadJson : MonoBehaviour
{

    private JsonData itemDate;

    private string jsonString;

    public void Awake()
    {
    //    EventCenter.AddListener(EventDefine.resetCurrentLou, resetCurrentLou);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(INI());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator INI()
    {

        yield return StartCoroutine(readJson());

    }



    IEnumerator readJson()
    {
        string spath = Application.streamingAssetsPath + "/information.json";
        FileInfo info = new FileInfo(spath);
        if (!info.Exists)
        {
            Debug.Log("未找到配置文件，重新生成默认");

        }
        else
        {
            Debug.Log("找到配置文件，从Json载入");
           

            WWW www = new WWW(spath);

            yield return www;

            jsonString = System.Text.Encoding.UTF8.GetString(www.bytes);

            JsonMapper.ToObject(www.text);

            itemDate = JsonMapper.ToObject(jsonString.ToString());


            for (int i = 0; i < itemDate.Count; i++)
            {
                int id = int.Parse(itemDate[i]["id"].ToString());
                int x = int.Parse(itemDate[i]["x"].ToString());
                int y = int.Parse(itemDate[i]["y"].ToString());
                int width = int.Parse(itemDate[i]["width"].ToString());
                int height = int.Parse(itemDate[i]["height"].ToString());
                string url = itemDate[i]["picUrl"].ToString();

                Node_JsonBridge node_JsonBridge = new Node_JsonBridge(id, x, y, width, height, url);

                ValueSheet.id_jsonbridge_dic.Add(id, node_JsonBridge);
            }
        }
        EventCenter.Broadcast(EventDefine.ini);
    }


    public void resetCurrentLou()
    {
      //  Debug.Log("I am running the function SetCurrentLou but dont running inside if");

        //Debug.Log(ValueSheet.louCtrs.Count);
        //if (ValueSheet.louCtrs.Count != 0)
        //{
        //    //Debug.Log("I am running the function SetCurrentLou");
        //    ValueSheet.currentLouCtr = ValueSheet.louCtrs[ValueSheet.louCtrs.Count-1];
        //}
    }


  
}
