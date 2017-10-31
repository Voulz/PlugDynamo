using AppDomainToolkit;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Interop;
using Dynamo.Controls;
using Dynamo.Models;
using Dynamo.ViewModels;

/*
 * -- Nuget Packages needed:
 * AppDomain Toolkit
 * Prism v 4.1 (do not update ! Needs to follow Dynamo Core's version)
 * Prism Wpf
 * 
 * -- References added:
 * DynamoCore (from `C:\Program Files\Dynamo\Dynamo Core\1.3\DynamoCore.dll`, set `Copy Local` and `Specific Version` to `False`)
 * DynamoCoreWpf (from `C:\Program Files\Dynamo\Dynamo Core\1.3\DynamoCoreWpf.dll`, set `Copy Local` and `Specific Version` to `False`)
 * 
 * If not WPF Project:
 * PresentationFramework (for System.Windows.Interop)
 * PresentationCore (for System.Windows.Interop)
 * WindowBase (for System.Windows.Interop)
*/

namespace DynReference
{
	public class DynamoCore
	{
		private const string DynCorePathKey = "DynamoCorePath";

		public static void Show(string dynamoCorePath)
		{
			using (var context = AppDomainContext.Create())
			{
				context.Domain.SetData(DynCorePathKey, dynamoCorePath);
				context.RemoteResolver.AddProbePath(dynamoCorePath);
				context.RemoteResolver.AddProbePath(Path.Combine(dynamoCorePath, "nodes"));
				if (!Equals(System.Threading.Thread.CurrentThread.CurrentCulture, CultureInfo.InvariantCulture))
				{
					context.RemoteResolver.AddProbePath(Path.Combine(dynamoCorePath, System.Threading.Thread.CurrentThread.CurrentCulture.Name));
				}

				context.Domain.AssemblyResolve += (e, a) =>
				{
					Console.WriteLine("   ::: MISSING ::: " + a.Name);
					return null;
				};

				context.LoadAssemblyWithReferences(LoadMethod.LoadFrom, Path.Combine(dynamoCorePath, "DynamoCore.dll"));
				context.LoadAssemblyWithReferences(LoadMethod.LoadFrom, Path.Combine(dynamoCorePath, "DynamoCoreWpf.dll"));

				context.Domain.DoCallBack(CallBack);
			}
		}

		private static void CallBack()
		{
			var tmp = System.Reflection.MethodBase.GetCurrentMethod();
			Console.WriteLine($"{tmp.ReflectedType.FullName}.{tmp.Name}()");

			var dynamoCorePath = (string)AppDomain.CurrentDomain.GetData(DynCorePathKey);
			Console.WriteLine($@"Dynamo Core Path: `{dynamoCorePath}`");
			Debug.Assert(!string.IsNullOrEmpty(dynamoCorePath), "DynamoCorePath is Null");


			Console.WriteLine("Creating Path Resolver...");
			var path = new PathResolver("Dynamo Test", dynamoCorePath);

			Console.WriteLine("Starting Dynamo Model...");
			var dynamoModel = DynamoModel.Start(new DynamoModel.DefaultStartConfiguration()
			{
				DynamoCorePath = dynamoCorePath,
				DynamoHostPath = AppDomain.CurrentDomain.BaseDirectory,
				PathResolver = path,
			});
			Console.WriteLine("Starting Dynamo View Model...");
			var dynamoVM = DynamoViewModel.Start(new DynamoViewModel.StartConfiguration()
			{
				DynamoModel = dynamoModel,
			});

			Console.WriteLine("Creating Dynamo View...");
			var mwHandle = Process.GetCurrentProcess().MainWindowHandle;
			var dynamoView = new DynamoView(dynamoVM);
			new WindowInteropHelper(dynamoView).Owner = mwHandle;

			Console.WriteLine("Showing the App...");
			dynamoView.ShowDialog();
		}
	}
}
