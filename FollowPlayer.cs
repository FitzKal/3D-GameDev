using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;
    public Boolean isGameOn = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
        isGameOn = true;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (isGameOn)
        {
            transform.position = player.transform.position + offset;
        }
        //transform.LookAt(player.transform.position);    
    }

    public void EndGame()
    {
        isGameOn = false;
    }

    
}
