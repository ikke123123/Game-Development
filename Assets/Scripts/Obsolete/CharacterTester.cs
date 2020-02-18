using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTester : MonoBehaviour
{
    [SerializeField] private float speed = 0;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        characterController.SimpleMove(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * speed);
    }
}
