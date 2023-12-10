using Engine;

namespace Game_24_29.Components;

public class SelectableComponent : Component
{
    public bool IsSelected { get; set; } = false;
    public SelectableComponent(GameObject owner) : base(owner)
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