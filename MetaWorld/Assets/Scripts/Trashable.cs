using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashable : MonoBehaviour
{
    private bool remove = false;
    public void TrueRemove()
    {
        remove = true;
    }

    public void FalseRemove()
    {
        remove = false;
    }
    
    public bool isRemove()
    {
        return remove;
    }
}
