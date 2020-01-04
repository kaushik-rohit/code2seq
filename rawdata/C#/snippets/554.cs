public static void RunPythonScript(string script, string filename = "script.py", string python = "/usr/bin/python")
		{
			filename = filename.Replace(":", "-"); 

			using (var streamWriter = new StreamWriter(new FileStream(filename, FileMode.Create)))
			{
				// Make this executable
				streamWriter.WriteLine("#!" + python);
				streamWriter.WriteLine("# -*- coding: utf-8 -*-");
				streamWriter.WriteLine("from __future__ import unicode_literals");
				streamWriter.Write(script);
			}
		
			File.SetAttributes(filename, (FileAttributes)((uint)File.GetAttributes(filename) | 0x80000000)); 

			var processInfo = new ProcessStartInfo
			{
				FileName = filename,
				CreateNoWindow = true,
				UseShellExecute = false,
				RedirectStandardOutput = true,
				WorkingDirectory = Directory.GetCurrentDirectory()
			};

			try
			{
				var process = Process.Start(processInfo);
				process.WaitForExit();
				Console.Write(process.StandardOutput.ReadToEnd());
				process.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error in spawning plotting process: " + ex.Message); 
			}
		}