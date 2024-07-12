using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RemoveTrash : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        Trashable trashable = other.GetComponent<Trashable>();
        if (trashable != null && trashable.isRemove()) { 
            Destroy(other.gameObject);
        }
    }
}
