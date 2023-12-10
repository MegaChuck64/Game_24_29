using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace Game_24_29.Components;

public class TerminalComponent : Component
{
    private List<string> _history;

    public SpriteFont Font { get; private set; }
    public float Spacing { get; set; } = 1.0f;

    public TerminalComponent(GameObject owner, SpriteFont font) : base(owner)
    {
        _history = new List<string>();
        Font = font;
    }

    public void ExecuteCommand(string text)
    {
        _history.Add(text);
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
        var spriteBatch = spriteBatchManager.GetBatch("default");
        var position = Owner.GetComponent<PositionComponent>()?.Position ?? Vector2.Zero;
        var tint = Owner.GetComponent<TintComponent>()?.Tint ?? Color.White;
        var size = Font.MeasureString("A");
        var offset = new Vector2(0, size.Y + Spacing);
        var count = 0;
        for (int i = _history.Count - 1; i >= 0; i--)
        {
            spriteBatch.DrawString(Font, _history[i], position - offset * count, tint);
            count++;
        }
    }
}