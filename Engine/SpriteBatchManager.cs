using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Engine;

public class SpriteBatchManager
{
    private Dictionary<string, SpriteBatch> _batches;

    public SpriteBatchManager()
    {
        _batches = new Dictionary<string, SpriteBatch>();
    }

    public void AddBatch(string name, SpriteBatch batch)
    {
        _batches.Add(name, batch);
    }

    public SpriteBatch GetBatch(string name)
    {
        return _batches[name];
    }

    public void RemoveBatch(string name)
    {
        _batches.Remove(name);
    }

    public void Clear()
    {
        _batches.Clear();
    }
}