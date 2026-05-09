using System;
using UnityEditor;
using UnityEngine;

namespace Fara.FaraMultiVrmConverter.Editor
{
    public static class PackageExporter
    {
        private const string PackagePath = "Assets/Fara/FaraMultiVrmConverter";

        /// <summary>
        /// CI entry point: Unity -executeMethod Fara.FaraMultiVrmConverter.Editor.PackageExporter.Export
        /// Optional CLI args: -output path/to/output.unitypackage
        /// </summary>
        public static void Export()
        {
            var outputPath = ParseOutputArg();

            Debug.Log($"[PackageExporter] Exporting '{PackagePath}' → '{outputPath}'");

            AssetDatabase.ExportPackage(
                PackagePath,
                outputPath,
                ExportPackageOptions.Recurse
            );

            Debug.Log($"[PackageExporter] Done: {outputPath}");
        }

        private static string ParseOutputArg()
        {
            var args = Environment.GetCommandLineArgs();
            for (int i = 0; i < args.Length - 1; i++)
            {
                if (args[i] == "-output")
                    return args[i + 1];
            }
            return "FaraMultiVrmConverter.unitypackage";
        }
    }
}
