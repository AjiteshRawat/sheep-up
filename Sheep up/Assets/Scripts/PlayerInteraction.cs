using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Rigidbody rb;
    private bool playerDied;
    private CameraFollow cameraFollow;
    void Awake(){
        rb = GetComponent<Rigidbody>();
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
    }

    void Update(){
        if(!playerDied){
            if(rb.velocity.sqrMagnitude > 60){
                playerDied = true;
                cameraFollow.CanFollow = false;

                SoundManager.instance.GameEndSound();
                GameplayManager.instance.RestartGame();
            }
        }
    }

    void OnTriggerEnter(Collider target){
        if(target.tag == "Coin"){
            target.gameObject.SetActive(false);
            SoundManager.instance.PickedUpCoin();
            GameplayManager.instance.IncremeantScore();
        }
        if(target.tag == "Spike"){
            cameraFollow.CanFollow = false;
            gameObject.SetActive(false);
            SoundManager.instance.GameEndSound();
            GameplayManager.instance.RestartGame();
        }
    }

    void OnCollisionEnter(Collision target){
        if(target.gameObject.tag == "EndPlatform"){
            SoundManager.instance.GameStartSound();
            GameplayManager.instance.RestartGame();
        }
    }
}
