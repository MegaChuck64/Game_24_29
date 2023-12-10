using Engine;   
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;


namespace Game_24_29.Components;

public class SelectableCollectionComponent : Component
{

    public SelectableCollectionComponent(GameObject owner) : base(owner)
    {
    }

    public override void Load()
    {
    }

    public override void Start()
    {
    }


    private static bool TryGetCurrentSelectedIndex(List<GameObject> selectables, out int index)
    {
        var result = false;
        index = 0;
        for (int i = 0; i < selectables.Count; i++)
        {
            if (selectables[i].GetComponent<SelectableComponent>().IsSelected)
            {
                index = i;
                result = true;
            }
        }

        return result;

    }
    public override void Update(float dt, InputManager input)
    {
        var selectables = Owner.Scene.GetGameObjectsWithComponent<SelectableComponent>().ToList();
        if (TryGetCurrentSelectedIndex(selectables, out int index))
        {
            if (input.WasPressed(Keys.S) || input.WasPressed(Keys.Down))
            {
                index++;
                if (index >= selectables.Count)
                {
                    index = 0;
                }
            }
            else if (input.WasPressed(Keys.W) || input.WasPressed(Keys.Up))
            {
                index--;
                if (index < 0)
                {
                    index = selectables.Count - 1;
                }
            }
            else if (input.WasPressed(Keys.Enter))
            {
                if (selectables[index].GetComponent<OnSelectComponent>() is OnSelectComponent onSelect)
                    onSelect.OnSelected();
            }
            for (int i = 0; i < selectables.Count; i++)
            {
                var select = selectables[i].GetComponent<SelectableComponent>();
                var lastSelected = select.IsSelected;
                select.IsSelected = i == index;

                if (i == index)
                {
                    if (selectables[i].GetComponent<OnChosenComponent>() is OnChosenComponent onChosen)
                        onChosen.OnChosenAction();
                }
                else if (lastSelected)
                {
                    if (selectables[i].GetComponent<OnUnchosenComponent>() is OnUnchosenComponent onUnchosen)
                        onUnchosen.OnUnchosenAction();
                }
            }
        }

    }

    public override void Draw(SpriteBatchManager spriteBatchManager)
    {
    }

}