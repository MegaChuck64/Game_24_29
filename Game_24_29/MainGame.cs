using Engine;
using Game_24_29.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game_24_29;

public class MainGame : BaseGame
{
    public override void Init()
    {
        BackgroundColor = Color.Black;
    }

    public override void Load(ref SpriteBatchManager spriteBatchManager, ref SceneManager sceneManager)
    {
        var font = Content.Load<SpriteFont>("Fonts/Consolas22");
        sceneManager.AddScene("menu", BuildMenuScene(sceneManager, font));
        sceneManager.AddScene("game", BuildGameScene(font));

        sceneManager.LoadScene("menu");
        sceneManager.StartScene();
    }

    private Scene BuildMenuScene(SceneManager sceneManager, SpriteFont font)
    {
        var menuScene = new Scene();
        var title = new GameObject("title card", this, menuScene);
        title.Components.Add(new TextComponent(title, "Game 24/29", font, 1f, TextComponent.Alignment.Center));
        title.Components.Add(new PositionComponent(title) { Position = new Vector2(CenterScreen.X, 100) });
        title.Components.Add(new TintComponent(title) { Tint = Color.LimeGreen });
        menuScene.GameObjects.Add(title);

        var options = new GameObject("options", this, menuScene);
        options.Components.Add(new SelectableCollectionComponent(options));
        menuScene.GameObjects.Add(options);
        
        var startGame = BuildMenuItem(menuScene, "start game", font, "Start Game", 200, () =>
        { 
            sceneManager.LoadScene("game");
            sceneManager.StartScene();
        }, 
        true);
        menuScene.GameObjects.Add(startGame);

        var leaderboard = BuildMenuItem(menuScene, "leaderboard", font, "Leaderboard", 250, () => sceneManager.LoadScene("leaderboard"));
        menuScene.GameObjects.Add(leaderboard);

        var settings = BuildMenuItem(menuScene, "settings", font, "Settings", 300, () => sceneManager.LoadScene("settings"));
        menuScene.GameObjects.Add(settings);

        return menuScene;
    }

    private GameObject BuildMenuItem(Scene scene, string name, SpriteFont font, string text, int yPos, Action onSelected, bool isSelected = false)
    {
        var go = new GameObject(name, this, scene);
        go.Components.Add(new TextComponent(go, text, font, 0.75f, TextComponent.Alignment.Center));
        go.Components.Add(new PositionComponent(go) { Position = new Vector2(CenterScreen.X, yPos) });
        go.Components.Add(new TintComponent(go) { Tint = Color.LimeGreen });
        go.Components.Add(new SelectableComponent(go) { IsSelected = isSelected });
        go.Components.Add(new OnSelectComponent(go, onSelected));
        go.Components.Add(new OnChosenComponent(go, () => go.GetComponent<TintComponent>().Tint = Color.Yellow));
        go.Components.Add(new OnUnchosenComponent(go, () => go.GetComponent<TintComponent>().Tint = Color.LimeGreen));
        return go;
    }

    private Scene BuildGameScene(SpriteFont font)
    {
        var gameScene = new Scene();
        var title = new GameObject("title card", this, gameScene);
        title.Components.Add(new TextComponent(title, "game 24/29 v0.01", font, 0.5f, TextComponent.Alignment.Left));
        title.Components.Add(new PositionComponent(title) { Position = new Vector2(2, 2) });
        title.Components.Add(new TintComponent(title) { Tint = Color.LimeGreen });
        gameScene.GameObjects.Add(title);

        var terminal = new GameObject("terminal", this, gameScene);
        terminal.Components.Add(new TerminalComponent(terminal, font));
        terminal.Components.Add(new PositionComponent(terminal) { Position = new Vector2(2, CenterScreen.Y * 2 - font.MeasureString("A").Y * 2 - 2) });
        terminal.Components.Add(new TintComponent(terminal) { Tint = Color.LimeGreen });
        terminal.Components.Add(new TerminalInputComponent(terminal, font, new Vector2(0, font.MeasureString("A").Y + 2)));
        gameScene.GameObjects.Add(terminal);

        return gameScene;
    }

    public override void Update(float dt, InputManager input)
    {
    }
    public override void PreDraw(SpriteBatchManager spriteBatchManager)
    {
        spriteBatchManager.GetBatch("default").Begin(
            sortMode: SpriteSortMode.BackToFront, 
            blendState: BlendState.AlphaBlend,
            samplerState: SamplerState.PointWrap,
            depthStencilState: DepthStencilState.DepthRead, 
            rasterizerState: RasterizerState.CullCounterClockwise,
            effect: null,
            transformMatrix: null);
    }
    public override void Draw(SpriteBatchManager spriteBatchManager)
    {
    }
    public override void PostDraw(SpriteBatchManager spriteBatchManager)
    {
        spriteBatchManager.GetBatch("default").End();
    }


}