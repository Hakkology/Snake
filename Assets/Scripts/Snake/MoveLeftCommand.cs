
using UnityEngine;

namespace Commands
{
    public class MoveLeftCommand : ISnakeCommand
    {
        public void Execute(Snake snake) => snake.SetDirection(Vector2.left);
    }
}
