using Engine;

namespace Game_24_29.Components;

public class DepthComponent : Component
{
    public float Depth { get; set; } = 0f;

    public DepthComponent(GameObject owner) : base(owner)
    {
    }

    public override void Draw(SpriteBatchManager spriteBatchManager)
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
}