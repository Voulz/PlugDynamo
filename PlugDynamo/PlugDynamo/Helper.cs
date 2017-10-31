using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace PlugDynamo
{
	class Helper
	{
		public static IEnumerable<string> GetDynamoCoreLocations()
		{
			const string regKey64 = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\";
			//Open HKLM for 64bit registry
			try
			{
				var regKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
				//Open Windows/CurrentVersion/Uninstall registry key
				regKey = regKey.OpenSubKey(regKey64);

				//Get "InstallLocation" value as string for all the subkey that starts with "Dynamo"
				return regKey.GetSubKeyNames().Where(s => s.StartsWith("Dynamo Core")).Select(
					(s) => regKey.OpenSubKey(s).GetValue("InstallLocation") as string);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return new string[] {};
			}
		}
	}
}
