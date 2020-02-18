using UnityEngine;

public class TeamMovement : MonoBehaviour
{
    private TeamController teamController;

    private CharacterController assassin = null;
    private CharacterController archer = null;
    private CharacterController tank = null;
    private float speed = 10;
    private Team team;

    private void Awake()
    {
        teamController = GetComponent<TeamController>();
        assassin = teamController.assassin.GetComponent<CharacterController>();
        archer = teamController.archer.GetComponent<CharacterController>();
        tank = teamController.tank.GetComponent<CharacterController>();
        team = teamController.team;
        //speed = teamController.speed;
        if (team == Team.blue) speed = -1 * speed;
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
        SelectCharacterController(playerType).SimpleMove(DirectionToVector(horizontal, vertical) * speed);
    }

    //Movement Private
    private CharacterController SelectCharacterController(PlayerType playerType)
    {
        switch (playerType)
        {
            case PlayerType.assassin:
                return assassin;
            case PlayerType.archer:
                return archer;
            case PlayerType.tank:
                return tank;
            default:
                return null;
        }
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
