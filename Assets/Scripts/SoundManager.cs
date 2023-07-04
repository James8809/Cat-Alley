using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour{

    
    //private const string PLAYER_PREFS_SOUND_EFFECTS_VOLUME = "SoundEffectsVolume";

    public static SoundManager Instance {get; private set; }

    public AudioSource catScream;
    public AudioSource missShot;
    public AudioSource hitBeam;
    public AudioSource onShoot;
    public AudioSource jump;
    public AudioSource onDeath;
    public AudioSource onHit;
    public AudioSource catMeowAudioSourcePrefab;
    public AudioSource scoreAudioSourcePrefab;



    private float volume = 1f;

    private void Awake(){
        Instance = this;

    }


    public void PlaySound(AudioSource audioSource, Vector3 position, float volumeMultiplier = 1f){
        audioSource.Play();
    }

    public void PlaySoundSpawn(AudioSource audioSourcePrefab, Vector3 position, float volumeMultiplier = 1f){
        AudioSource audioSource = Instantiate(audioSourcePrefab, position, Quaternion.identity);
        audioSource.Play();
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }

}

