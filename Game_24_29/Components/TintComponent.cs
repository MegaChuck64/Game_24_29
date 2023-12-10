using Engine;
using Microsoft.Xna.Framework;

namespace Game_24_29.Components;

public class TintComponent : Component
{
    public Color Tint { get; set; }
    public TintComponent(GameObject owner) : base(owner)
    {
        Tint = Color.White;
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