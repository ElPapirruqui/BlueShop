using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip error;
    [SerializeField] private AudioClip coins;

    public enum Clip
    {
        Error,
        Coins
    }
    public void PlayAudio(Clip clipType, Vector3 position, float volume = 1)
    {
        AudioClip clip = null;
        switch (clipType)
        {
            case Clip.Error:
                clip = error;
                break;
            case Clip.Coins:
                clip = coins;
                break;
        }
        AudioSource.PlayClipAtPoint(clip, position, volume);
    }
}
