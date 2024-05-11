using System.Linq;
using Segur.PlatformWatcher.Editor.JsonParser;
using UnityEditor;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Segur.PlatformWatcher.Editor
{
    public static class PlatformValidator
    {
        public static void Validate()
        {
            var parser = new PlatformWatcherJsonParser(PlatformWatcherConstants.JsonPath);
            parser.ReadFile();

            if (parser.WhiteList == null)
            {
                return;
            }

            if (parser.WhiteList.Count == 0)
            {
                return;
            }

            var currentBuildTargetGroup = BuildPipeline.GetBuildTargetGroup(EditorUserBuildSettings.activeBuildTarget);

            var success = parser.WhiteList
                .Any(buildTargetGroup => buildTargetGroup == currentBuildTargetGroup);
            if (success)
            {
                return;
            }

            Debug.LogError(
                "Error: You are not on the correct platform.\n<b>Please switch platform to " +
                string.Join(
                    " or ",
                    parser.WhiteList.Select(buildTargetGroup => $"\"{buildTargetGroup}\"")
                )
                + "</b>"
            );
        }
    }
}