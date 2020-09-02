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
    public bool isHit = false;
    [SerializeField]
    private Transform  _initialPos;
    public bool canEatGhosts = false;
    private UI_Manager _uiManager;
    [SerializeField]
    private int Yellow = 115;
    

 

    

    void Start()
    {
        _controller = GetComponent<CharacterController>(); 
        StartCoroutine(WaitToMove());
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        transform.position = _initialPos.position;
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
    }
   
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Yellow")
        {
            Yellow --;
            if(Yellow == 0)
            {
                //YouWin
            }
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
        _controller.enabled = false;
        yield return new WaitForSeconds(4.1f);
        _controller.enabled = true;  
        _isMoving = true;
          
    }
    public IEnumerator HitPlayer()
    {
        isHit = true;
        Restart();
        lives -= 1;
        _dead.Play();
        _uiManager.UpdateLives(lives);
        yield return new WaitForSeconds(1f);
        isHit = false; 
    }
    private void Restart()
    {
        _controller.enabled = false;
        transform.position = _initialPos.position;
        transform.rotation = _initialPos.rotation;
        StartCoroutine(WaitToMove());  
    }
}
