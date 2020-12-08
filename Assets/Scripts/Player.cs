﻿using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private GameplayInput _gameplayInput;
    private Rigidbody _rigidbody;
    
    [SerializeField] private float speed;
    [SerializeField] private Light light;
    [SerializeField] private Text coinsText;
    
    private int coins;

    [SerializeField] private Item currentItem;
    
    private void Awake()
    {
        _gameplayInput = new GameplayInput();
        _gameplayInput.Enable();
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movementVector = _gameplayInput.Player.Movement.ReadValue<Vector2>();
        bool isJumping = _gameplayInput.Player.Jump.triggered;

        Vector3 movement = new Vector3(movementVector.x, 0f, movementVector.y);
        _rigidbody.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            light.color = Color.red;
            coins += 1;
            SetCountText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            light.color = Color.white;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            light.color = Color.blue;
        }
    }
    
    private void SetCountText()
    {
        coinsText.text = $"Coins: {coins}";
    }
}
