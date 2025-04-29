using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startGameUI;
    [SerializeField] private List<GameObject> VehicleModels;
    [SerializeField] private FollowPlayer camerascript;
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject pl;
    [SerializeField] private GameObject WonGameUI;
    [SerializeField] private Text timer;
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private Text reverse;
    private float[] mapbounds = {-28.0f, 28.0f, -12f, 184f};
    public int gameStage = 0;
    private int maxCoinNR = 1;
    public int collectedCoins;
    private int time = 0;
    public int rev = 3;
    void Start()
    {
        
    }
    
    void Update()
    {
        switch (gameStage)
        {
            case 0:
                StartGameState();
                break;
            case 1:
                MidGameState();
                break;
            case 2:
                EndGameState();
                break;
            case 3:
                GameOverState();
                break;
        }
        
    }

    private void GameOverState()
    {
        GameOverUI.SetActive(true);
        camerascript.EndGame();
    }

    private void EndGameState()
    {
        camerascript.EndGame();
        WonGameUI.SetActive(true);
        

    }

    private IEnumerator startTimer()
    {
        while (gameStage == 1)
        {
            yield return new WaitForSeconds(1f);
            time++;
            timer.text = time.ToString();   
        }
    }

    private IEnumerator reversseTimer()
    {
        
        while (rev != 0)
        {
            yield return new WaitForSeconds(1);
            rev--;
            reverse.text = rev.ToString();
        }

        gameStage = 1;

    }

    private void StartGameState()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(VehicleModels[0]);
            StartCoroutine(reversseTimer());
            spawnCoin();
            startGameUI.SetActive(false);
            
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(VehicleModels[1]);
            StartCoroutine(reversseTimer());
            spawnCoin();
            startGameUI.SetActive(false);
            
        }

    }
    
    private void MidGameState()
    {
        StartCoroutine(reversseTimer());
        if (!camerascript.isGameOn)
        {
            camerascript.FindPlayer();
            StartCoroutine(startTimer());    
        }
        
        
        

    }

    public void spawnCoin()
    {
        if (collectedCoins != maxCoinNR)
        {
            Vector3 pos = new Vector3(Random.Range(mapbounds[0],mapbounds[1]),1.1f,Random.Range(mapbounds[2],mapbounds[3]));
            Instantiate(coin,pos,new Quaternion(0,0,0,0));   
        }
        else
        {
            gameStage = 2;
        }
        
    }
    
}
