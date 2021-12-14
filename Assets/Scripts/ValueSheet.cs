using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public static class ValueSheet 
{
    public static Dictionary<int, Node_JsonBridge> id_jsonbridge_dic = new Dictionary<int, Node_JsonBridge>();
    public static Dictionary<int, Node> id_NODE_dic = new Dictionary<int, Node>();

    public static Node currentOnSelect;


}

public static class m_Utility
{
    public static async Task<Texture2D> GetRemoteTexture(string url)
    {
        Debug.Log(url);

        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
        {
            // begin request:
            var asyncOp = www.SendWebRequest();
           
            // await until it's done: 
            while (asyncOp.isDone == false)
                await Task.Delay(1000 / 30);//30 hertz

            // read results:
            if (www.isNetworkError || www.isHttpError)
            {
                // log error:
#if DEBUG
                Debug.Log($"{www.error}, URL:{www.url}");
#endif

                // nothing to return on error:
                return null;
            }
            else
            {
                // return valid results:
                return DownloadHandlerTexture.GetContent(www);
            }
        }
        Debug.Log("running??????");
    }
}
