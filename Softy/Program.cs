using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading;

namespace Softy
{
    public class Program
    {
        static void Main() => new Program().Run().GetAwaiter().GetResult();
        public async Task Run()
        {


            
            string[] FNStuff = { "FortniteClient-Win64-Shipping_EAC.exe", "FortniteClient-Win64-Shipping_BE.exe", "FortniteLauncher.exe" };

            foreach (string procname in FNStuff)
            {
                var process = Process.GetProcessesByName(procname);
                foreach (var proc in process)
                {
                    proc.Kill();
                }
            }

            Console.Title = "SoftyFN Launcher";


            Softy.Log("Bienvenido a SoftyFN!");
            Thread.Sleep(1000);

            string TempPath = Path.GetTempPath();
            var Path1 = "";
            var version = "1";

            var path1 = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Epic\\UnrealEngineLauncher\\LauncherInstalled.dat"));
            dynamic Json = JsonConvert.DeserializeObject(path1);

            foreach (var installion in Json.InstallationList)
            {
                if (installion.AppName == "Fortnite")
                {
                    Path1 = installion.InstallLocation.ToString() + "\\FortniteGame\\Binaries\\Win64";
                    version = installion.AppVersion.ToString().Split('-')[1];
                }
            }

            if (!File.Exists(Path1 + "\\FortniteClient-Win64-Shipping_EAC.old")) { }
            else
            {
                File.Move(Path1 + "\\FortniteClient-Win64-Shipping_EAC.exe", Path1 + "\\FortniteClient-Win64-Shipping_EAC.exe.old");
            }

            if (!File.Exists(Path1 + "\\FortniteClient-Win64-Shipping_BE.old")) { }
            else
            {
                File.Move(Path1 + "\\FortniteClient-Win64-Shipping_BE.exe", Path1 + "\\FortniteClient-Win64-Shipping_BE.exe.old");
            }

            WebClient webClient = new WebClient();

            await webClient.DownloadFileTaskAsync("https://cdn.discordapp.com/attachments/871716050021003284/891687018575323247/FortniteClient-Win64-Shipping_EAC.exe", TempPath + "\\FortniteClient-Win64-Shipping_EAC.exe");
            await webClient.DownloadFileTaskAsync("https://cdn.discordapp.com/attachments/871716050021003284/891687015593156608/FortniteClient-Win64-Shipping_BE.exe", TempPath + "\\FortniteClient-Win64-Shipping_BE.exe");
            if (!File.Exists(TempPath + "\\SoftyFN.dll"))
            {
                await webClient.DownloadFileTaskAsync("https://cdn.discordapp.com/attachments/871716050021003284/891686497504333875/SoftyFN.dll", TempPath + "\\SoftyFN.dll");
            }

            if (!File.Exists(Path1 + "\\FortniteClient-Win64-Shipping_EAC.exe"))
            {
                File.Move(TempPath + "\\FortniteClient-Win64-Shipping_EAC.exe", Path1 + "\\FortniteClient-Win64-Shipping_EAC.exe");
            }
            else
            {
                File.Delete(Path1 + "\\FortniteClient-Win64-Shipping_EAC.exe");
                File.Move(TempPath + "\\FortniteClient-Win64-Shipping_EAC.exe", Path1 + "\\FortniteClient-Win64-Shipping_EAC.exe");
            }

            if (!File.Exists(Path1 + "\\FortniteClient-Win64-Shipping_BE.exe"))
            {
                File.Move(TempPath + "\\FortniteClient-Win64-Shipping_BE.exe", Path1 + "\\FortniteClient-Win64-Shipping_BE.exe");
            }
            else
            {
                File.Delete(Path1 + "\\FortniteClient-Win64-Shipping_BE.exe");
                File.Move(TempPath + "\\FortniteClient-Win64-Shipping_BE.exe", Path1 + "\\FortniteClient-Win64-Shipping_BE.exe");
            }

            if (!File.Exists(Path1 + "\\SoftyFN.dll"))
            {
                File.Move(TempPath + "\\SoftyFN.dll", Path1 + "\\SoftyFN.dll");
            }
            else
            {
                File.Delete(Path1 + "\\SoftyFN.dll");
                File.Move(TempPath + "\\SoftyFN.dll", Path1 + "\\SoftyFN.dll");
            }

            
            var Proc = new ProcessStartInfo();
            Proc.CreateNoWindow = true;
            Proc.FileName = "cmd.exe";
            Proc.Arguments = "/C start com.epicgames.launcher://apps/Fortnite?action=launch";
            Process.Start(Proc);


            Softy.Log("SoftyFN funcionando en la version v" + version);
            Thread.Sleep(1000);
            Softy.Log("Abriendo fortnite Fortnite...");

            Console.ReadLine();

        }
    }
}