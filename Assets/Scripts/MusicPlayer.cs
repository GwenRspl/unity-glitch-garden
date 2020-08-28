using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    AudioSource audioSource;

    private void Awake() {
        SetUpSingleton();
    }

    private void SetUpSingleton() {
        if (FindObjectsOfType(GetType()).Length > 1) {
            Destroy(this.gameObject);
        } else {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start() {
        this.audioSource = GetComponent<AudioSource>();
        this.audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }

    public void SetVolume(float volume) {
        this.audioSource.volume = volume;
    }

}