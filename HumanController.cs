using System;
using UnityEngine;


public class HumanController : MonoBehaviour
{
    private GameManager _gameManager;
    private Animator animator = new Animator();
    private float[] mapbounds = {-28.0f, 28.0f, -12f, 184f};

    
    private void Awake()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
      animator = GetComponent<Animator>();

    }
    void Start()
    {
        
    }

    
    void Update()
    {
        switch (_gameManager.gameStage )
        {
            case 0:
              animator.Play("Wave");
                break;
            case 1 :
                animator.Play("run");
                animator.SetBool("IsRunning",true);
                run();
                break;
            case 2 :
                animator.Play("idle");
                animator.SetBool("FinishGame",true);
                break;
            case 3 :
                animator.Play("idle");
                animator.SetBool("FinishGame",true);
                break;
                
        }
        
    }

    public void run()
    {
        if (gameObject.transform.position[0] > mapbounds[0] && gameObject.transform.position[0] < mapbounds[1])
        {
            transform.Translate(Vector3.forward * 10 * Time.deltaTime);    
        }
        else
        {
            flipHuman();
            transform.Translate(Vector3.forward * 10 * Time.deltaTime); 
        }
        

    }

    public void flipHuman()
    {
        Vector3 rot = gameObject.transform.rotation.eulerAngles;
        rot.y += 180f;
        transform.rotation = Quaternion.Euler(rot);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _gameManager.gameStage = 3;
            
        }
    }
}
