using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team { blue, red };
public enum PlayerType { assassin, archer, tank };
public enum VerticalDirection { up, down, unspecified };
public enum HorizontalDirection { left, right, unspecified };
public enum Tower { one, two, three };

public class TeamController : MonoBehaviour
{
    [Header("Players")]
    [SerializeField] private GameObject assassin = null;
    [SerializeField] private GameObject archer = null;
    [SerializeField] private GameObject tank = null;
    [Header("Tower")]
    [SerializeField] private GameObject tower1 = null;
    [SerializeField] private GameObject tower2 = null;
    [SerializeField] private GameObject tower3 = null;

    private float speed = 0;
    private GameObjectProfile assassinProfile = null;
    private GameObjectProfile archerProfile = null;
    private GameObjectProfile tankProfile = null;

    private float assassinHealth = 0;
    private float archerHealth = 0;
    private float tankHealth = 0;

    private float tower1Health = 0;
    private float tower2Health = 0;
    private float tower3Health = 0;

    //Set speed on awake to predetermined speed in collector script
    private void Awake()
    {
        assassinProfile = CreateProfile(assassin);
        archerProfile = CreateProfile(archer);
        tankProfile = CreateProfile(tank);
    }

    //Movement Public
    public void Move(PlayerType playerType, VerticalDirection vertical, float modifier = 1)
    {
        Move(playerType, HorizontalDirection.unspecified, vertical, modifier);
    }
    public void Move(PlayerType playerType, HorizontalDirection horizontal, float modifier = 1)
    {
        Move(playerType, horizontal, VerticalDirection.unspecified, modifier);
    }
    public void Move(PlayerType playerType, HorizontalDirection horizontal, VerticalDirection vertical, float modifier = 1)
    {
        modifier = Mathf.Clamp(modifier, 0, 1);
        GameObjectProfile tempProfile = SelectPlayer(playerType);
        tempProfile.rb.AddForce(DirectionToVector(horizontal, vertical) * speed);
    }

    //Health Public
    public float RecountHealth(Tower tower, float damage)
    {
        return 0;
    }
    public float RecountHealth(PlayerType playerType, float damage)
    {
        return 0;
    }

    //Movement Private
    private GameObjectProfile SelectPlayer(PlayerType playerType)
    {
        switch (playerType)
        {
            case PlayerType.assassin:

                return assassinProfile;
            case PlayerType.archer:

                return archerProfile;
            case PlayerType.tank:

                return tankProfile;
        }
        return null;
    }
    private GameObjectProfile CreateProfile(GameObject gameobject)
    {
        return new GameObjectProfile()
        {
            gameObject = gameobject,
            transform = gameobject.GetComponent<Transform>(),
            rb = gameobject.GetComponent<Rigidbody>()
        };
    }
    private Vector3 DirectionToVector(HorizontalDirection horizontal, VerticalDirection vertical)
    {
        return new Vector3()
        {
            x = DirectionToInt(horizontal),
            y = DirectionToInt(vertical),
            z = 0
        };
    }
    private int DirectionToInt(HorizontalDirection horizontal)
    {
        switch (horizontal)
        {
            case HorizontalDirection.left:
                return -1;
            case HorizontalDirection.right:
                return 1;
        }
        return 0;
    }
    private int DirectionToInt(VerticalDirection vertical)
    {
        switch (vertical)
        {
            case VerticalDirection.down:
                return -1;
            case VerticalDirection.up:
                return 1;
        }
        return 0;
    }
}

public class GameObjectProfile
{
    public GameObject gameObject;
    public Transform transform;
    public Rigidbody rb;
}
