using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Object
{

    public Texture2D texture;
    public Vector2 pos;
    public int type = 1;
    public Rectangle rect;
    public int XX = 1, YY = 1; 

    public Object(int x, int y, Texture2D text)
    {
        texture = text;
        XX = x;
        YY = y;

        pos.X = 150 + (XX * 160);
        pos.Y =100 + (YY * 150);

        rect = new Rectangle((int)pos.X, (int)pos.Y,
              125, 125);
    }

    ~Object()
    {

    }
    public void Update (int x, int y, Texture2D text)
    {
        XX = x;
        YY = y;

        texture = text;
        pos.X = 150 + (XX * 160);
        pos.Y = 100 + (YY * 150);

        rect = new Rectangle((int)pos.X, (int)pos.Y,
              125, 125);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
       spriteBatch.Draw(texture, pos, Color.White);
    }

    public void Move(Vector2 posf, int type)
    {
        bool b = true;
        if (pos.X != posf.X || pos.Y != posf.Y)
            {
            //Derecha
            if (type == 1)
            {
                while (b)
                {
                    pos.X += 10;
                    if (posf.X <= pos.X)
                    {
                        pos.X = posf.X;
                        b = false;
                    }
                }
            }
            
        }
    }
    
}