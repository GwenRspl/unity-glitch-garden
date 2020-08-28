using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.8f;

    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultDifficulty = 0;

    private void Start() {
        this.volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        this.difficultySlider.value = PlayerPrefsController.GetDifficulty();
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
        PlayerPrefsController.SetDifficulty(this.difficultySlider.value);
        FindObjectOfType<LevelLoader>().LoadStartScreen();
    }

    public void SetDefaults() {
        this.volumeSlider.value = this.defaultVolume;
        this.difficultySlider.value = this.defaultDifficulty;
    }
}