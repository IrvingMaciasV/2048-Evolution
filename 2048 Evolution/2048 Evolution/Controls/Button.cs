using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Button
{
    Texture2D texture;
    Vector2 pos;
    Rectangle rect;

    Color color = new Color(255, 255, 255);

    public Vector2 size;

    public Button(Texture2D newTexture, GraphicsDevice graphics)
    {
        texture = newTexture;
        //size = new Vector2(graphics.Viewport.Width / 1, graphics.Viewport.Height / 5);
        size = new Vector2(150, 100);
    }

    bool down = true;
    public bool isClicked;
    public void Update(MouseState mouse, int i)
    {
        if (i == 1)
        {
            rect = new Rectangle((int)pos.X, (int)pos.Y,
                (int)pos.X / 2, (int)pos.Y / 4);
        }
        else
        {
            rect = new Rectangle((int)pos.X, (int)pos.Y,
                (int)pos.X * 8, (int)pos.Y * 8);
        }
        Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

        if (mouseRectangle.Intersects(rect))
        {
            if (color.A == 255) down = false;
            if (color.A == 0) down = true;

            if (down) color.A += 3;
            else color.A -= 3;

            if (mouse.LeftButton == ButtonState.Pressed) isClicked = true;
        }

        else if (color.A < 255)
        {
            color.A += 3;
            isClicked = false;
        }
    }

    public void setPosition(Vector2 newPosition)
    {
        pos = newPosition;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, rect, color);
    }
}