using System.Collections;
using System.Collections.Generic;
using Commands;
using UnityEngine;
public class Snake : MonoBehaviour
{
    private Vector2 _snakeDir = Vector2.right;

    private readonly ISnakeCommand _upCommand = new MoveUpCommand();
    private readonly ISnakeCommand _downCommand = new MoveDownCommand();
    private readonly ISnakeCommand _leftCommand = new MoveLeftCommand();
    private readonly ISnakeCommand _rightCommand = new MoveRightCommand();

    private readonly Queue<ISnakeCommand> _commandQueue = new();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) _commandQueue.Enqueue(_upCommand);
        else if (Input.GetKeyDown(KeyCode.S)) _commandQueue.Enqueue(_downCommand);
        else if (Input.GetKeyDown(KeyCode.A)) _commandQueue.Enqueue(_leftCommand);
        else if (Input.GetKeyDown(KeyCode.D)) _commandQueue.Enqueue(_rightCommand);
    }

    void FixedUpdate()
    {
        if (_commandQueue.Count > 0)
        {
            var command = _commandQueue.Dequeue();
            command.Execute(this);
        }

        transform.position = new Vector3
        {
            x = Mathf.Round(transform.position.x) + _snakeDir.x,
            y = Mathf.Round(transform.position.y) + _snakeDir.y,
            z = 0
        };
    }

    public void SetDirection(Vector2 dir)
    {
        _snakeDir = dir;
    }

    public Vector2 CurrentDirection => _snakeDir;
}