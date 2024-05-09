using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Audio Config", menuName = "Guns/Audio Config", order = 5)]
public class AudioConfigScriptableObject : ScriptableObject, System.ICloneable
{
    [Range(0, 1f)]
    public float Volume = 1f;
    public AudioClip[] FireClips;
    public AudioClip EmptyClip;
    public AudioClip ReloadClip;

    public void PlayShootingClip(AudioSource AudioSource, bool IsLasBullet = false){
        AudioSource.PlayOneShot(FireClips[Random.Range(0, FireClips.Length)],Volume);
    }

    public void PlayOutOfAmmoClip(AudioSource AudioSource)
    {
        if(EmptyClip != null)
        {
            AudioSource.PlayOneShot(EmptyClip, Volume);
        }
    }

    public void PlayReloadClip(AudioSource AudioSource)
    {
        if(ReloadClip != null)
        {
            AudioSource.PlayOneShot(ReloadClip, Volume);
        }
    }

    public object Clone()
    {
        AudioConfigScriptableObject config = CreateInstance<AudioConfigScriptableObject>();

        Utilities.CopyValues(this, config);

        return config;
    }
}
