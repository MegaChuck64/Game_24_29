using System.Collections.Generic;

namespace Engine;

public class SceneManager
{
    private Dictionary<string, Scene> _scenes;

    public string CurrentScene { get; private set; }

    public SceneManager()
    {
        _scenes = new Dictionary<string, Scene>();
    }

    public void AddScene(string name, Scene scene)
    {
        _scenes.Add(name, scene);
    }

    public void LoadScene(string name)
    {
        if (!_scenes.ContainsKey(name))
            return;

        CurrentScene = name;
        _scenes[name].Load();
    }

    public void StartScene()
    {
        _scenes[CurrentScene].Start();
    }

    public void Update(float dt, InputManager input)
    {
        _scenes[CurrentScene].Update(dt, input);
    }

    public void Draw(SpriteBatchManager spriteBatchManager)
    {
        _scenes[CurrentScene].Draw(spriteBatchManager);
    }

    public void Clear()
    {
        _scenes.Clear();
    }


}