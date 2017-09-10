
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameStateManagementTutorial.GameStates
{
    interface IGameState
    {
        /// <summary>
        /// Initialize the game settings here 
        /// </summary>
        void Initialize();

        /// <summary>
        /// Load all content here
        /// </summary>
        /// <param name="content"></param>
        void LoadContent(ContentManager content);

        /// <summary>
        /// Unload any content here
        /// </summary>
        void UnloadContent();

        /// <summary>
        /// Updates the game
        /// </summary>
        /// <param name="gameTime"></param>
        void Update(GameTime gameTime);

        /// <summary>
        /// Draws the game
        /// </summary>
        /// <param name="spriteBatch"></param>
        void Draw(SpriteBatch spriteBatch);
    }
}
