using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunActive : ItemActive
{
    public override void OnKeyDown()
    {
        ParticleSystem particle = gameObject.GetComponentInChildren<ParticleSystem>();
        if (particle != null ) particle.Play();
    }

    public override void OnKeyUp()
    {
        ParticleSystem particle = gameObject.GetComponentInChildren<ParticleSystem>();
        if (particle != null) particle.Stop();
    }
}
