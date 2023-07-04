using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    public GameStateManager state;
    private Transform catTransform;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        catTransform = this.GetComponent<Transform>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(catTransform.position);
        if(catTransform.position.z >= playerTransform.position.z){
            SoundManager.Instance.PlaySound(SoundManager.Instance.catScream, Camera.main.transform.position);
            SoundManager.Instance.PlaySound(SoundManager.Instance.onHit, Camera.main.transform.position);
            PlayerHurtUI.Instance.OnPlayerGotCatScratched();
            state.minusLive();
            this.enabled = false;
        }
    }
}
