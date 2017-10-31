using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Reflection;
using Dynamo.Controls;
using Dynamo.Interfaces;
using Dynamo.Models;
using Dynamo.ViewModels;
using Microsoft.Win32;
using System.Windows.Forms;

/*
 * This File is not compiled directly. It is just copied in the output directory. It will be compiled at runtime.
 */

namespace DynCompile
{

	class Helper
	{
		public static IEnumerable<string> GetDynamoCoreLocations()
		{
			const string regKey64 = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\";
			//Open HKLM for 64bit registry
			try
			{
				var regKey = Microsoft.Win32.RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
				//Open Windows/CurrentVersion/Uninstall registry key
				regKey = regKey.OpenSubKey(regKey64);

				//Get "InstallLocation" value as string for all the subkey that starts with "Dynamo"
				return regKey.GetSubKeyNames().Where(s => s.StartsWith("Dynamo Core")).Select(
					(s) => regKey.OpenSubKey(s).GetValue("InstallLocation") as string);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return new string[] { };
			}
		}
	}

	public class RunDynamo
	{
		private static string _dynCorePath;

		public static string DynamoCorePath
		{
			get { return _dynCorePath; }
		}

		public static object Run()
		{
			var log = "";

			var tmp = System.Reflection.MethodBase.GetCurrentMethod();
			log += tmp.ReflectedType.FullName + "." + tmp.Name + "\n";

			var dynpath = Helper.GetDynamoCoreLocations();
			_dynCorePath = dynpath.LastOrDefault();
			//			Console.WriteLine("Dynamo Core Path: " + DynamoCorePath);
			log += "Dynamo Core Path: " + DynamoCorePath + "\n";


			//			Debug.Print("Creating Path Resolver...");
			log += "Creating Path Resolver..." + "\n";
			var path = new PathResolver("Dynamo Test", DynamoCorePath);

			//			Debug.Print("Starting Dynamo Model...");
			log += "Starting Dynamo Model..." + "\n";
			var dynamoModel = DynamoModel.Start(new DynamoModel.DefaultStartConfiguration()
			{
				DynamoCorePath = DynamoCorePath,
				DynamoHostPath = AppDomain.CurrentDomain.BaseDirectory,
				PathResolver = path,
			});

			//			Debug.Print("Starting Dynamo View Model...");
			log += "Starting Dynamo View Model..." + "\n";
			var dynamoVM = DynamoViewModel.Start(new DynamoViewModel.StartConfiguration()
			{
				DynamoModel = dynamoModel,
			});

			//			Debug.Print("Creating Dynamo View...");
			log += "Creating Dynamo View..." + "\n";
			var mwHandle = Process.GetCurrentProcess().MainWindowHandle;
			var dynamoView = new DynamoView(dynamoVM);
			new WindowInteropHelper(dynamoView).Owner = mwHandle;

			//			Debug.Print("Showing the App...");
			log += "Showing the App..." + "\n";
			dynamoView.ShowDialog();
			return log;
		}
	}


	public class PathResolver : IPathResolver
	{
		private readonly List<string> _preloadLibraryPaths;
		private readonly List<string> _additionalNodeDirectories;
		private readonly List<string> _additionalResolutionPaths;
		private readonly string _userDataRootFolder;
		private readonly string _commonDataRootFolder;

		public PathResolver(string dataFolderName, string dynamoCorePath)
		{
			var currentAssemblyDir = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
			var dynNodesDirectory = Path.Combine(dynamoCorePath, "nodes");
			//var userNodesDirectory = Path.Combine(currentAssemblyDir, "nodes");

			if (!Directory.Exists(dynNodesDirectory))
				throw new DirectoryNotFoundException(dynNodesDirectory); // probably wrong folder of Dynamo

			//if (!Directory.Exists(userNodesDirectory)) Directory.CreateDirectory(userNodesDirectory);

			_preloadLibraryPaths = new List<string>
			{
				"VMDataBridge.dll",
				"DSCoreNodes.dll",
				"DSOffice.dll",
				"DSIronPython.dll",
				"FunctionObject.ds",
				"BuiltIn.ds",
				"DynamoConversions.dll",
				"DynamoUnits.dll",
				"DynZeroTouch.dll", //We can directly load our custom nodes
			};

			// Add an additional node processing folder
			//_additionalNodeDirectories = new List<string> { dynNodesDirectory, userNodesDirectory };
			_additionalNodeDirectories = new List<string> { dynNodesDirectory };

			// Add the Revit_20xx folder for assembly resolution
			_additionalResolutionPaths = new List<string> { currentAssemblyDir, dynamoCorePath };

			_userDataRootFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dynamo", dataFolderName);
			_commonDataRootFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Dynamo", dataFolderName);

			Console.WriteLine("Dynamo Nodes Diretory: " + dynNodesDirectory);
			//Console.WriteLine("Nodes Diretory: " + userNodesDirectory);
			Console.WriteLine("Assembly Diretory: " + currentAssemblyDir);
			Console.WriteLine("User: " + UserDataRootFolder);
			Console.WriteLine("Common: " + CommonDataRootFolder);
		}



		public IEnumerable<string> AdditionalNodeDirectories
		{
			get { return _additionalNodeDirectories; }
		}

		public IEnumerable<string> AdditionalResolutionPaths
		{
			get { return _additionalResolutionPaths; }
		}

		public IEnumerable<string> PreloadedLibraryPaths
		{
			get { return _preloadLibraryPaths; }
		}

		public string UserDataRootFolder
		{
			get { return _userDataRootFolder; }
		}

		public string CommonDataRootFolder
		{
			get { return _commonDataRootFolder; }
		}
	}

}
