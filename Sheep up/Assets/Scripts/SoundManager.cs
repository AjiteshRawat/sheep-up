using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField]
    private AudioSource gameEnd, gameStart, coinSound, jumpSound; 
    void Awake(){
        if(instance == null){
            instance = this;
        }
    }
    
    public void GameStartSound(){
        gameStart.Play();
    }

    public void GameEndSound(){
        gameEnd.Play();
    }

    public void PickedUpCoin(){
        coinSound.Play();
    }

    public void JumpSound(){
        jumpSound.Play();
    }
}
