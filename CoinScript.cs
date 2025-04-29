using System;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private GameManager _gameManager;
    private float[] mapbounds = { -28.0f, 28.0f, -12f, 184f};

    private void Awake()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _gameManager.collectedCoins++;
            _gameManager.spawnCoin();
            Destroy(gameObject);
        }
    }
}
