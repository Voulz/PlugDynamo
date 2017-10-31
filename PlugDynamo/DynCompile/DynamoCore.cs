using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace DynCompile
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
			var code = System.IO.File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PathResolver.cs"));

			var runCode = new RunString(AppDomain.CurrentDomain);
			runCode.Usings.AddRange(new[] { "Dynamo.Models", "Dynamo.ViewModels", "Dynamo.Controls", "Dynamo.Interfaces", "Microsoft.Win32", "System.Diagnostics", "System.Reflection", "System.Windows.Forms", "System.Windows.Interop", "System.Windows" });
			var sR = runCode.Run(code);
		}
	}

}
