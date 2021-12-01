using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Occlusion_voice_chat_CrossPlatform.plugin 
{
    public static class PluginManager
    {
        private static List<Plugin> plugins = new List<Plugin>();
        
        public static void LoadPlugins(string path)
        {
            // Load all the dlls in the given path
            string[] files = Directory.GetFiles(path, "*.dll");
            foreach (string file in files)
            {
                LoadPlugin(file);
            }
        }
        
        public static void LoadPlugin(string path)
        {
            // Load the dll
            Assembly assembly = Assembly.LoadFrom(path);
            
            // Get all the types in the assembly
            Type[] types = assembly.GetTypes();
            
            // Find all the types that inherit from Plugin
            foreach (Type type in types)
            {
                if (type.IsSubclassOf(typeof(Plugin)))
                {
                    // Create an instance of the plugin
                    Plugin plugin = (Plugin)Activator.CreateInstance(type);
                    
                    // Add the plugin to the list
                    plugins.Add(plugin);
                }
            }
        }
        
        public static void UnloadPlugins()
        {
            // Unload all the plugins
            foreach (Plugin plugin in plugins)
            {
                plugin.Unload();
            }
            
            // Clear the list
            plugins.Clear();
        }


    }

    public abstract class Plugin
    {
        public abstract void Load();
        public abstract void Unload();
    }
}