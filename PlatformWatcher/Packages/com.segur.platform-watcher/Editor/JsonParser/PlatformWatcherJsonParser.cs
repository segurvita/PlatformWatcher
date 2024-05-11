using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Segur.PlatformWatcher.Editor.JsonParser
{
    public class PlatformWatcherJsonParser
    {
        private readonly string _jsonPath;

        private List<BuildTargetGroup> _whiteList = new List<BuildTargetGroup>();

        public List<BuildTargetGroup> WhiteList
        {
            get => _whiteList;
            set
            {
                _whiteList = value
                    .Where(buildTargetGroup => buildTargetGroup != BuildTargetGroup.Unknown)
                    .ToList();
            }
        }

        public PlatformWatcherJsonParser(string inputJsonPath)
        {
            _jsonPath = inputJsonPath;
        }

        public void ReadFile()
        {
            if (!File.Exists(_jsonPath))
            {
                return;
            }

            var jsonText = File.ReadAllText(_jsonPath, Encoding.UTF8);
            if (string.IsNullOrEmpty(jsonText))
            {
                return;
            }

            var setting = JsonUtility.FromJson<PlatformWatcherSetting>(jsonText);
            if (setting == null)
            {
                return;
            }

            WhiteList = setting.buildTargetGroupWhiteList
                .Select(buildTargetGroup => (BuildTargetGroup)buildTargetGroup)
                .ToList();
        }

        public void WriteFile()
        {
            var setting = new PlatformWatcherSetting
            {
                buildTargetGroupWhiteList = WhiteList.Select(buildTargetGroup => (int)buildTargetGroup).ToArray()
            };

            var jsonText = JsonUtility.ToJson(setting, true);
            if (string.IsNullOrEmpty(jsonText))
            {
                return;
            }

            File.WriteAllText(_jsonPath, jsonText, Encoding.UTF8);
        }
    }
}