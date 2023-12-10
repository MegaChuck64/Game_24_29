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
    private SceneManager _sceneManager;
    public TerminalComponent(GameObject owner, SpriteFont font, SceneManager sceneManager) : base(owner)
    {
        _history = new List<string>();
        Font = font;
        _history.Add("Welcome to 24/29...");
        _history.Add("Type 'help' for a list of commands...");
        _sceneManager = sceneManager;
    }

    public void ExecuteCommand(string text)
    {
        text = text.Trim();
        _history.Add("?>" + text);
        var splt = text.Split(' ');
        var command = splt[0];
        switch (command.ToLower())
        {
            case "help":
                _history.Add("help - list of commands");
                _history.Add("clear - clear the terminal");
                _history.Add("exit OR menu - go to menu");
                break;
            case "clear":
                _history.Clear();
                break;
            case "exit":
            case "menu":
                _sceneManager.LoadScene("menu");
                _sceneManager.StartScene();
                break;
            default:
                _history.Add("Command not found");
                break;
        }
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
            spriteBatch.DrawString(Font, _history[i], position - offset * count, tint, 0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0f);
            count++;
        }
    }
}