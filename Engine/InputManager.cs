using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine;

public class InputManager
{
    public MouseState MouseState { get; private set; }
    public MouseState PreviousMouseState { get; private set; }
    public KeyboardState KeyboardState { get; private set; }
    public KeyboardState PreviousKeyboardState { get; private set; }

    public InputManager()
    {
        MouseState = Mouse.GetState();
        KeyboardState = Keyboard.GetState();
    }

    public void Update()
    {
        PreviousMouseState = MouseState;
        PreviousKeyboardState = KeyboardState;
        MouseState = Mouse.GetState();
        KeyboardState = Keyboard.GetState();
    }

    public bool WasPressed(Keys key) =>
        KeyboardState.IsKeyDown(key) && PreviousKeyboardState.IsKeyUp(key);

    public bool WasReleased(Keys key) =>
        KeyboardState.IsKeyUp(key) && PreviousKeyboardState.IsKeyDown(key);

    public bool IsDown(Keys key) =>
        KeyboardState.IsKeyDown(key);

    public bool WasPressed(MouseButton button) => button switch
    {
        MouseButton.Left => MouseState.LeftButton == ButtonState.Pressed && PreviousMouseState.LeftButton == ButtonState.Released,
        MouseButton.Right => MouseState.RightButton == ButtonState.Pressed && PreviousMouseState.RightButton == ButtonState.Released,
        MouseButton.Middle => MouseState.MiddleButton == ButtonState.Pressed && PreviousMouseState.MiddleButton == ButtonState.Released,
        _ => false,
    };

    public bool WasReleased(MouseButton button) => button switch
    {
        MouseButton.Left => MouseState.LeftButton == ButtonState.Released && PreviousMouseState.LeftButton == ButtonState.Pressed,
        MouseButton.Right => MouseState.RightButton == ButtonState.Released && PreviousMouseState.RightButton == ButtonState.Pressed,
        MouseButton.Middle => MouseState.MiddleButton == ButtonState.Released && PreviousMouseState.MiddleButton == ButtonState.Pressed,
        _ => false,
    };

    public bool IsDown(MouseButton button) => button switch
    {
        MouseButton.Left => MouseState.LeftButton == ButtonState.Pressed,
        MouseButton.Right => MouseState.RightButton == ButtonState.Pressed,
        MouseButton.Middle => MouseState.MiddleButton == ButtonState.Pressed,
        _ => false,
    };

    public bool WasMoved() =>
        MouseState.Position != PreviousMouseState.Position;

    public bool WasMoved(out int x, out int y)
    {
        x = MouseState.Position.X;
        y = MouseState.Position.Y;
        return WasMoved();
    }

    public bool WasMoved(out Vector2 position)
    {
        position = MouseState.Position.ToVector2();
        return WasMoved();
    }

    public bool WasScrolledUp() =>
        MouseState.ScrollWheelValue > PreviousMouseState.ScrollWheelValue;

    public bool WasScrolledDown() =>
        MouseState.ScrollWheelValue < PreviousMouseState.ScrollWheelValue;

    public bool WasScrolled(out int scrollValue)
    {
        scrollValue = MouseState.ScrollWheelValue;
        return WasScrolledUp() || WasScrolledDown();
    }

    public bool WasScrolled(out int scrollValue, out int delta)
    {
        scrollValue = MouseState.ScrollWheelValue;
        delta = MouseState.ScrollWheelValue - PreviousMouseState.ScrollWheelValue;
        return WasScrolledUp() || WasScrolledDown();
    }

    public bool WasScrolled(out int scrollValue, out int delta, out int x, out int y)
    {
        scrollValue = MouseState.ScrollWheelValue;
        delta = MouseState.ScrollWheelValue - PreviousMouseState.ScrollWheelValue;
        x = MouseState.Position.X;
        y = MouseState.Position.Y;
        return WasScrolledUp() || WasScrolledDown();
    }

    public bool WasScrolled(out int scrollValue, out int delta, out Vector2 position)
    {
        scrollValue = MouseState.ScrollWheelValue;
        delta = MouseState.ScrollWheelValue - PreviousMouseState.ScrollWheelValue;
        position = MouseState.Position.ToVector2();
        return WasScrolledUp() || WasScrolledDown();
    }

    public bool WasScrolled(out int scrollValue, out int delta, out int x, out int y, out Vector2 position)
    {
        scrollValue = MouseState.ScrollWheelValue;
        delta = MouseState.ScrollWheelValue - PreviousMouseState.ScrollWheelValue;
        x = MouseState.Position.X;
        y = MouseState.Position.Y;
        position = MouseState.Position.ToVector2();
        return WasScrolledUp() || WasScrolledDown();
    }

    public bool WasScrolledUp(out int scrollValue) =>
        WasScrolled(out scrollValue) && WasScrolledUp();

    public bool WasScrolledUp(out int scrollValue, out int delta) =>
        WasScrolled(out scrollValue, out delta) && WasScrolledUp();

    public bool WasScrolledDown(out int scrollValue) =>
        WasScrolled(out scrollValue) && WasScrolledDown();

    public bool WasScrolledDown(out int scrollValue, out int delta) =>
        WasScrolled(out scrollValue, out delta) && WasScrolledDown();



    public enum MouseButton
    {
        Left,
        Right,
        Middle,
    }
}