using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtUI : MonoBehaviour {

    private string PLAYER_HURT_ANIM_TRIGGER = "CatHurtPlayerTrigger";

    public static PlayerHurtUI Instance {get; private set; }

    [SerializeField] private GameObject hurtUIImage;
    [SerializeField] private Animator playerHurtAnimator;

    private void Awake(){
        Instance = this;

        //volume = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_EFFECTS_VOLUME, 1f);
    }

    public void OnPlayerGotCatScratched(){
        playerHurtAnimator.SetTrigger(PLAYER_HURT_ANIM_TRIGGER);
        Debug.Log("this should trigger hurt anim");
    }
}
