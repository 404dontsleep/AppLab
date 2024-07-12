using Oculus.Interaction.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public Transform hand;
    private GameObject weapon;
    private GameObject weapon_collider;
    public Transform weapon_pos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            weapon_collider = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            weapon_collider = null;
        }
    }
    void Awake()
    {
        transform.parent = hand;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }
    public void GrabWeapon()
    {
        if (weapon_collider != null && weapon_pos != null)
        {
            if(weapon != null) Destroy(weapon);
            weapon = Instantiate(weapon_collider);
            weapon.transform.parent = weapon_pos;
            weapon.transform.position = weapon_pos.position;
            weapon.transform.rotation = weapon_pos.rotation;
            weapon.transform.localScale = weapon_pos.localScale;
        }
    }
    public void UnShot()
    {
        if (weapon != null)
        {
            ItemActive itemActive = weapon.GetComponent<ItemActive>();
            if (itemActive != null )
            {
                itemActive.OnKeyUp();
            }
        }
    }
    public void Shot()
    {
        if (weapon != null)
        {
            ItemActive itemActive = weapon.GetComponent<ItemActive>();
            if (itemActive != null)
            {
                itemActive.OnKeyDown();
            }
        }
    }
}
