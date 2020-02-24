using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private Team team = Team.blue;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        if (team == Team.blue) speed = -1 * speed;
    }

    public void Move(VerticalDirection vertical, float modifier = 1)
    {
        Move(HorizontalDirection.unspecified, vertical, modifier);
    }
    public void Move(HorizontalDirection horizontal, float modifier = 1)
    {
        Move(horizontal, VerticalDirection.unspecified, modifier);
    }
    public void Move(HorizontalDirection horizontal, VerticalDirection vertical, float modifier = 1)
    {
        modifier = Mathf.Clamp(modifier, 0, 1);
        characterController.SimpleMove(DirectionToVector(horizontal, vertical) * speed * modifier);
    }
    public void Move(Vector3 input, float modifier = 1)
    {
        modifier = Mathf.Clamp(modifier, 0, 1);
        input.y = 0;
        input = input.normalized;
        characterController.SimpleMove(input * speed * modifier);
    }

    private Vector3 DirectionToVector(HorizontalDirection horizontal, VerticalDirection vertical)
    {
        return new Vector3()
        {
            x = DirectionToInt(horizontal),
            y = 0,
            z = DirectionToInt(vertical)
        }.normalized;
    }
    private int DirectionToInt(HorizontalDirection horizontal)
    {
        switch (horizontal)
        {
            case HorizontalDirection.left:
                return -1;
            case HorizontalDirection.right:
                return 1;
            default:
                return 0;
        }
    }
    private int DirectionToInt(VerticalDirection vertical)
    {
        switch (vertical)
        {
            case VerticalDirection.back:
                return -1;
            case VerticalDirection.forward:
                return 1;
            default:
                return 0;
        }
    }
}
