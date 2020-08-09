using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed=10.0f;
    [SerializeField]
    private float _gravity= 1.0f;
    [SerializeField]
    private float _jumpHeight=15.0f;
    private float _yVelocity;
    private bool _canDoubleJump;
   // [SerializeField ]
    //private int _coins;
    private UIManager _uiManager;
    [SerializeField]
    private int _lives=3;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(_uiManager==null)
        {
            Debug.LogError("The UI Manager Is NULL");
        }
        _uiManager.LivesDisplay(_lives);
    }
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput,0,0);
        Vector3 velocity = direction * _speed;
        if(_controller.isGrounded == true)
        {
            _yVelocity = _jumpHeight;
           // if(Input.GetKeyDown(KeyCode.Space))
           // {
               
           //    _canDoubleJump = true;
           // }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                 _yVelocity += _jumpHeight;
               // if(_canDoubleJump = true)
              //  {
                   
               //     _canDoubleJump = false;
              //  }
            }
            _yVelocity -= _gravity;
        }  
        velocity.y=_yVelocity;   
        _controller.Move(velocity * Time.deltaTime);   
    }
   /* public void AddCoins()
    {
        _coins ++;
        _uiManager.CoinDisplay(_coins);
    }*/
    public void Damage()
    {
        _lives--;
        _uiManager.LivesDisplay(_lives);    
        if(_lives<1)
        {
            SceneManager.LoadScene(0); 
        }                                                                
    }
}
