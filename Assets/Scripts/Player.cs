using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    CharacterController _controller;
    [SerializeField]
    private float _speed = 3.5f;
    private float _gravity = 1f;
    private float _yVelocity;
    [SerializeField]
    private AudioSource _wakka;
    private bool _isMoving = false;
     [SerializeField]    
    public int lives = 3;
  
    [SerializeField]
    private AudioSource _dead;
    public bool isDead = false;
    [SerializeField]
    private Transform  _initialPos;
    public bool canEatGhosts = false;
    private UI_Manager _uiManager;
    public int yellowCount = 115;
    [SerializeField]
    private AudioSource _victory;
    [SerializeField]
    private AudioSource _bg;
    [SerializeField]
    private AudioSource _chase;
    // public bool isHit = false;
   

 

    

    void Start()
    {
        transform.position = _initialPos.position;
        _controller = GetComponent<CharacterController>(); 
        StartCoroutine(WaitToMove());
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
        if (Input.GetKeyDown(KeyCode.W) && _isMoving == true)
        {
            _wakka.Play();
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            _wakka.Stop();
        }

        MovePlayer();  

     if (transform.position.x >= 21f)
        {
            transform.position = new Vector3(-17f,transform.position.y, 0);
        } 
        else if ( transform.position.x <= -18f )
        {
            transform.position = new Vector3( 20f, transform.position.y, 0);
        }

        if(yellowCount == 0)
        {
            _bg.Stop();
            _victory.Play();
        }
       
    }
   
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Yellow")
        {
            yellowCount --;
            _uiManager.UpdateYellowCount(yellowCount);
        }    
        if(isDead == true)
        {
            DamagePlayer();
        }
    
    }
   
   

    private void MovePlayer() 
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical"); 


        Vector3 direction = new Vector3(horizontalInput, 0 , verticalInput);
        Vector3 velocity = _speed * direction;
        velocity.y = _yVelocity;
        _yVelocity -= _gravity; 

        velocity = transform.transform.TransformDirection(velocity);

        _controller.Move(velocity * Time.deltaTime);
    }
    IEnumerator WaitToMove()
    {
        _isMoving = false;
        _controller.enabled = false;
        yield return new WaitForSeconds(4.1f);
        _controller.enabled = true;
        _isMoving = true;
          
    }
    public void DamagePlayer()
    {
        lives --;
        _dead.Play();
        isDead = false;
        Start();
        // transform.position = _initialPos.transform.position;
    }
    public IEnumerator HitPlayer()
    {
        isDead = true;
        lives --;
        _uiManager.UpdateLives(lives);
        Respawn();
        _dead.Play();
        yield return new WaitForSeconds(1f);
        isDead = false; 
    }
    private void Respawn()
    {
        transform.position = _initialPos.position;
        transform.rotation = _initialPos.rotation;
        StartCoroutine(WaitToMove());  
    }

}
