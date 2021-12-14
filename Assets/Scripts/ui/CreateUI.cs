using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUI : MonoBehaviour
{

    public GameObject PREFAB_node;
    // Start is called before the first frame update

    private void Awake()
    {
        EventCenter.AddListener(EventDefine.ini, CreateNode);
    }

    public void CreateNode()
    {
        foreach (var jsonBridgePair in ValueSheet.id_jsonbridge_dic)
        {        
            GameObject g_node = Instantiate(PREFAB_node, this.transform);

            Node node = g_node.GetComponent<Node>();

            node.ini(jsonBridgePair.Value);
        }
    }
}
