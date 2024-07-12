using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KhienActive : ItemActive
{
    public ParticleSystem aura;
    public ParticleSystem shot;
    private float lastShot = 0;
    private bool isShot = false;

    void Update()
    {
        if (Time.time - lastShot > 0.3 && isShot == true)
        {
            isShot = false;
            if (aura != null) aura.Stop();
            if (shot != null) shot.Stop();
        }
    }
    public override void OnKeyDown()
    {
        isShot = false;
        if (aura != null) aura.Play();
    }

    public override void OnKeyUp()
    {
        isShot = true;
        lastShot = Time.time;
        if (shot != null) shot.Play();
    }
}
