using UnityEngine;

namespace Commands
{
    public class MoveRightCommand : ISnakeCommand
    {
        public void Execute(Snake snake) => snake.SetDirection(Vector2.right);
    }
}