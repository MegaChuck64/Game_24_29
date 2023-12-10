using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_24_29.Components;

public class TerminalInputComponent : Component
{
    public SpriteFont Font { get; private set; }
    public Vector2 Offset { get; private set; }
    public string Text { get; private set; } = string.Empty;
    public TerminalInputComponent(GameObject owner, SpriteFont font, Vector2 offset) : base(owner)
    {
        Font = font;
        Owner.Game.Window.TextInput += Window_TextInput;
        Offset = offset;
    }

    private void Window_TextInput(object sender, TextInputEventArgs e)
    {
        if (e.Character == '\b')
        {
            if (Text.Length > 0)
            {
                Text = Text.Remove(Text.Length - 1);
            }
            return;
        }

        Text += e.Character;
    }

    public override void Load()
    {
    }

    public override void Start()
    {
    }


    public override void Update(float dt, InputManager input)
    {
        if (input.WasPressed(Keys.Enter))
        {            
            var terminalComponent = Owner.GetComponent<TerminalComponent>();
            if (terminalComponent != null)
            {
                terminalComponent.ExecuteCommand(Text);
                Text = string.Empty;  
            }
        }
    }

    public override void Draw(SpriteBatchManager spriteBatchManager)
    {
        var spriteBatch = spriteBatchManager.GetBatch("default");
        var position = (Owner.GetComponent<PositionComponent>()?.Position ?? Vector2.Zero) + Offset;
        var tint = Owner.GetComponent<TintComponent>()?.Tint ?? Color.White;
        spriteBatch.DrawString(Font, ">? " + Text, position, tint);
    }
}   