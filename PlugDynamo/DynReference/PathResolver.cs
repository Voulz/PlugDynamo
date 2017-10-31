using System;
using System.Collections.Generic;
//using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dynamo.Interfaces;

namespace DynReference
{
	public class PathResolver : IPathResolver
	{
		private readonly List<string> _preloadLibraryPaths;
		private readonly List<string> _additionalNodeDirectories;
		private readonly List<string> _additionalResolutionPaths;

		public PathResolver(string dataFolderName, string dynamoCorePath)
		{

			var currentAssemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
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

			this.UserDataRootFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dynamo", dataFolderName);
			this.CommonDataRootFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Dynamo", dataFolderName);

			Console.WriteLine("Dynamo Nodes Diretory: " + dynNodesDirectory);
			//Console.WriteLine("Nodes Diretory: " + userNodesDirectory);
			Console.WriteLine("Assembly Diretory: " + currentAssemblyDir);
			Console.WriteLine("User: " + UserDataRootFolder);
			Console.WriteLine("Common: " + CommonDataRootFolder);
		}

		public IEnumerable<string> AdditionalNodeDirectories => _additionalNodeDirectories;

		public IEnumerable<string> AdditionalResolutionPaths => _additionalResolutionPaths;

		public IEnumerable<string> PreloadedLibraryPaths => _preloadLibraryPaths;

		public string UserDataRootFolder { get; }

		public string CommonDataRootFolder { get; }
	}
}
