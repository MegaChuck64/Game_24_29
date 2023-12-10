using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Engine;

public abstract class Component
{
    public GameObject Owner { get; private set; }
    public Component(GameObject owner)
    {
        Owner = owner;
    }
    public abstract void Load();
    public abstract void Start();
    public abstract void Update(float dt, InputManager input);
    public abstract void Draw(SpriteBatchManager spriteBatchManager);

}