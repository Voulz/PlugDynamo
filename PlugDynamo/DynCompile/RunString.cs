using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;

namespace DynCompile
{
	class RunString
	{
		public AppDomain Domain { get; set; }
		public List<String> Usings { get; } = new List<string>();
		public RunString() : this(AppDomain.CurrentDomain)
		{
		}
		public RunString(AppDomain domain)
		{
			Domain = domain;
			Usings.Add("System");
		}

		public object Run(string code)
		{
			var compilerParameters = new CompilerParameters
			{
				GenerateInMemory = true,
				TreatWarningsAsErrors = false,
				GenerateExecutable = false,
				
			};
			
			foreach (var assembly in Domain.GetAssemblies())
			{
				try
				{
					var location = assembly.Location;
					if (!String.IsNullOrEmpty(location))
					{
						compilerParameters.ReferencedAssemblies.Add(location);
					}
				}
				catch (NotSupportedException)
				{
					// this happens for dynamic assemblies, so just ignore it. 
				}
			}
			var usings = string.Join(Environment.NewLine, Usings.Select((u) => $"using {u};"));

			var finalCode = code;
			var provider = new CSharpCodeProvider();
			var compilerResults = provider.CompileAssemblyFromSource(compilerParameters, new string[] { finalCode });
			if (compilerResults.Errors.HasErrors)
			{
				foreach (CompilerError er in compilerResults.Errors)
				{
					throw new Exception(er.ToString());
				}
			}
			
			var module = compilerResults.CompiledAssembly.GetModules()[0];
			var type = module.GetType("DynCompile.RunDynamo");
			var method = type.GetMethod("Run");

			try
			{
				return method.Invoke(null, null);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				return null;
			}
		}

	}

}
