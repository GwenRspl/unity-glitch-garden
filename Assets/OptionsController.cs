using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.8f;

    private void Start() {
        this.volumeSlider.value = PlayerPrefsController.GetMasterVolume();
    }

    private void Update() {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer) {
            musicPlayer.SetVolume(this.volumeSlider.value);
        } else {
            Debug.LogWarning("No music player found");
        }
    }

    public void SaveAndExit() {
        PlayerPrefsController.SetMasterVolume(this.volumeSlider.value);
        FindObjectOfType<LevelLoader>().LoadStartScreen();
    }

    public void SetDefaults() {
        this.volumeSlider.value = this.defaultVolume;
    }
}