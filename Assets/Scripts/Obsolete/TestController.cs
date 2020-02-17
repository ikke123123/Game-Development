using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    [SerializeField] private TeamMovement teamController;

    private void FixedUpdate()
    {
        teamController.Move(PlayerType.archer, VerticalDirection.forward);
    }
}
