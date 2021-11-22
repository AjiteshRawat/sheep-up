using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour{
    public static GameplayManager instance;

    [SerializeField]
    private Text scoreText;
    private int score;

    void Awake(){
        if (instance == null){
            instance = this;
        }
    }

    public void IncremeantScore(){
        score++;
        scoreText.text = "x" + score;
    }

    public void RestartGame(){
        Invoke("ReloadGame", 3f);
    }

    void ReloadGame(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }
}
