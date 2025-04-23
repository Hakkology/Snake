using System.Collections;
using System.Collections.Generic;
using Commands;
using UnityEngine;
public class Snake : MonoBehaviour
{
    public Transform SnakePrefab;
    public ScoreManager scoreManager;
    public HealthManager healthManager;

    private Vector2 _snakeDir = Vector2.right;

    private readonly ISnakeCommand _upCommand = new MoveUpCommand();
    private readonly ISnakeCommand _downCommand = new MoveDownCommand();
    private readonly ISnakeCommand _leftCommand = new MoveLeftCommand();
    private readonly ISnakeCommand _rightCommand = new MoveRightCommand();

    private readonly Queue<ISnakeCommand> _commandQueue = new();
    private List<Transform> _snakeList = new List<Transform>();

    public YellowFlashController yellowFlash;

    void Start() 
    {
        _snakeList.Add(transform);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) _commandQueue.Enqueue(_upCommand);
        else if (Input.GetKeyDown(KeyCode.S)) _commandQueue.Enqueue(_downCommand);
        else if (Input.GetKeyDown(KeyCode.A)) _commandQueue.Enqueue(_leftCommand);
        else if (Input.GetKeyDown(KeyCode.D)) _commandQueue.Enqueue(_rightCommand);
    }

    void FixedUpdate()
    {
        for (int i = _snakeList.Count -1; i > 0; i--)
        {
            _snakeList[i].position = _snakeList[i-1].position;
        }

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

    private void Grow()
    {
        Transform kuyruk = Instantiate(SnakePrefab);
        kuyruk.position = _snakeList[_snakeList.Count - 1].position;
        _snakeList.Add(kuyruk);

        // optional
        if (yellowFlash != null)
        {
            float flashAmount = 0.2f;
            yellowFlash.Flash(flashAmount, 0.25f);
            Debug.Log("FLASH TETİKLENDİ");
        }
    }

    public List<Transform> GetSnakeSegments()
    {
        return _snakeList;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Food"))
        {
            Grow();
            scoreManager.AddScore(10);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("GoodFood"))
        {
            Grow();
            scoreManager.AddScore(30); 
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Wall") || 
            other.gameObject.layer == LayerMask.NameToLayer("Snake"))
        {
            healthManager.ApplyDamage(1); // ✅ Doğrudan çağrı
            ResetSnake();
        }
    }


    public void ResetSnake()
    {
        // Kuyrukları temizle
        for (int i = _snakeList.Count - 1; i > 0; i--)
        {
            Destroy(_snakeList[i].gameObject);
        }

        _snakeList.Clear();
        _snakeList.Add(transform);
        transform.position = Vector3.zero;
        _snakeDir = Vector2.right;

        Debug.Log("Yılan sıfırlandı.");
    }


}