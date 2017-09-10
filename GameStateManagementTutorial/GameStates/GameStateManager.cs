
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace GameStateManagementTutorial.GameStates
{
    public class GameStateManager
    {
        /// <summary>
        /// Instance of the game state manager
        /// </summary>
        private static GameStateManager _instance;
        private ContentManager _content;

        /// <summary>
        /// Stack for the screens
        /// </summary>
        private Stack<GameState> _screens = new Stack<GameState>();

        public static GameStateManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameStateManager();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Sets the content manager
        /// </summary>
        /// <param name="content"></param>
        public void SetContent(ContentManager content)
        {
            _content = content;
        }

        /// <summary>
        /// Adds a new screen to the stack
        /// </summary>
        /// <param name="screen">The screen to add</param>
        public void AddScreen(GameState screen)
        {
            try
            {
                _screens.Push(screen);
                _screens.Peek().Initialize();
                if (_content != null)
                {
                    _screens.Peek().LoadContent(_content);
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Changes the screen. Removes the top one. 
        /// </summary>
        /// <param name="screen">The screen to change to</param>
        public void ChangeScreen(GameState screen)
        {

            try
            {
                ClearScreens();
                AddScreen(screen);
            }
            catch (Exception ex)
            {

            }

        }

        /// <summary>
        /// Removes the top screen from the stack
        /// </summary>
        public void RemoveScreen()
        {
            if (_screens.Count > 0)
            {
                try
                {
                    var screen = _screens.Peek();

                    _screens.Pop();
                }
                catch (Exception ex)
                {

                }
            }
        }

        /// <summary>
        /// Clears all the screen from the list
        /// </summary>
        public void ClearScreens()
        {
            while (_screens.Count > 0)
            {
                var screen = _screens.Peek();

                _screens.Pop();
            }
        }


        /// <summary>
        /// Unloads the content from the screen
        /// </summary>
        public void UnloadContent()
        {
            foreach (GameState state in _screens)
            {
                state.UnloadContent();
            }
        }

        /// <summary>
        /// Updates the top screen. 
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            try
            {
                if (_screens.Count > 0)
                {
                    _screens.Peek().Update(gameTime);
                }
            }
            catch (Exception ex)
            {
                 
            }
        }

        /// <summary>
        /// Renders the top screen.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            try
            {
                if (_screens.Count > 0)
                {
                    _screens.Peek().Draw(spriteBatch);
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
