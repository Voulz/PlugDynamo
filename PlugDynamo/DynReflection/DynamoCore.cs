using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Interop;
using AppDomainToolkit;

/*
 * -- Nuget Packages needed:
 * AppDomain Toolkit
 * 
 * -- References added (if not WPF Project):
 * PresentationFramework (for System.Windows.Interop)
 * PresentationCore (for System.Windows.Interop)
 * WindowBase (for System.Windows.Interop)
*/

namespace DynReflection
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


			Console.WriteLine("Starting Dynamo Model...");
			/* equivalent of:
			 * var dynamoModel = DynamoModel.Start(new DynamoModel.DefaultStartConfiguration()
			 * {
			 * 	DynamoCorePath = dynamoCorePath,
			 * 	DynamoHostPath = AppDomain.CurrentDomain.BaseDirectory,
			 * });
			*/
			var tDCore = AppDomain.CurrentDomain.GetAssemblies().First((a) => a.GetName().Name == "DynamoCore" &&
																									Path.GetDirectoryName(a.Location) != AppDomain.CurrentDomain.BaseDirectory);
			var tDModel = tDCore.GetType("Dynamo.Models.DynamoModel");
			var tDModelConfig = tDModel.GetNestedTypes().First((t) => t.Name == "DefaultStartConfiguration");

			var defModelConfig = Activator.CreateInstance(tDModelConfig);
			tDModelConfig.GetProperty("DynamoCorePath").SetValue(defModelConfig, dynamoCorePath, null);
			tDModelConfig.GetProperty("DynamoHostPath").SetValue(defModelConfig, dynamoCorePath, null);

			var dynamoModel = tDModel.GetMethod("Start", new[] { tDModelConfig }).Invoke(null, new[] { defModelConfig });



			Console.WriteLine("Starting Dynamo View Model...");
			/* equivalent of:
			 * var dynamoVM = DynamoViewModel.Start(new DynamoViewModel.StartConfiguration()
			 * {
			 * 	DynamoModel = dynamoModel,
			 * });
			*/
			var tDCoreWPF = AppDomain.CurrentDomain.GetAssemblies().First((a) => a.GetName().Name == "DynamoCoreWpf");
			var tDViewModel = tDCoreWPF.GetType("Dynamo.ViewModels.DynamoViewModel");
			var tDViewModelConfig = tDViewModel.GetNestedTypes().First((t) => t.Name == "StartConfiguration");

			var viewModelConfig = Activator.CreateInstance(tDViewModelConfig);
			tDViewModelConfig.GetProperty("DynamoModel").SetValue(viewModelConfig, dynamoModel, null);

			var dynamoVM = tDViewModel.GetMethod("Start", new[] { tDViewModelConfig }).Invoke(null, new[] { viewModelConfig });


			Debug.Print("Creating Dynamo View...");
			/* equivalent of:
			 * var mwHandle = Process.GetCurrentProcess().MainWindowHandle;
			 * var dynamoView = new DynamoView(dynamoVM);
			 * new WindowInteropHelper(dynamoView).Owner = mwHandle;
			*/
			var mwHandle = Process.GetCurrentProcess().MainWindowHandle;
			var tDView = tDCoreWPF.GetType("Dynamo.Controls.DynamoView");

			var dynamoView = tDView.GetConstructor(new[] { tDViewModel }).Invoke(new[] { dynamoVM });
			new WindowInteropHelper((Window)dynamoView).Owner = mwHandle;


			Debug.Print("Showing the App...");
			tDView.GetMethod("ShowDialog").Invoke(dynamoView, null);
		}
	}

}
