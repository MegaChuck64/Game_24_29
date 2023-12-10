using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game_24_29.Components;

public class TextComponent : Component
{
    public string Text { get; set; }
    public SpriteFont Font { get; set; }
    public float Scale { get; set; }
    public Alignment TextAlignment { get; set; }


    public TextComponent(GameObject owner, string text, SpriteFont font, float scale = 1f, Alignment textAlignment = Alignment.Left) : base(owner)
    {
        Text = text;
        Font = font;
        Scale = scale;
        TextAlignment = textAlignment;
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
        spriteBatchManager
            .GetBatch("default")
            .DrawString(
                Font, 
                Text, 
                Owner.GetComponent<PositionComponent>()?.Position ?? Vector2.Zero, 
                Owner.GetComponent<TintComponent>()?.Tint ?? Color.White,
                0f,
                GetOrigin, 
                Scale, 
                SpriteEffects.None, 
                Owner.GetComponent<DepthComponent>()?.Depth ?? 0f);
    }

    public enum Alignment
    {
        Left,
        Center,
        Right
    }

    private Vector2 GetOrigin => TextAlignment switch
    {
        Alignment.Left => Vector2.Zero,
        Alignment.Center => Font.MeasureString(Text) / 2f,
        Alignment.Right => Font.MeasureString(Text),
        _ => throw new NotImplementedException()
    };


}
