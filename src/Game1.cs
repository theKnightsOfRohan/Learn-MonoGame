using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Learn_MonoGame;

public class Game1 : Game
{
    Texture2D ballTexture;
    Vector2 ballPosition;
    float ballSpeed;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        ballPosition = new Vector2(
            _graphics.PreferredBackBufferWidth / 2,
            _graphics.PreferredBackBufferHeight / 2
        );

        ballSpeed = 100f;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        ballTexture = Content.Load<Texture2D>("ball");
    }

    protected override void Update(GameTime gameTime)
    {
        if (
            GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
            || Keyboard.GetState().IsKeyDown(Keys.Escape)
        )
            Exit();

        // TODO: Add your update logic here
        var kstate = Keyboard.GetState();
        var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

        foreach (Keys key in kstate.GetPressedKeys())
        {
            switch (key)
            {
                case Keys.Up:
                    ballPosition.Y -= ballSpeed * delta;
                    break;
                case Keys.Down:
                    ballPosition.Y += ballSpeed * delta;
                    break;
                case Keys.Left:
                    ballPosition.X -= ballSpeed * delta;
                    break;
                case Keys.Right:
                    ballPosition.X += ballSpeed * delta;
                    break;
            }
        }

        if (ballPosition.X - ballTexture.Width / 2 < 0)
        {
            ballPosition.X = ballTexture.Width / 2;
        }
        if (ballPosition.X + ballTexture.Width / 2 > _graphics.PreferredBackBufferWidth)
        {
            ballPosition.X = _graphics.PreferredBackBufferWidth - ballTexture.Width / 2;
        }

        if (ballPosition.Y - ballTexture.Height / 2 < 0)
        {
            ballPosition.Y = ballTexture.Height / 2;
        }
        if (ballPosition.Y + ballTexture.Height / 2 > _graphics.PreferredBackBufferHeight)
        {
            ballPosition.Y = _graphics.PreferredBackBufferHeight - ballTexture.Height / 2;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.Draw(
            ballTexture,
            ballPosition,
            null,
            Color.White,
            0f,
            new Vector2(ballTexture.Width / 2, ballTexture.Height / 2),
            1f,
            SpriteEffects.None,
            0f
        );
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
