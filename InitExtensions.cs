using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.CodeExtensions
{
    public sealed class InitExtensions
    {
        private static List<string> DataDirectories = new List<string>()
        {
            "BonusesData",
            "WeaponData",
            "EnemyData",
            "AllyData",
            "SettingsData"
        };
        internal static T LoadData<T>(string reqDirectory, string reqData) where T : class
        {
            var directory = "";
            foreach (var dir in DataDirectories)
            {
                if (dir.Contains(reqDirectory)) directory = dir;
            }

            var result = Resources.Load($"Data/{directory}/{reqData}") as T;
            return result;
        }
    }
}