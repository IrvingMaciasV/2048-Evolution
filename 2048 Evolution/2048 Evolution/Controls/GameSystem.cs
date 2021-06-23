using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

class GameSystem
{
    KeyboardState pastKey;
    public int cont = 0;
    public bool win = false;
    public List<Texture2D> textureObj = new List<Texture2D>();
    public Object[,] arrayObj;
    bool b = true;
    public SoundEffect pop;

    Vector2 posf;

    public GameSystem()
    {
        arrayObj = new Object[4, 4] { { null, null, null, null }, { null, null, null, null }, { null, null, null, null }, { null, null, null, null } };
    }

    ~GameSystem()
    {

    }

    void Add()
    {
        Random rnd = new Random();
        bool cont = true;
        
        while (cont)
        {
            int x = 0, y = 0;
            x = rnd.Next(4);
            y = rnd.Next(4);
            if (arrayObj[y, x] == null)
            {
                arrayObj[y, x] = new Object(x, y, textureObj[0]); ;
                cont = false;
            }

        }
    }

    public void init()
    {
        arrayObj = new Object[4, 4] { { null, null, null, null }, { null, null, null, null }, { null, null, null, null }, { null, null, null, null } };
        Add();
        Add();
        cont = 2;
    }


    public void update()
    {
        //----Si NO es GAME OVER
        if (cont < 16 && win==false)
        {

            //--------DERECHA
            if (Keyboard.GetState().IsKeyDown(Keys.D) && pastKey.IsKeyUp(Keys.D))
            {
                //-----MOVIMIENTO
                for(int i = 0; i <= 3; i++)
                {
                    for(int j = 2; j >= 0; j--)
                    {
                        //posf.X = arrayObj[i, j].XX;
                        //posf.Y = arrayObj[i,j].YY;
                        //-----ACCIONAR MOVIMIENTO
                        if (arrayObj[i, j] != null)
                        {
                            b = true;
                            while (b)
                            {
                                int j2 = j + 1;
                                if (j < 3)
                                {
                                    if (arrayObj[i, j2] == null)
                                    {
                                        posf.X = j2;
                                        
                                        Object temp = arrayObj[i, j];
                                        arrayObj[i, j] = null;

                                        j += 1;
                                        arrayObj[i, j] = temp;
                                        temp.XX = j;
                                        b = true;
                                    }
                                    //COLISION
                                    else
                                    {
                                        b = false;
                                        if (arrayObj[i, j].type == arrayObj[i, j2].type)
                                        {
                                            arrayObj[i, j] = null;
                                            pop.Play();
                                            cont--;
                                            arrayObj[i, j2].type += 1;
                                        }
                                    }
                                }
                                else b = false;
                            }
                        }
                    }
                }

                cont++;
                Add();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) && pastKey.IsKeyUp(Keys.A))
            {
                //-----MOVIMIENTO
                for (int i = 0; i <= 3; i++)
                {
                    for (int j = 1; j <= 3; j++)
                    {
                        //-----ACCIONAR MOVIMIENTO
                        if (arrayObj[i, j] != null)
                        {
                            b = true;
                            while (b)
                            {
                                int j2 = j - 1;
                                if (j > 0)
                                {
                                    if (arrayObj[i, j2] == null)
                                    {
                                        Object temp = arrayObj[i, j];
                                        arrayObj[i, j] = null;
                                        j -= 1;
                                        arrayObj[i, j] = temp;
                                        temp.XX = j;
                                        b = true;
                                    }
                                    //COLISION
                                    else
                                    {
                                        b = false;
                                        if (arrayObj[i, j].type == arrayObj[i, j2].type)
                                        {
                                            arrayObj[i, j] = null;
                                            pop.Play();
                                            cont--;
                                            arrayObj[i, j2].type += 1;
                                        }
                                    }
                                }
                                else b = false;
                            }
                        }
                    }
                }

                cont++;
                Add();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W) && pastKey.IsKeyUp(Keys.W))
            {
                //-----MOVIMIENTO
                for (int j = 0; j <= 3; j++)
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        //-----ACCIONAR MOVIMIENTO
                        if (arrayObj[i, j] != null)
                        {
                            b = true;
                            while (b)
                            {
                                int i2 = i - 1;
                                if (i > 0)
                                {
                                    if (arrayObj[i2, j] == null)
                                    {
                                        Object temp = arrayObj[i, j];
                                        arrayObj[i, j] = null;
                                        i -= 1;
                                        arrayObj[i, j] = temp;
                                        temp.YY = i;
                                        b = true;
                                    }
                                    // COLISION
                                    else
                                    {
                                        b = false;
                                        if (arrayObj[i, j].type == arrayObj[i2, j].type)
                                        {
                                            arrayObj[i, j] = null;
                                            pop.Play();
                                            cont--;
                                            arrayObj[i2, j].type += 1;
                                        }
                                    }
                                }

                                else b = false;
                            }
                        }
                    }
                }

                cont++;
                Add();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S) && pastKey.IsKeyUp(Keys.S))
            {
                //-----MOVIMIENTO
                for (int j = 0; j <= 3; j++)
                {
                    for (int i = 2; i >= 0; i--)
                    {
                        //-----ACCIONAR MOVIMIENTO
                        if (arrayObj[i, j] != null)
                        {
                            b = true;
                            while (b)
                            {
                                int i2 = i + 1;
                                if (i < 3)
                                {
                                    if (arrayObj[i2, j] == null)
                                    {
                                        Object temp = arrayObj[i, j];
                                        arrayObj[i, j] = null;
                                        i += 1;
                                        arrayObj[i, j] = temp;
                                        temp.YY = i;
                                        b = true;
                                    }
                                    // COLISION
                                    else
                                    {
                                        b = false;
                                        if (arrayObj[i, j].type == arrayObj[i2, j].type)
                                        {
                                            arrayObj[i, j] = null;
                                            pop.Play();
                                            cont--;
                                            arrayObj[i2, j].type += 1;
                                        }
                                    }
                                }
                                else b = false;
                            }
                        }
                    }
                }

                cont++;
                Add();
            }
        }


        pastKey = Keyboard.GetState();

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (arrayObj[i, j] != null)
                {
                    int tp = arrayObj[i, j].type - 1;
                    arrayObj[i, j].Update(j, i, textureObj[tp]);
                    if (arrayObj[i, j].type == 11)
                        win = true;
                }
            }
        }

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        for (int ii = 0; ii < 4; ii++)
        {
            for (int jj = 0; jj < 4; jj++)
            {
                if (arrayObj[ii, jj] != null)
                {
                    spriteBatch.Draw(arrayObj[ii,jj].texture, arrayObj[ii, jj].rect, Color.White);
                }
            }
        }
    }
}