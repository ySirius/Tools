using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSTool
{
    /// <summary>
    /// 注册表  HKEY_LOCAL_MACHINE/SOFTWARE 节点下
    /// </summary>
    public static class RegistryHelper
    {
        private const string Node = "SOFTWARE";

        public static string GetRegistryData(string node, string key)
        {
            string registData;
            RegistryKey hkml = Registry.LocalMachine;
            RegistryKey software = hkml.OpenSubKey(Node, true);
            RegistryKey dir = software.OpenSubKey(node, true);
            if (dir == null) return "";
            registData = dir.GetValue(key)?.ToString();
            return registData;
        }

        /// <summary>
        /// 写入注册表
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="name">注册项名称</param>
        /// <param name="value">注册项值</param>
        public static void WriteRegistry(string node, string name, string value)
        {
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey software = hklm.OpenSubKey(Node, true);
            RegistryKey dir = software.CreateSubKey(node);
            if (dir != null)
                dir.SetValue(name, value);
        }

        /// <summary>
        /// 删除注册表
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        public static void DeleteRegistry(string node, string name)
        {
            string[] aimnames;
            RegistryKey hkml = Registry.LocalMachine;
            RegistryKey software = hkml.OpenSubKey(Node, true);
            RegistryKey dir = software.OpenSubKey(node, true);
            if (dir == null) return;
            aimnames = dir.GetSubKeyNames();
            foreach (string aimKey in aimnames)
            {
                if (aimKey == name)
                    dir.DeleteSubKeyTree(name);
            }
        }

        /// <summary>
        /// 查询节点是否存在
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsRegeditExit(string node, string name)
        {
            bool _exit = false;
            string[] subkeyNames;
            RegistryKey hkml = Registry.LocalMachine;
            RegistryKey software = hkml.OpenSubKey(Node, true);
            RegistryKey dir = software.OpenSubKey(node, true);
            subkeyNames = dir.GetSubKeyNames();
            foreach (string keyName in subkeyNames)
            {
                if (keyName == name)
                {
                    _exit = true;
                    return _exit;
                }
            }
            return _exit;
        }
    }
}
