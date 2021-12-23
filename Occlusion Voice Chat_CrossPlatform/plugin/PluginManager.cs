using Occlusion_Voice_Chat_CrossPlatform.plugin.api.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Avalonia.Media.Imaging;

namespace Occlusion_voice_chat_CrossPlatform.plugin 
{
    public static class PluginManager
    {
        public static List<Plugin> Plugins = new List<Plugin>();
        
        public static Dictionary<Plugin, Bitmap> PluginIcons { get; private set; } = new Dictionary<Plugin, Bitmap>();

        private static Bitmap _defaultIcon;
        
        public static string DefaultPluginFolder { get; set; }
        public static Bitmap DefaultIcon
        {
            get
            {
                if (_defaultIcon == null)
                {
                    Assembly executingAssembly = Assembly.GetExecutingAssembly();
                    
                    string[] resources = executingAssembly.GetManifestResourceNames();
                    foreach (string resource in resources)
                    {
                        if (resource.EndsWith("icon.png"))
                        {
                            using (Stream stream = executingAssembly.GetManifestResourceStream(resource))
                            {
                                _defaultIcon = new Bitmap(stream);
                            }
                        }
                    }
                }

                return _defaultIcon;
            }
        }
        
        public static Bitmap GetPluginIcon(Plugin plugin)
        {
            if (PluginIcons.ContainsKey(plugin))
            {
                return PluginIcons[plugin];
            }
            else
            {
                return DefaultIcon;
            }
        }
        
        public static void LoadPlugins(string path)
        {
            // Load all the dlls in the given path
            string[] files = Directory.GetFiles(path, "*.dll");
            foreach (string file in files)
            {
                Console.WriteLine($"Loading plugin {file}...");
                LoadPlugin(file);
            }
        }
        
        public static void LoadPlugin(string path)
        {
            try
            {
                // Load the dll
                Assembly assembly = Assembly.LoadFrom(path);
                
                // Get all the types in the assembly
                Type[] types = assembly.GetTypes();

                Plugin plugin = null;
                
                // Find all the types that inherit from Plugin
                foreach (Type type in types)
                {
                    if (type.IsSubclassOf(typeof(Plugin)))
                    {
                        // Create an instance of the plugin
                        plugin = (Plugin)Activator.CreateInstance(type);
                        
                        plugin.Load();

                        // Add the plugin to the list
                        Plugins.Add(plugin);
                    }
                }
                
                // Load the icon for this plugin
                // Grab a file named "icon.png" from the embedded resources of the plugin dll
                // Wrap this code in a try catch, and instead load the icon.png file embedded resource in this assembly
                // If the icon.png file is not found, load the default icon.png file from the plugin dll
                try
                {
                    string[] resources = assembly.GetManifestResourceNames();
                    foreach (string resource in resources)
                    {
                        if (resource.EndsWith("icon.png"))
                        {
                            using (Stream stream = assembly.GetManifestResourceStream(resource))
                            {
                                if (plugin != null)
                                    PluginIcons[plugin] = new Bitmap(stream);
                                
                                break;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Could not load plugin icon.png file for plugin {assembly.FullName}. " +
                                      $"Using default icon.png file.\n\nException details:\n{e.Message}");
                }

                
                
            }
            catch (IOException e)
            {
                Console.WriteLine($"Failed to load plugin in path {path}.\n\nException details:\n{e.Message}");
            }
        }
        
        public static void UnloadPlugins()
        {
            // Unload all the plugins
            foreach (Plugin plugin in Plugins)
            {
                plugin.Unload();
            }
            
            // Clear the list
            Plugins.Clear();
        }


    }

    /// <summary>
    /// This is the base class for your plugin.
    /// This is where you set up all your callbacks, as well as metadata for occlusion to know about your plugin.
    /// </summary>
    public abstract class Plugin
    {
        public virtual string PluginName { get; }
        
        public virtual string PluginVersion { get; }
        
        /// <summary>
        /// Minimum version of Occlusion your plugin supports
        /// </summary>
        public virtual int MinVersion { get; }
        
        // Maximum version of Occlusion your plugin supports (-1 if there is no max)
        public virtual int MaxVersion { get; }
        
        /// <summary>
        /// The buttons that show up in the plugins menu
        /// </summary>
        public virtual IList<ButtonWrapper> MenuButtons { get; set; }

        /// <summary>
        /// This is where you set up all your callbacks and run your initialization logic.
        /// </summary>
        public abstract void Load();
        
        /// <summary>
        /// This is where you dispose of anything you need to. Callbacks are cleared automatically.
        /// </summary>
        public abstract void Unload();
    }
}