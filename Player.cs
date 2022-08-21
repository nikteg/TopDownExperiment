using Godot;

public class Player : KinematicBody2D
{
  
  [Export] private int _speed = 200;
  
  [Signal]
  public delegate void FireBullet(Vector2 position, float rotation);

  private Vector2 _velocity;

  private void GetInput()
  {
    
    LookAt(GetGlobalMousePosition());
    
    var velocity = new Vector2();

    if (Input.IsActionPressed("up"))
    {
      velocity.y -= 1;
    }

    if (Input.IsActionPressed("down"))
    {
      velocity.y += 1;
    }

    if (Input.IsActionPressed("left"))
    {
      velocity.x -= 1;
    }

    if (Input.IsActionPressed("right"))
    {
      velocity.x += 1;
    }

    _velocity = velocity.Normalized() * _speed;
  }

  public override void _UnhandledInput(InputEvent @event)
  {
    if (@event.IsActionPressed("shoot"))
    {
      Shoot();
    }
  }

  private void Shoot()
  {
    EmitSignal(nameof(FireBullet), Position, Rotation);
  }

  public override void _PhysicsProcess(float delta)
  {
    GetInput();
    _velocity = MoveAndSlide(_velocity);
  }
}
