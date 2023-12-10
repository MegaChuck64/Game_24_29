using Engine;
using Microsoft.Xna.Framework;

namespace Game_24_29.Components;

public class PositionComponent : Component
{
    public Vector2 Position { get; set; } = Vector2.Zero;

    public PositionComponent(GameObject owner) : base(owner)
    {
    }
    public override void Load()
    {
    }

    public override void Start()
    {
    }

    public override void Update(float dt, InputManager input)
    {
    }
    public override void Draw(SpriteBatchManager spriteBatchManager)
    {
    }
}