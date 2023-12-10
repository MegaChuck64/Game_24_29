using System.Collections.Generic;

namespace Engine;

public class Scene
{
    public List<GameObject> GameObjects { get; set; }

    public Scene()
    {
        GameObjects = new List<GameObject>();
    }

    public IEnumerable<GameObject> GetGameObjectsWithComponent<T>() where T : Component
    {
        foreach (var gameObject in GameObjects)
        {
            if (gameObject.GetComponent<T>() != null)
            {
                yield return gameObject;
            }
        }
    }

    public void Load()
    {
        foreach (var gameObject in GameObjects)
        {
            foreach (var component in gameObject.Components)
            {
                component.Load();
            }
        }
    }

    public void Start()
    {
        foreach (var gameObject in GameObjects)
        {
            foreach (var component in gameObject.Components)
            {
                component.Start();
            }
        }
    }

    public void Update(float dt, InputManager input)
    {
        foreach (var gameObject in GameObjects)
        {
            foreach (var component in gameObject.Components)
            {
                component.Update(dt, input);
            }
        }
    }

    public void Draw(SpriteBatchManager spriteBatchManager)
    {
        foreach (var gameObject in GameObjects)
        {
            foreach (var component in gameObject.Components)
            {
                component.Draw(spriteBatchManager);
            }
        }
    }


}