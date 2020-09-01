using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    

    void Start()
    {
        StartCoroutine(WaitToMove());
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
        yield return new WaitForSeconds(4.1f);
        _controller = GetComponent<CharacterController>(); 
        _isMoving = true;
          
    }
}
