using System;
using UnityEngine;
using Zenject;

namespace NoMoreThunder;

internal class LightningManager : IInitializable
{
    private readonly AudioSource[] lightningAudioSources;

    private LightningManager(MenuEnvironmentManager menuEnvironmentManager)
    {
        var thunderMenuEnvironment = menuEnvironmentManager.transform.Find("ThunderMenuEnvironment");
        
        if (thunderMenuEnvironment == null)
        {
            throw new NullReferenceException(
                "Metallica environment was not found. This is likely because you are " +
                "using the mod in the wrong version of the game.");
        }
        
        var logoAudio = thunderMenuEnvironment.transform
            .Find("MetallicaLogo/LogoLightings")
            .GetComponent<AudioSource>();
        
        var lightningAudio = thunderMenuEnvironment.transform
            .Find("LightingsAnimator/LightingMesh")
            .GetComponent<AudioSource>();
        
        lightningAudioSources = [logoAudio, lightningAudio];
    }
    
    public void Initialize()
    {
        foreach (var audioSource in lightningAudioSources)
        {
            audioSource.enabled = false;
        }
    }
}