using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditNode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EventCenter.Broadcast(EventDefine.onSelected, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EventCenter.Broadcast(EventDefine.onSelected, 1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EventCenter.Broadcast(EventDefine.onSelected, 2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            EventCenter.Broadcast(EventDefine.onSelected, 3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            EventCenter.Broadcast(EventDefine.onSelected, 4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            EventCenter.Broadcast(EventDefine.onSelected, 5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            EventCenter.Broadcast(EventDefine.onSelected, 6);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            EventCenter.Broadcast(EventDefine.onSelected, 7);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            EventCenter.Broadcast(EventDefine.onSelected, 8);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            EventCenter.Broadcast(EventDefine.onSelected, 9);
        }

        if (ValueSheet.currentOnSelect != null)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                ValueSheet.currentOnSelect.UP();
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                ValueSheet.currentOnSelect.Down();
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                ValueSheet.currentOnSelect.Left();
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                ValueSheet.currentOnSelect.Right();
            }
            if (Input.GetKey(KeyCode.A))
            {
                ValueSheet.currentOnSelect.widthIncrease();
            }
            if (Input.GetKey(KeyCode.S))
            {
                ValueSheet.currentOnSelect.widthdecrease();
            }
            if (Input.GetKey(KeyCode.Z))
            {
                ValueSheet.currentOnSelect.heightincrease();
            }
            if (Input.GetKey(KeyCode.X))
            {
                ValueSheet.currentOnSelect.heightdecrease();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SaveJson.instance.WriteJson();
        }


    }
}
