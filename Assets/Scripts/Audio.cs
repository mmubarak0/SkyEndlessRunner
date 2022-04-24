using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    private AudioSource sound;
    public GameObject vol;
    private Slider slider;
    private void Awake() {
        sound = GetComponent<AudioSource>();
        slider = vol.GetComponent<Slider>();
    }
    void Update()
    {
        sound.volume = PlayerManager.soundVolume;
    }

    public void setVolume()
    {
        PlayerManager.soundVolume = slider.value;
    }
}
