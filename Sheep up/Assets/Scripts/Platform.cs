using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private Transform[] spikes;

    [SerializeField]
    private GameObject coin;
    private bool fallDown;
    void Start(){
        ActivatePlatform();
    }

    void ActivateSpike(){
        int index = Random.Range(0, spikes.Length);
        spikes[index].gameObject.SetActive(true);
        spikes[index].DOLocalMoveY(0.7f, 1.3f).SetLoops(-1,LoopType.Yoyo).SetDelay(Random.Range(3f,5f));
    }

    void AddCoin(){
        GameObject c = Instantiate(coin);
        c.transform.position = transform.position;
        c.transform.SetParent(transform);
        c.transform.DOLocalMoveY(1f, 0f);
    }

    void ActivatePlatform(){
        int chance = Random.Range(0, 100);

        if(chance > 70){
            int type = Random.Range(0, 8);

            if(type == 0){
                ActivateSpike();
            }
            else if(type == 1){
                AddCoin();
            }
            else if(type == 2){
                fallDown = true;
            }
            else if(type == 3){
                
            }
            else if(type == 4){
                AddCoin();
            }
            else if(type == 5){
                
            }
            else if(type == 6){
                
            }
            else if(type == 7){
                AddCoin();
            }
        }
    }

    void InvokeFalling(){
        gameObject.AddComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision target){
        if (target.gameObject.tag == "Player"){
            if(fallDown){
                fallDown = false;
                Invoke("InvokeFalling", 2f);
            }
        }
    }
   
}
