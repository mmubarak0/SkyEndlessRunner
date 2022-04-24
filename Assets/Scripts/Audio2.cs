using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio2 : MonoBehaviour
{
    private AudioSource sound;
    private void Awake() {
        sound = GetComponent<AudioSource>();
    }
    void Update()
    {
        sound.volume = PlayerManager.soundVolume;
    }
}
