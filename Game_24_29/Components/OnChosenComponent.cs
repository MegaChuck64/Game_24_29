using Engine;
using System;

namespace Game_24_29.Components;

public class OnChosenComponent : Component
{
    public Action OnChosenAction;
    public OnChosenComponent(GameObject owner, Action onChosenAction) : base(owner)
    {
        OnChosenAction = onChosenAction;
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