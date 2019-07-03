﻿using InfiniteVSTrial.Properties;
using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading;

namespace InfiniteVSTrial
{
    class Program
    {
        static string dirPath = @"C:\Windows\Infinite Visual Studio";
        static string exePath = dirPath + @"\InfiniteVSTrial.exe";

        static void Main(string[] args)
        {
            // Create main dir
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            // Copy exe
            if (System.Reflection.Assembly.GetEntryAssembly().Location != exePath)
            {
                if (File.Exists(exePath))
                    File.Delete(exePath);
                File.Copy(System.Reflection.Assembly.GetEntryAssembly().Location, exePath);
            }
                
            // Inject Task
            InjectSheduledTask();

            // Create powershell dir
            if (!Directory.Exists(dirPath + @"\VSCELicense"))
                Directory.CreateDirectory(dirPath + @"\VSCELicense");

            // Create powershell files
            File.WriteAllBytes(dirPath + @"\VSCELicense\VSCELicense.psd1", Resources.VSCELicense);
            File.WriteAllBytes(dirPath + @"\VSCELicense\VSCELicense.psm1", Resources.VSCELicense1);

            // Import powershell cmdlet
            string res = RunScript(@"Set-ExecutionPolicy Bypass -Force; 
                                    Import-Module -Name 'C:\Windows\Infinite Visual Studio\VSCELicense\VSCELicense.psd1';
                                    Set-VSCELicenseExpirationDate -Version VS2017;
                                    Set-VSCELicenseExpirationDate -Version VS2019;");
            Console.WriteLine(res);


        }

        static void InjectSheduledTask()
        {
            try
            {
                using (var ts = new TaskService())
                {
                    TaskDefinition td = ts.NewTask();
                    td.Settings.MultipleInstances = TaskInstancesPolicy.StopExisting;
                    td.Principal.UserId = @"NT AUTHORITY\SYSTEM";
                    td.RegistrationInfo.Description = "(C) IT skyrius, Inovacijų laboratorija. Vilniaus universitetas Kauno fakultetas.";
                    td.Triggers.Add(new BootTrigger());
                    td.Principal.RunLevel = TaskRunLevel.Highest;
                    td.Actions.Add(new ExecAction(exePath));
                    ts.RootFolder.RegisterTaskDefinition(@"Infinite Visual Studio", td);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        
        static string RunScript(string scriptText)
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(scriptText);
            pipeline.Commands.Add("Out-String");
            Collection<PSObject> results = pipeline.Invoke();
            runspace.Close();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }
            return stringBuilder.ToString();
        }
    }
}
