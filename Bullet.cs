using Godot;

public class Bullet : Area2D
{
    [Export] private int _speed;
    
    public override void _PhysicsProcess(float delta)
    {
        var movement = _speed * delta;
        
        var velocity = Transform.x.Normalized() * movement;

        Position += velocity;
    }
}
