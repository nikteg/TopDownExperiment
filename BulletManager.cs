using Godot;

public class BulletManager : Node
{
    [Export]
    private NodePath _playerNodePath;
    
    [Export]
    private Resource _bulletResource;

    public override void _Ready()
    {
        GetNode(_playerNodePath).Connect(nameof(Player.FireBullet), this, nameof(CreateBullet));
    }

    public void CreateBullet(Vector2 position, float rotation)
    {
        var bullet = (Node2D)GD.Load<PackedScene>(_bulletResource.ResourcePath).Instance();

        AddChild(bullet);
        
        bullet.Position = position;
        bullet.Rotation = rotation;
    }
}
