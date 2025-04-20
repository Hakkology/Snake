using UnityEngine;

namespace Commands
{
    public class MoveUpCommand : ISnakeCommand
    {
        public void Execute(Snake snake) => snake.SetDirection(Vector2.up);
    }
}