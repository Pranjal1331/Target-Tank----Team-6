using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    #region Variables
    public enum AudioTypes {SFX,  Music};
    public AudioTypes audioType;
    public string name;
    public AudioClip clip;
    [Range(0f, 01)]
    public float volume=0.5f;
    [Range(.1f, 3f)]
    public float pitch=1f;
    public bool loop;
    public float spatialBlend=1f;
    [Range(0f, 1f)]

    [HideInInspector]
    public AudioSource source;
    #endregion
}
