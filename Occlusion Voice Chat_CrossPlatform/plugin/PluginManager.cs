﻿using System;
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
                Console.WriteLine($"Loading plugin {file}...");
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
                    
                    plugin.Load();

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
        /// This is where you set up all your callbacks and run your initialization logic.
        /// </summary>
        public abstract void Load();
        
        /// <summary>
        /// This is where you dispose of anything you need to. Callbacks are cleared automatically.
        /// </summary>
        public abstract void Unload();
    }
}