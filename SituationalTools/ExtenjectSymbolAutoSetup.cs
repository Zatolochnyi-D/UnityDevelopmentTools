#if UNITY_EDITOR
using System;
using System.Linq;
using UnityEditor;
using UnityEditor.Build;

namespace DenZ.DevelopmentTools
{
    [InitializeOnLoad]
    public static class ExtenjectSymbolAutoSetup
    {
        private const string SYMBOL = "EXTENJECT";
        private const string NAMESPACE_NAME = "Zenject";

        static ExtenjectSymbolAutoSetup()
        {
            bool hasExtenject = NamespaceExists(NAMESPACE_NAME);

            if (hasExtenject)
                AddDefine(SYMBOL);
            else
                RemoveDefine(SYMBOL);
        }

        private static bool NamespaceExists(string namespaceName)
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Any(x => x.Namespace == namespaceName);
        }

        private static void AddDefine(string symbol)
        {
            var target = EditorUserBuildSettings.selectedBuildTargetGroup;
            var namedTarget = NamedBuildTarget.FromBuildTargetGroup(target);
            var defines = PlayerSettings.GetScriptingDefineSymbols(namedTarget);

            if (!defines.Contains(symbol))
                PlayerSettings.SetScriptingDefineSymbols(namedTarget, defines + ";" + symbol);
        }

        private static void RemoveDefine(string symbol)
        {
            var target = EditorUserBuildSettings.selectedBuildTargetGroup;
            var namedTarget = NamedBuildTarget.FromBuildTargetGroup(target);
            var defines = PlayerSettings.GetScriptingDefineSymbols(namedTarget);

            if (defines.Contains(symbol))
                PlayerSettings.SetScriptingDefineSymbols(namedTarget, defines.Replace(symbol, "").Replace(";;", ";"));
        }
    }
}
#endif