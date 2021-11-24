using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject startPlatform, endPlatform, platform;

    private float blockWidth = 0.5f, blockHeight = 0.2f;

    [SerializeField]
    private int amountToSpawn = 1000;
    private int beginAmount = 0;
    
    private Vector3 lastPosition;

    private List<GameObject> spawnedPlatforms = new List<GameObject>();

    [SerializeField]
    private GameObject playerPrefab;

    void Awake(){
        InstantiateLevel();
    }


    void InstantiateLevel(){
        for (int i = beginAmount; i < amountToSpawn; i++){
            GameObject newPlatform;
            
            //Generating platforms
            if(i == 0){
                newPlatform = Instantiate(startPlatform);
            }

            else if(i == amountToSpawn - 1){
                newPlatform = Instantiate(endPlatform);         
                newPlatform.tag = "EndPlatform";
            }

            else{
                newPlatform = Instantiate(platform);            
            }

            newPlatform.transform.parent = transform;               //Setting Level Generator as parent

            spawnedPlatforms.Add(newPlatform);                      

            if (i == 0){
                lastPosition = newPlatform.transform.position;      //Holding the last position of each platform

                //Instantiating player
                Vector3 temp = lastPosition;
                temp.y += 0.1f;
                Instantiate(playerPrefab, temp, Quaternion.identity);
                continue;
            }

            //Randomizing platform spwan
            int left = Random.Range(0, 2);

            if(left == 0 ){
                newPlatform.transform.position = new Vector3 (lastPosition.x - blockWidth, lastPosition.y + blockHeight, lastPosition.z);
            }
            else{
                newPlatform.transform.position = new Vector3 (lastPosition.x, lastPosition.y + blockHeight, lastPosition.z + blockWidth);
            }

            lastPosition = newPlatform.transform.position;

            //Adding animation to first 25 blocks
            if (i < 25){
                float endPosition = newPlatform.transform.position.y;

                newPlatform.transform.position = new Vector3(newPlatform.transform.position.x, newPlatform.transform.position.y - blockHeight * 3f, newPlatform.transform.position.z);

                newPlatform.transform.DOLocalMoveY(endPosition, 0.3f).SetDelay (i * 0.1f);
            }
        } 
    } 
}
