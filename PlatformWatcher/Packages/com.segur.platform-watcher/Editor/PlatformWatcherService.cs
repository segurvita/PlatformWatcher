using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

// ReSharper disable once CheckNamespace
namespace Segur.PlatformWatcher.Editor
{
    [InitializeOnLoad]
    public class PlatformWatcherCore : IPreprocessBuildWithReport, IActiveBuildTargetChanged
    {
        public int callbackOrder => 0;

        static PlatformWatcherCore()
        {
            PlatformValidator.Validate();
        }

        public void OnActiveBuildTargetChanged(BuildTarget previousTarget, BuildTarget newTarget)
        {
            PlatformValidator.Validate();
        }

        public void OnPreprocessBuild(BuildReport report)
        {
            PlatformValidator.Validate();
        }
    }
}