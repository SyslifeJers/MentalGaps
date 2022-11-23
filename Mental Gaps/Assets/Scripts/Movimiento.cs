using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float moveSpeed;

    private Vector2 input;
    private Animator _animatorn;

    private Rigidbody2D GetRigidbody2D;
    // Start is called before the first frame update
    private void Awake()
    {
        _animatorn = GetComponent<Animator>();
    }
    private void Start()
    {
        GetRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //if (!isMoving)
        //{

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        _animatorn.SetFloat("Move X", input.x);
        _animatorn.SetFloat("Move Y", input.y);

        if (input.x != 0 || input.y != 0)
        {
            _animatorn.SetFloat("UMove X", input.x);
            _animatorn.SetFloat("UMove Y", input.y);
        }

    }
    private void FixedUpdate()
    { 
        GetRigidbody2D.MovePosition(GetRigidbody2D.position + input* moveSpeed * Time.fixedDeltaTime);

    }

}
