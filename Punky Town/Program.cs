using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Positron;

namespace PunkyTown
{
    static class Program
    {

        [STAThread]
        public static void Main()
        {
            #region Load Global Configuration
            // Load the global configuration file
            try
            {
                using (var global_config_stream = new System.IO.FileStream("Global.config", System.IO.FileMode.Open))
                    GlobalConfiguration.Load(global_config_stream);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine("Global configuration not found. Using global defaults.");
                GlobalConfiguration.LoadDefaults();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to load global configuration. Using global defaults.");
                GlobalConfiguration.LoadDefaults();
            }
            #endregion
            #region Load Game Configuration
            // Load the game configuration file
            GameConfiguration configuration;
            try
            {
                using (var game_config_stream = new System.IO.FileStream("PunkyTown.config", System.IO.FileMode.Open))
                    configuration = GameConfiguration.Load(game_config_stream);
            }
            catch(System.IO.FileNotFoundException ex)
            {
                Console.WriteLine("Game configuration not found. Using game defaults.");
                configuration = new GameConfiguration();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to load game configuration. Using game defaults.");
                configuration = new GameConfiguration();
            }
            #endregion
            #region Meat and Potatos
            // Instantiate the main window
            // this also sets up OpenGL
            var main_window = new ThreadedRendering();

            // Initialize textures and sounds
            Texture.Initialize(configuration.ArtworkPathFull);
            Sound.InitialSetup();

            var game = new PositronGame(main_window, configuration);

            #region Load Scene Data
            SceneConfigurator scene_config = new SceneConfigurator(new Type[]{
                typeof(SpinnyCircle),
                typeof(SpinnyCamera),
            });
            Scene main_scene;
            try
            {
                throw new System.IO.FileNotFoundException("Test!");
                using (var scene_stream = new System.IO.FileStream("CurrentScene.config", System.IO.FileMode.Open))
                    main_scene = scene_config.Load(scene_stream, game);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine("Scene data not found. Using scene defaults.");
                main_scene = SceneMainFactory.Create(game);
            }
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Unable to load scene data. Using scene defaults.");
            //    main_scene = SceneMainFactory.Create(game);
            //}
            #endregion
            game.CurrentScene = main_scene;
            // Run the window thread
            try
            {
                main_window.Run();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                #region Store Scene Data
                // Store the current scene
                //try
                //{
                    using (var global_config_stream = new System.IO.FileStream("CurrentScene.config", System.IO.FileMode.Create))
                        scene_config.Store(global_config_stream, game.CurrentScene);
                    SpriteBase.Animation.Store(game);
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine("Unable to write scene data.\n" + ex);
                //}
                #endregion
                #region Store Game Configuration
                // Store the game configuration file
                try
                {
                    using (var game_config_stream = new System.IO.FileStream("PunkyTown.config", System.IO.FileMode.Create))
                        configuration.Store(game_config_stream);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to write game configuration.\n" + ex);
                }
                #endregion
                #region Store Global Configuration
                // Store the global configuration file
                try
                {
                    using (var global_config_stream = new System.IO.FileStream("Global.config", System.IO.FileMode.Create))
                        GlobalConfiguration.Store(global_config_stream);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to write global configuration.\n" + ex);
                }
                #endregion
            }
            #endregion
        }
    }
}
