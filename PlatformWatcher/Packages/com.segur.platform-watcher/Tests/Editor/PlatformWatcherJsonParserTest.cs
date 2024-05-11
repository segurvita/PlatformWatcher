using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using Segur.PlatformWatcher.Editor.JsonParser;
using Segur.PlatformWatcher.Tests.Editor;
using UnityEditor;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Segur.PlatformWatcher.Editor
{
    public class PlatformWatcherJsonParserTest
    {
        private const string ReadFileTestFilePath = "Tests/Editor/TestAssets/ReadFileTest.json";

        [Test]
        public void SetWhiteListTest()
        {
            var jsonPath = Path.Combine(TestUtility.GetTempFolderPath(), "SetWhiteListTest.json");
            var parser = new PlatformWatcherJsonParser(jsonPath)
            {
                WhiteList = new List<BuildTargetGroup>
                {
                    BuildTargetGroup.Unknown, // Skip
                    BuildTargetGroup.Standalone
                }
            };

            Assert.That(parser.WhiteList.Count, Is.EqualTo(1));
            Assert.That(parser.WhiteList[0], Is.EqualTo(BuildTargetGroup.Standalone));
        }

        [Test]
        public void ReadFileTest()
        {
            var packagePath = TestUtility.GetPackagePath();
            var jsonPath = Path.Combine(packagePath, ReadFileTestFilePath);

            var parser = new PlatformWatcherJsonParser(jsonPath);
            parser.ReadFile();

            Assert.That(parser.WhiteList.Count, Is.EqualTo(2));
            Assert.That(parser.WhiteList[0], Is.EqualTo(BuildTargetGroup.iOS));
            Assert.That(parser.WhiteList[1], Is.EqualTo(BuildTargetGroup.Android));
        }

        [Test]
        public void ReadFileNotFoundTest()
        {
            var jsonPath = Path.Combine(TestUtility.GetTempFolderPath(), "FileNotFound.json");

            var parser = new PlatformWatcherJsonParser(jsonPath);
            parser.ReadFile();

            Assert.That(parser.WhiteList, Is.Not.Null);
            Assert.That(parser.WhiteList.Count, Is.EqualTo(0));
        }

        [Test]
        public void WriteFileTest()
        {
            var jsonPath = Path.Combine(TestUtility.GetTempFolderPath(), "WriteFileTest.json");
            var parser = new PlatformWatcherJsonParser(jsonPath)
            {
                WhiteList = new List<BuildTargetGroup>
                {
                    BuildTargetGroup.WebGL,
                }
            };

            parser.WriteFile();

            Assert.That(File.Exists(jsonPath), Is.True);

            var jsonText = File.ReadAllText(jsonPath, Encoding.UTF8);
            var setting = JsonUtility.FromJson<PlatformWatcherSetting>(jsonText);

            Assert.That(setting, Is.Not.Null);
            Assert.That(setting.buildTargetGroupWhiteList, Is.Not.Null);
            Assert.That(setting.buildTargetGroupWhiteList.Length, Is.EqualTo(1));
            Assert.That(setting.buildTargetGroupWhiteList[0], Is.EqualTo((int)BuildTargetGroup.WebGL));

            if (File.Exists(jsonPath))
            {
                File.Delete(jsonPath);
            }
        }

        [Test]
        public void WriteFileEmptyWhiteListTest()
        {
            var jsonPath = Path.Combine(TestUtility.GetTempFolderPath(), "WriteEmptyFileTest.json");
            var parser = new PlatformWatcherJsonParser(jsonPath)
            {
                WhiteList = new List<BuildTargetGroup>()
            };

            parser.WriteFile();

            Assert.That(File.Exists(jsonPath), Is.True);

            var jsonText = File.ReadAllText(jsonPath, Encoding.UTF8);
            var setting = JsonUtility.FromJson<PlatformWatcherSetting>(jsonText);

            Assert.That(setting, Is.Not.Null);
            Assert.That(setting.buildTargetGroupWhiteList, Is.Not.Null);
            Assert.That(setting.buildTargetGroupWhiteList.Length, Is.EqualTo(0));

            if (File.Exists(jsonPath))
            {
                File.Delete(jsonPath);
            }
        }
    }
}