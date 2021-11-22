using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private float damping = 2f;
    private float height = 10f;
    private bool canFollow;
    private Vector3 startPosition;
    void Start(){
        player = GameObject.FindWithTag("Player").transform;
        startPosition = transform.position;
        canFollow = true;
    }

    void Update(){
        Follow();
    }

    void Follow(){
        if(canFollow){
            transform.position = Vector3.Lerp(transform.position,new Vector3(player.position.x + 10f, player.position.y + height, player.position.z - 10f),Time.deltaTime * damping);
        }
    }

    public bool CanFollow{
        get{
            return canFollow;
        }
        set{
            canFollow = value;
        }
    }
}
