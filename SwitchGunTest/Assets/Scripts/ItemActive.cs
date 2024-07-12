using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemActive : MonoBehaviour
{
    public abstract void OnKeyDown();
    public abstract void OnKeyUp();
}
