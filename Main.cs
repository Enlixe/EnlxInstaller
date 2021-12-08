using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnlxInstaller
{
    public partial class EnlxInstaller : Form
    {
        static readonly string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        static readonly string folderpath = Path.Combine(appdata, ".minecraft\\nobs");
        static readonly string filepath = Path.Combine(folderpath, "mod.zip");

        static readonly string forge = Path.Combine(appdata, ".minecraft\\versions\\1.17.1-forge-37.1.0");

        static readonly string modpath = Path.Combine(folderpath, "Better Minecraft Server Pack [FORGE] 1.17.1");
        static readonly string modsfolder = Path.Combine(folderpath, "mods");

        bool folderDone = false;
        bool downloadDone = false;
        bool extractDone = false;

        bool addonsDone = false;

        /* Init */
        public EnlxInstaller() { InitializeComponent(); }

        private void EnlxInstaller_Load(object sender, EventArgs e)
        {
            // Check if the forge exist
            if (!Directory.Exists(forge))
            {
                Console.WriteLine("Err | Cannot find forge");

                // Confirmation if user want to redownload or cancel
                var result = MessageBox.Show("Cannot find forge \nDo you want to download latest forge ?", "Error", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Opening Forge Website");

                    System.Diagnostics.Process.Start("https://files.minecraftforge.net/net/minecraftforge/forge/index_1.17.1.html");

                    Application.Exit();
                }
                else
                {
                    Console.WriteLine("Info | Forge Download Cancelled\n");
                    MessageBox.Show("Installation Cancelled");

                    Application.Exit();
                }
            }

            if (Directory.Exists(folderpath))
                downloadButton.Enabled = false;

            // Reinstall button
            if (!Directory.Exists(folderpath))
                reinstallButton.Visible = false;
            else
                reinstallButton.Visible = true;

            // Addons button
            if (!Directory.Exists(modsfolder))
                addonsButton.Visible = false;
            else
                addonsButton.Visible = true;
        }

        /* Unused */
        private void pictureBox1_Click(object sender, EventArgs e) { }



        /*
         * Download Button Clicked
         */
        private void downloadButton_Click(object sender, EventArgs e)
        {
            // Disable Button
            downloadButton.Enabled = false;
            
            download();
        }

        private void addonsButton_Click(object sender, EventArgs e)
        {
            addonsButton.Enabled = false;
            /*
             * Addons (currently optifine bugged out)
             */

            /*     
                if (addonsOptifine.Checked == true)
                {
                    addonsOptifine.Enabled = false;
                    _download_downloadAddons("https://enlixe.github.io/assets/download/optifine.jar", Path.Combine(folderpath, "mods\\addons-optifine.jar"));
                }
            */

            if (addonsJourneymap.Checked == true)
            {
                addonsJourneymap.Enabled = false;
                _download_downloadAddons("https://media.forgecdn.net/files/3509/575/journeymap-1.17.1-5.7.3.jar", Path.Combine(folderpath, "mods\\addons-journeymap.jar"));
            }

            if (addonsMousetweaks.Checked == true)
            {
                addonsMousetweaks.Enabled = false;
                _download_downloadAddons("https://media.forgecdn.net/files/3515/478/MouseTweaks-forge-mc1.17.1-2.15.jar", Path.Combine(folderpath, "mods\\addons-mousetweaks.jar"));
            }
        }

        private void reinstallButton_Click(object sender, EventArgs e)
        {
            // Confirmation if user want to redownload or cancel
            var result = MessageBox.Show("Are you sure you want to redownload it ? \nAll settings / files will gone !", "Repair ?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Repairing Download");

                Directory.Delete(folderpath, true);
                Directory.CreateDirectory(folderpath);

                Console.WriteLine("Info | Folder - Re-Created {0}\n", folderpath);
                folderDone = true;

                download();
            }
            else
            {
                Console.WriteLine("Info | Folder - Repair Cancelled\n");
                MessageBox.Show("Installation Cancelled");
                Application.Exit();
            }
        }

        /*
         * Download Task
         */
        private async Task download()
        {
            Console.WriteLine("Info | Task - Installing");

            // Making folder
            await Task.Run(() => {
                _download_createFolder(folderpath);
                _download_createFolder(Path.Combine(folderpath, "mods"));
            });

            // Download
            await Task.Run(() => {
                if (folderDone)
                    _download_downloadFile("https://media.forgecdn.net/files/3538/711/Better+Minecraft+Server+Pack+%5bFORGE%5d+v11.5.zip", filepath);
            });
        }

        /*
         * Making Folder If Doesn't Exist
         */
        private void _download_createFolder(string folder)
        {
            try {
                if (!Directory.Exists(folder)) {
                    // If folder doesnt exist - create it
                    Directory.CreateDirectory(folder);

                    Console.WriteLine("Info | Folder - Created {0}\n", folder);
                    folderDone = true;
                } 
            } catch (Exception) {
                Console.WriteLine("Err | Folder - Failed Creating Folder\n");
                MessageBox.Show("Err | Failed Creating Mod Folder");
                Application.Exit();
            }
        }

        /*
         * Download Addons
         */
        private void _download_downloadAddons(string downloadLink, string downloadPath)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(_download_downloadAddons_Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(_download_downloadAddons_ProgressChanged);

                webClient.DownloadFileAsync(new Uri(downloadLink), downloadPath);

                Console.WriteLine("Info | Downloading Addons - from {0}", downloadLink);
            }
            catch (Exception)
            {
                Console.WriteLine("Err | Downloading Addons - Failed {0}n", downloadLink);
                MessageBox.Show("Err | Failed Downloading Addons");
                Application.Exit();
            }
        }
        private void _download_downloadAddons_ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Invoke(new Action(() => {
                progressBar.Value = e.ProgressPercentage;
            }));
            progressLabel.Invoke(new Action(() => {
                progressLabel.Text = "Downloading Addons - " + e.ProgressPercentage.ToString() + "%";
            }));
        }
        private void _download_downloadAddons_Completed(object sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Info | Download Completed");
            downloadDone = true;

            progressLabel.Invoke(new Action(() => {
                progressLabel.Text = "Downloading Addons - Completed";
            }));
        }

        /*
         * Downloading Files Required
         */
        private void _download_downloadFile(string downloadLink, string downloadPath)
        {
            try {
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(_download_downloadFile_Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(_download_downloadFile_ProgressChanged);

                webClient.DownloadFileAsync(new Uri(downloadLink), downloadPath);

                Console.WriteLine("Info | Downloading - from {0}", downloadLink);
            } catch (Exception) {
                Console.WriteLine("Err | Downloading - Failed {0}n", downloadLink);
                MessageBox.Show("Err | Failed Downloading");
                Application.Exit();
            }
        }
            private void _download_downloadFile_ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
            {
                progressBar.Invoke(new Action(() => {
                    progressBar.Value = e.ProgressPercentage;
                }));
                progressLabel.Invoke(new Action(() => {
                    progressLabel.Text = "Downloading - " + e.ProgressPercentage.ToString() + "%";
                }));
            }
            private void _download_downloadFile_Completed(object sender, AsyncCompletedEventArgs e)
            {
                Console.WriteLine("Info | Download Completed");
                downloadDone = true;

                /*
                 * Addons (currently optifine bugged out)
                 *

                if (optifine.Checked == true)
                {
                    optifine.Enabled = false;
                    _download_downloadAddons("https://enlixe.github.io/assets/download/optifine.jar", Path.Combine(folderpath, "mods\\addons-optifine.jar"));
                    _download_downloadAddons("https://media.forgecdn.net/files/3479/861/OptiForge-MC1.17.1-0.1.1.jar", Path.Combine(folderpath, "mods\\addons-optiforgejar"));
                }

                */

                if (addonsJourneymap.Checked == true)
                {
                    addonsJourneymap.Enabled = false;
                    _download_downloadAddons("https://media.forgecdn.net/files/3509/575/journeymap-1.17.1-5.7.3.jar", Path.Combine(folderpath, "mods\\addons-journeymap.jar"));
                }
                if (addonsMousetweaks.Checked == true)
                {
                    addonsMousetweaks.Enabled = false;
                    _download_downloadAddons("https://media.forgecdn.net/files/3515/478/MouseTweaks-forge-mc1.17.1-2.15.jar", Path.Combine(folderpath, "mods\\addons-mousetweaks.jar"));
                }

                if (downloadDone)
                    _download_extractFile(filepath, folderpath);

            }

        /*
         * Extract File Downloaded
         */
        private async Task _download_extractFile(string extractFilePath, string extractFolderPath)
        {
            Console.WriteLine("Info | Extracting");
            progressLabel.Invoke(new Action(() => {
                progressLabel.Text = "Extracting...";
            }));
            try {
                await Task.Run(() => ZipFile.ExtractToDirectory(extractFilePath, extractFolderPath));
                await Task.Run(() => File.Delete(extractFilePath));

                Console.WriteLine("Info | Extracting Completed");
                extractDone = true;

                if (extractDone)
                {
                    Console.WriteLine("Info | Task - Installing Completed");

                    // Move Mod
                    Console.WriteLine("Info | Moving Mod");
                    await Task.Run(() => CopyDir(modpath, folderpath));
                    await Task.Run(() => Directory.Delete(modpath, true));
                    Console.WriteLine("Info | Moving Mod Completed");

                    // Add Profile
                    Console.WriteLine("Info | Adding Profiles");
                    progressLabel.Invoke(new Action(() => {
                        progressLabel.Text = "Adding Profile...";
                    }));
                    await Task.Run(() => add_profile());
                    Console.WriteLine("Info | Adding Profiles Completed");

                    progressLabel.Invoke(new Action(() => { progressLabel.Text = "Installing Completed"; }));
                    MessageBox.Show("Installation Completed");
                    Application.Exit();
                }
            } catch (Exception) {
                // Console.WriteLine("Err | Extract - Could not extract / delete ZIP!\n");
                // MessageBox.Show("Err | Could not extract / delete ZIP!");
                // Application.Exit();
            }
        }

        /*
         * Add Profile
         */
        private async Task add_profile()
        {
            try {
                string profilePath = Path.Combine(appdata, ".minecraft\\launcher_profiles.json");
                string json = File.ReadAllText(profilePath);

                JObject jo = JObject.Parse(json);
                JObject profiles = (JObject)jo["profiles"];

                if (!profiles.ContainsKey("Nobs 1.17.1"))
                {
                    profiles.AddFirst(
                        new JProperty("Nobs 1.17.1",
                            new JObject(
                                // Created
                                new JProperty("gameDir", folderpath),
                                new JProperty("icon", "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAEAAAABACAYAAACqaXHeAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAmbSURBVHhe7VtbkBTVGe6xfAOf4kNKsSAFJvGKxEsSgVTQnd3ZpfAJnyxlrUoBSURuyz3IRbkjXlEBq8BSywfMC2RndmYXNlWsCXIHI4SCZUmRxErFPGlet/2+/z+np3unb7M764LOx3Sfa5/zf///n1v34tRRRx11fJ+RMWEoDnz0H9dxEXHdniee+uFU5h384AvNw23G07fFPn8j4CYThsMQBaYc+PAL9wDIS0rzWiV6gyPRgiROvqxI2hmqANeMZ26/4a1PxHsAoSaXUMmb9HcEyR4At8+ANblLZesBs8aMiAcU3jg/yul3vqZMYg3KA+QW3DcoeRI9IGP6sK4vnY4QCq9//hXkAPl+pCiPkQa3jlfOucUd5/YzWQ1iFXDwfYx/P2FGzXVw3zVfwbcDGGO02IEJcxNPKGfO5L0axLrNgff/7T4RsdRBAX0zWu/4kUkOO2B9b/mlV6pbIoQzyBC1+QibFj+QejgMatwMBwo7L8pEUyYCIN38/N0iY+G1v2Eukkz56XDUpM1Tb3CcprbrXAH5ty/thaStJOGRheTugDR/VgEdUADTmq9lvLE+ozJHCeABbZOuPwXk37n8FQQfbSRHYCQHguNY0uMQ/bJ53t3/1xwo4FUoQOoxVXZ3m7bRm9BO45LrRAH5Xb23Q6x/inAQTIgSnrWcMS2/+8m/TDwRHa98JjSttRlYt5cbfk1VkCeGRQEgvgfS/Ebl8lkLaPntjwfdZ8eOc7InMU0BNs6bxpuW/EzaL205eQQZUxqXPRTbX00VkN/duw1826RRsZJeLXMHT3ogOnaclbkg2IfGLXmitOWElJr9y+XGFY/cqSVB1Eyw9t1XOItJXDqF2Vvm3Fmz9geiuP0Mmckvyu1Lm0+YOhx+mZnZFQ//0RR5GLKAQhyd6GysYcvcCYNuF5PdWDRx1XN1q1THHd20aKI3KaZF56bjmH6oANfJrvx5hVxDUoCSB0RI15k+pzri2NfPwmP7gmRNnJCwX4U0irD1MhlnQmPbpF7NjEdp46eunYeyq34RkHHQCmjfY1zeNJyWfOGNC3iKnkKrkLq2oUqQxiRUj5KExDXKMwBDDVivaWl53Mehc8NR6Sr7hyEqAMT70NA4K8X02ePTEX/zguFjpDckFe643Px7/2ESsShuOz0W9a/adqxlk2b7LiiAQ0GUsPqXXt2qFPCnd69cy/Q7Y6QVXNNnJ1s9v/MC3A/VRGCRVoBNTlV9hwFLnTZo2m5c/nBkm50vHeVJcjRr+hWQ/ELEIL+nbzK0reTxSyKf3/l3t4DLWogXXP5WEq8FeaJx2YMYOaZt4xFRgOvfwhoD66VWgOv290hn+E2fE+/2JC/ETf3m5+4S0rl5d/1Pa9QOjcvh+tJNxunceIy9RiNESaks0b6nVwjx8aQxL+QR6tKj5KUgAnyRwdBTmPRiA9zwS9reljaBOOpRE2FLnUXX+k+kXsOayV6dRA/QDQ7l4JiPJl946+J+HmlFUSDSQqtHkC+8+pnLfb3u7QHU5zOaACQinUpZcesprygM7NO4QdVIMQS0YYzfKSajAiA/HgRmyiyLyiSvJZXgqU4K1eTaNvYCucUTM7z4MoPneTnSmj2CkIuFtpNUSyqIjGXEKqB9dy9NgxhIzR7/ieZWAsQvMySxKKvjPH+pfKTVILfw/kxu0f0gPfFZUy2ApqWTnmXvicxMe3ETYde6HsMliHgPMPXjNjl5uj1Cdt783E8j66F4gjSInxDHZYoiUdx6sjyZRgC7vGsaw/gfsMkJQJpg/9hD+BCpgPZdsD4eEAFikMHujPLFTXYdGPNiHVy5hcmvr0tbT48qYo1Xi3J9j97koM4Y8oqTs2ttz2JRAK6GdVMD7zEjFSBjDw/EHWy4zrPdxDFqitNZ/RTa7P/aVrQ7vNKm40c425c2HvuvFFi4zsfsv2F1tPVRsF1lrJQz8qH8rssyZlrmRh9pZXuLNpvnJS11mO2NNXOLJgbqlraf3ouiVpZR4WzQur21vCxzBO5CBL/squjlzo9Da4/I3MznHl/3q4pnQj2g3ZBnR7VBeSYvvnzGlQvn+eL20xSugjx3eJY8j7OMiFIICV1ubW1OLJR8NEIVYMer6S0aaeoAdH2c5TNqWXPx5oWSebVpKYhze+sDNSTiIO7JxQRunS8excEoGofWHNHKeCbM+kRoZv6dS+iXVot/h1d4/bx0QGK5+fdE1hsKuL31DwtF2WOyqx8N7deS5xMNEeSJ8EmQ5AMdRkHLk2oNCZ4smpSI/JLIA7jHkSfCh4DjlN/fx6D5eVhdBHRlqTPZwwA0jXO4FzVXGLpAXuyuxrtZMmMQqR3d4GBz8/vozY2FR147TbXcDURp8/H96G6mMMSvceUjXhuc8HRPwCItz75QaX2xvFTDmF8fb3mLyEpc421jSSc6Qk51pj6hFkIWQrN0vYtbD4jsY5Etlwo2Dqi7891dumWO8FzetBE14YUhtmLadd6PjpfP6mFHyAXDAGl2zXd8kgdI2A/LpydOYJcnnip/MgA8vn5qVc/HVuYLTIYDFVCQEx2KWApWuQWVLo+1/gcg+iXraF11kLISNIx7jRUHEufz2h6A9tO6vR9VPSBfaAmxIEPe1IpsiGs9c4YTeqpjDDf2i6taq/uR+kF+n2eomxHJQsiI37WhhCq+zVcDIU7oXeRA9GMcbp7UnMEhlbDBb/MakrRk+tIMq/k2n4RD6/+yDc22iaKlfTPQgYa1g7e6H9UpwHN9EEYGUwGPYARp/0fKatH14l/7sAsdp6mgd/FqWDelZgom0imAb3IGkjdJuz57GShLq4DODZ+OxXPmBQWeZ9vSDB+3KwSOumtqS9qPxIb5sRJCXBVhDEkdf1SEycOvrBR+rtIDTWnziT6k1ZpePQbm2X55QEhLnnme/7IvlN/cpsXhVd2jHtswreID6uFlne5jW7Kh7aXqxP5lRtlCmrR50oyvzJ7osLsjF8kjysPFhox6kVbs7d8ziarRvap7MoZOjySMLKZzMc60zUNSAHd5VmhLVKKAmZgQyHkX9ZK+0w0XDq88rEJ6sgJGGdO2hisg8pVYAGiAjbAF1SzzeNdP17SsDoGRIy+wxHF5ciEeRZ5IpQC+uhZ3EtKWsIHpkGBnIwuVUWQzsnrCRSCdBwA5768vTYOiXaql3FHc29tvBRBFPJTkKZZRwp+XFDUSgtQKILwvNpY0AipB3uGNpOt7ENa+iwFCEw3DdSB0bdC9vGsvyMr/YpnmW/K6YX3OT7/elvvOcK2jjjrqqKOOmsBxvgFvyacroQ8B7QAAAABJRU5ErkJggg=="),
                                new JProperty("javaArgs", "-Xmx4G -XX:+UnlockExperimentalVMOptions -XX:+UseG1GC -XX:G1NewSizePercent=20 -XX:G1ReservePercent=20 -XX:MaxGCPauseMillis=50 -XX:G1HeapRegionSize=32M"),
                                // Last used
                                new JProperty("lastVersionId", "1.17.1-forge-37.1.0"),
                                new JProperty("name", "Nobs"),
                                new JProperty("type", "custom")
                            )
                        )
                    );

                    File.WriteAllText(profilePath, jo.ToString());
                }
            } catch (Exception) {
                Console.WriteLine("Err | Profile - Could not add profile\n");
                MessageBox.Show("Err | Could not add profile, please add it manually!");
                Application.Exit();
            }
        }

        public void CopyDir(string sourceFolder, string destFolder)
        {
            try {
                if (!Directory.Exists(destFolder))
                    Directory.CreateDirectory(destFolder);

                // Get Files & Copy
                string[] files = Directory.GetFiles(sourceFolder);
                foreach (string file in files)
                {
                    string name = Path.GetFileName(file);

                    // ADD Unique File Name Check to Below!!!!
                    string dest = Path.Combine(destFolder, name);
                    File.Copy(file, dest);
                }

                // Get dirs recursively and copy files
                string[] folders = Directory.GetDirectories(sourceFolder);
                foreach (string folder in folders)
                {
                    string name = Path.GetFileName(folder);
                    string dest = Path.Combine(destFolder, name);
                    CopyDir(folder, dest);
                }
            } catch (Exception) {
                Console.WriteLine("Err | CopyDir - Could not move dir!\n");
                MessageBox.Show("Err | Could not moving file!");
                Application.Exit();
            }
        }
    }
}
