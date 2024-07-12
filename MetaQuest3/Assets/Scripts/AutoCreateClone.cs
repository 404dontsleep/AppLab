using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class AutoCreateClone : MonoBehaviour
{
    public GameObject setting;
    void Awake()
    {
        foreach (GameObject child in GetAllChildrenObjects(gameObject)) {
            child.SetActive(false);
        }
        CloneTag("Free");
    }
    public void CloneTag(string tag)
    {
        if (setting != null)
        {
            List<GameObject> list = GetAllChildrenObjectsWithTag(gameObject, tag);

            foreach (GameObject child in list)
            {
                GameObject sts = Instantiate(setting);
                sts.transform.position = child.transform.position + Vector3.zero;
                child.transform.parent = sts.transform;
                child.SetActive(true);
                sts.transform.parent = gameObject.transform;
            }
        }
    }
    public List<GameObject> GetAllChildrenObjects(GameObject parent)
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in parent.transform)
        {
            children.Add(child.gameObject);
        }
        return children;
    }
    public List<GameObject> GetAllChildrenObjectsWithTag(GameObject parent, string tag)
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in parent.transform)
        {
            if (child.CompareTag(tag)) children.Add(child.gameObject);
        }
        return children;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
