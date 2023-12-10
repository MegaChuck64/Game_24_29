using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_24_29.Components;

public class OnSelectComponent : Component
{
    public Action OnSelected;
    public OnSelectComponent(GameObject owner, Action onSelected) : base(owner)
    {
        OnSelected = onSelected;
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