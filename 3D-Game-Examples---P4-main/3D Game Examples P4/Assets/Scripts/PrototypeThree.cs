using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeThree : MonoBehaviour
{
    public float JumpForce = 10f;
    public float MoveSpeed = 1f;
    public float GravityModifier = 1f;
    public bool IsOnGround = true;

    float horizontalInput;
    float verticalInput;

    private Rigidbody _playerRb;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= GravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if(Input.GetKeyDown(KeyCode.Space) && IsOnGround)
        {
            _playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            IsOnGround = false;
        }

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        _playerRb.AddForce(movement * MoveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
        }
    }
}
