using System.Linq;
using Segur.PlatformWatcher.Editor.JsonParser;
using UnityEditor;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Segur.PlatformWatcher.Editor
{
    public class PlatformWatcherWindow : EditorWindow
    {
        [SerializeField]
        private BuildTargetGroup[] platformWhiteList;

        private readonly PlatformWatcherJsonParser _parser =
            new PlatformWatcherJsonParser(PlatformWatcherConstants.JsonPath);

        private SerializedObject _so;

        [MenuItem("Tools/Platform Watcher")]
        public static void ShowWindow()
        {
            GetWindow<PlatformWatcherWindow>("Platform Watcher");
        }

        private void OnEnable()
        {
            ScriptableObject target = this;
            _so = new SerializedObject(target);

            _parser.ReadFile();

            if (_parser.WhiteList == null || _parser.WhiteList.Count == 0)
            {
                platformWhiteList = new[]
                {
                    BuildTargetGroup.Unknown
                };
                return;
            }

            platformWhiteList = _parser.WhiteList.ToArray();
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField("Select the target platform for this project:", EditorStyles.boldLabel);

            _so.Update();
            var stringsProperty = _so.FindProperty("platformWhiteList");
            EditorGUILayout.PropertyField(stringsProperty, true);
            _so.ApplyModifiedProperties();

            // ReSharper disable once InvertIf
            if (GUILayout.Button("Save"))
            {
                _parser.WhiteList = platformWhiteList
                    .ToList();
                _parser.WriteFile();

                Debug.Log("Target Platform saved.");

                PlatformValidator.Validate();
            }
        }
    }
}