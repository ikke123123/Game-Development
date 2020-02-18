using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    [SerializeField] private TeamMovement teamController = null;
    [SerializeField] private VerticalDirection verticalDirection = VerticalDirection.back;

    private void FixedUpdate()
    {
        teamController.Move(PlayerType.archer, verticalDirection);
    }
}