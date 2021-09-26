using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Occlusion_Voice_Chat_CrossPlatform.avalonia.view_models
{
    public class SettingsPageModel : ReactiveObject
    {
        public ObservableCollection<string> HRTFFilters { get; set; } = new ObservableCollection<string>();

        public SettingsPageModel()
        {
            RefreshListBox();
        }

        public void RefreshListBox()
        {
            HRTFFilters.Clear();

            Assembly assembly = Assembly.GetExecutingAssembly();
            DirectoryInfo dir = new DirectoryInfo($"{Path.GetDirectoryName(assembly.Location)}/HRTF sets/");
            FileInfo[] sets = dir.GetFiles();

            for (int i = 0; i < sets.Length; i++)
            {
                if (i != 0 && sets[i].Name.Contains("MIT-48000"))
                {
                    SwapValues(sets, i, 0);
                    break;
                }
            }

            foreach (FileInfo s in sets)
            {
                if (s.Name.EndsWith(".mhr"))
                {
                    HRTFFilters.Add(s.Name);
                }
            }
        }

        private static void SwapValues<T>(T[] source, long index1, long index2)
        {
            T temp = source[index1];
            source[index1] = source[index2];
            source[index2] = temp;
        }
    }
}
