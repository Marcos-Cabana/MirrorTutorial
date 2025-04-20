using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] float _playerSpeed = 10f;
    float _moveH;
    float _moveV;
    Vector3 _movement;

    void HandleMovement()
    {
        if(isLocalPlayer)
        {
            _moveH = Input.GetAxis("Horizontal");
            _moveV = Input.GetAxis("Vertical");

            _movement = new Vector3(_moveH,_moveV,0).normalized;

            transform.position += _movement * _playerSpeed * Time.deltaTime;
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }

    }

    private void Update() 
    {
        HandleMovement();    
    }

}
