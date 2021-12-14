using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YunqiLibrary;
public class udp : MonoBehaviour
{
    UDP m_udp;
    
    // Start is called before the first frame update
    void Start()
    {
        m_udp = new UDP(29010, dealWidthUDP);
    }

    // Update is called once per frame
    public void dealWidthUDP(string s)
    {
        Debug.Log(s);

        string[]  strArray= s.Split('_');

        string path = strArray[0];

        int id = int.Parse(strArray[1]);

        ValueSheet.id_NODE_dic[id].picUrl = path;

        ValueSheet.id_NODE_dic[id].LoadImage();

    }



    private void OnApplicationQuit()
    {
        if (m_udp != null)
        {
            m_udp.AbortThread();
        }

    }

    //private async void loadImage()
    //{
    //    ValueSheet.id_NODE_dic[id].LoadImage();

    //}
}
