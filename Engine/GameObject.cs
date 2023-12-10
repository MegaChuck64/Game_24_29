using System;
using System.Collections.Generic;
using System.Text;

namespace Engine;

public class GameObject
{
    public BaseGame Game { get; private set; }
    public Scene Scene { get; private set; }
    public string Name { get; set; }
    public List<Component> Components { get; set; }

    public GameObject(string name, BaseGame game, Scene scene)
    {
        Name = name;
        Components = new List<Component>();
        Game = game;
        Scene = scene;
    }

    public void Load()
    {
        foreach (var component in Components)
        {
            component.Load();
        }
    }

    public void Start()
    {
        foreach (var component in Components)
        {
            component.Start();
        }
    }


    public void Update(float dt, InputManager input)
    {
        foreach (var component in Components)
        {
            component.Update(dt, input);
        }
    }

    public void Draw(SpriteBatchManager spriteBatchManager)
    {
        foreach (var component in Components)
        {
            component.Draw(spriteBatchManager);
        }
    }

    public T GetComponent<T>() where T : Component
    {
        foreach (var component in Components)
        {
            if (component is T t)
            {
                return t;
            }
        }
        return null;
    }


}