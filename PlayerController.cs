using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, rotationSpeed;
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

    }


    void Update()
    {
        if (_gameManager.gameStage == 1)
        {

            float verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);

            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);

        }


    }
}
