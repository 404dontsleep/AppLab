using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionObject : MonoBehaviour
{
    private bool isRoot = true;
    public void Clone()
    {
        if (!this.isRoot) return;
        var selection = GameObject.FindGameObjectWithTag("Selection");
        var itemList = GameObject.FindGameObjectWithTag("ItemList");
        if(selection != null && itemList != null)
        {
            GameObject clone = Instantiate(gameObject);
            clone.GetComponent<ActionObject>().isRoot = true;
            clone.transform.parent = itemList.transform;
            clone.transform.position = gameObject.transform.position;
            
            this.isRoot = false;
            this.transform.parent = selection.transform;
        }
    }
    public void ParentToSelection()
    {
        var selection = GameObject.FindGameObjectWithTag("Selection");
        this.transform.parent = selection.transform;
    }
    public void Delete()
    {
        if(isRoot == false)
        {
            Destroy(gameObject);
        }
    }
}
