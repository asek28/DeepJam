using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ParticleColorChanger : MonoBehaviour
{
    public Color particleColor = Color.white; // Default olarak beyaz renk

    void OnValidate()
    {
        ChangeParticleColor(transform); // OnValidate fonksiyonunda renk deðiþikliðini uygula
    }

    void ChangeParticleColor(Transform parentTransform)
    {
        // Parent Transform'daki tüm Particle System'larý bul
        ParticleSystem[] particleSystems = parentTransform.GetComponentsInChildren<ParticleSystem>();

        // Her bir Particle System için renk deðiþikliði uygula
        foreach (ParticleSystem ps in particleSystems)
        {
            var mainModule = ps.main;
            mainModule.startColor = new ParticleSystem.MinMaxGradient(particleColor);
        }
    }
}