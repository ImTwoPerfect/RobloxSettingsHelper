using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace RobloxSettingsHelper
{
    public partial class StartupForm : Form
    {
        private static string userName = System.Environment.UserName;
        private static string appPath = AppDomain.CurrentDomain.BaseDirectory;
        private static string robloxPath;
        private static string localClientSettingsPath = appPath + "ClientSettings\\ClientAppSettings.json";

        public StartupForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClientSettingsForm csf = new ClientSettingsForm(localClientSettingsPath);
            csf.ShowDialog();
        }

        private void StartupForm_Load(object sender, EventArgs e)
        {
            var settings = LoadSettings("RSHSettings.json");
            ApplySettings(settings, this);
            setVisibility();
            robloxPath = getRobloxFilePath();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            robloxPath = getRobloxFilePath();
            if (robloxPath != null)
            {
                if (fontCheck.Checked)
                {
                    CopyFonts();
                }
                if (clientSettingsCheck.Checked)
                {
                    CopyClientSettings();
                }
                if (fpsUnlockCheck.Checked)
                {
                    if (int.TryParse(fpsCapTxt.Text, out int fps) && fps > 0)
                    {
                        UnlockFPS(fpsCapTxt.Text);
                    }
                    else
                    {
                        MessageBox.Show("Error: FPS value is invalid.");
                    }
                }
                if (texturesCheck.Checked)
                {
                    // Dark Textures
                    CopyTextures("DarkTextures");
                }
                if(!texturesCheck.Checked)
                {
                    // Roblox Textures
                    CopyTextures("RobloxTextures");
                }

                MessageBox.Show("Success: Settings updated!");
            }
            else
            {
                MessageBox.Show("Error: Roblox folder not found!");
            }
            SaveSettings();
        }

        public static void UnlockFPS(string fpsCapValue)
        {
            string globalBasicSettingsPath = "C:\\Users\\" + userName + "\\AppData\\Local\\Roblox\\GlobalBasicSettings_13.xml";
            Console.WriteLine("Unlocking FPS..");
            if (File.Exists(globalBasicSettingsPath))
            {
                Console.WriteLine("GlobalBasicSettings file path: " + globalBasicSettingsPath);
                var xdoc = XDocument.Load(globalBasicSettingsPath);
                var frameCap = xdoc.Descendants("int").FirstOrDefault(x => (string)x.Attribute("name") == "FramerateCap");
                if (frameCap != null)
                {
                    frameCap.Value = fpsCapValue;
                    xdoc.Save(globalBasicSettingsPath);
                    Console.WriteLine("Successfully unlocked FPS!");
                    return;
                }
            }
            Console.WriteLine("Error: Couldn't find GlobalBasicSettings_13.xml in " + globalBasicSettingsPath);
        }

        public static void CopyFonts()
        {
            string fontFolderPath = appPath + "fonts\\";
            string localFontPath = fontFolderPath + "font.ttf";
            string scoreboardFontPath = fontFolderPath + "scoreboardfont.ttf";
            string menuUIFontPath = fontFolderPath + "menuuifont.ttf";
            string dmgIndicatorsFontPath = fontFolderPath + "indicatorsfont.ttf";

            string robloxFontFolderPath = robloxPath + "\\content\\fonts";
            string robloxScoreboardFontPath = robloxFontFolderPath + "\\Montserrat-Black.ttf";
            string robloxUIFontPath = robloxFontFolderPath + "\\Montserrat-Bold.ttf";
            string robloxIndicatorsFontPath = robloxFontFolderPath + "\\SourceSansPro-Bold.ttf";

            if (File.Exists(localFontPath))
            {
                Console.WriteLine("Font folder path: " + robloxFontFolderPath);
                foreach (var file in Directory.GetFiles(robloxFontFolderPath))
                {
                    string oldFont = file.ToString();
                    if (oldFont != robloxFontFolderPath + "\\families" && oldFont != robloxFontFolderPath + "\\gamecontrollerdb.txt" && oldFont != robloxFontFolderPath + "\\RobloxEmoji.ttf" && oldFont != robloxFontFolderPath + "\\TwemojiMozilla.ttf")
                    {
                        File.Delete(oldFont);
                        File.Copy(localFontPath, oldFont);
                        //MessageBox.Show(file.ToString()); debug for finding font
                    }
                }
                Console.WriteLine("Successfully copied fonts!");
            }

            ReplaceFont(scoreboardFontPath, robloxScoreboardFontPath);
            ReplaceFont(menuUIFontPath, robloxUIFontPath);
            ReplaceFont(dmgIndicatorsFontPath, robloxIndicatorsFontPath);
        }

        public static void CopyTextures(string texturePath)
        {
            Console.WriteLine("Copying textures..");
            string localTexturesFolderPath = appPath + "textures\\" + texturePath;
            if (Directory.Exists(localTexturesFolderPath))
            {
                string robloxTexturesPath = robloxPath + "\\PlatformContent\\pc\\textures";
                Console.WriteLine("Textures path: " + localTexturesFolderPath);
                if (Directory.Exists(robloxTexturesPath))
                {
                    CopyDirectory(localTexturesFolderPath, robloxTexturesPath, true);
                    Console.WriteLine("Successfully copied textures!");
                    return;
                }
                Console.WriteLine("Error: Couldn't find roblox textures path." + robloxTexturesPath);
                return;
            }
            Console.WriteLine("Error: Couldn't find local textures file: " + localTexturesFolderPath);
            return;
        }

        public static void CopyClientSettings()
        {
            string clientSettingsFolderPath = appPath + "ClientSettings";
            string clientSettingsPath = clientSettingsFolderPath + "\\ClientAppSettings.json";
            Console.WriteLine("Copying client settings..");
            if (File.Exists(clientSettingsPath))
            {
                CopyDirectory(clientSettingsFolderPath, robloxPath + "\\ClientSettings", false);
                Console.WriteLine("ClientAppSettings file path:" + robloxPath + "\\ClientSettings\\ClientAppSettings.json");
                Console.WriteLine("Successfully copied ClientAppSettings!");
                return;
            }
            Console.WriteLine("Error: Couldn't find ClientAppSettings.json in folder " + clientSettingsPath);
            return;
        }

        public static void ReplaceFont(string oldFilePath, string newFilePath)
        {
            if (File.Exists(oldFilePath))
            {
                if (File.Exists(newFilePath))
                {
                    File.Delete(newFilePath);
                    File.Copy(oldFilePath, newFilePath);
                }
                else
                {
                    Console.WriteLine($"Error: couldn't find {newFilePath}.");
                }
            }
            else
            {
                Console.WriteLine($"Error: couldn't find {oldFilePath}.");
            }
        }

        public static string getUserName()
        {
            return userName;
        }

        public static string getFilePath()
        {
            return "C:\\Users\\" + getUserName() + "\\AppData\\Local\\Roblox\\Versions";
        }

        public static string getRobloxFilePath()
        {
            // Check local files for latest Roblox version (ignoring studio)
            var lastModifiedFolders = new DirectoryInfo(getFilePath())
                .GetDirectories()
                .OrderByDescending(d => d.LastWriteTime)
                .Take(2)
                .ToList();

            foreach (var folder in lastModifiedFolders)
            {
                if (folder.EnumerateFiles("RobloxPlayerBeta.exe").Any())
                {
                    return folder.FullName;
                }
            }
            return null;
        }

        public static void CopyDirectory(string source, string target, bool recursive)
        {
            var dir = new DirectoryInfo(source);
            if (!dir.Exists) throw new DirectoryNotFoundException("Error: Source not found.");
            Directory.CreateDirectory(target);

            foreach (var file in dir.GetFiles())
            {
                file.CopyTo(Path.Combine(target, file.Name), true);
            }

            if (recursive)
            {
                foreach (var subDir in dir.GetDirectories())
                {
                    CopyDirectory(subDir.FullName, Path.Combine(target, subDir.Name), true);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FontsForm form = new FontsForm();
            form.ShowDialog();
        }

        public Dictionary<string, object> LoadSettings(string path)
        {
            if (!File.Exists(path))
                return new Dictionary<string, object>();

            string json = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<Dictionary<string, object>>(json)
                   ?? new Dictionary<string, object>();
        }

        public void ApplySettings(Dictionary<string, object> settings, Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is CheckBox cb && settings.ContainsKey(cb.Name))
                {
                    cb.Checked = Convert.ToBoolean(settings[cb.Name]);
                }
                else if (ctrl is RichTextBox tb && settings.ContainsKey(tb.Name))
                {
                    tb.Text = settings[tb.Name]?.ToString();
                }
                if (ctrl.HasChildren)
                {
                    ApplySettings(settings, ctrl);
                }
            }
        }

        public void SaveSettings()
        {
            var settings = new Dictionary<string, object>();

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is CheckBox cb)
                {
                    settings[cb.Name] = cb.Checked;
                }
                if (ctrl is RichTextBox txt)
                {
                    settings[txt.Name] = txt.Text;
                }
            }

            string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText("RSHSettings.json", json);
        }

        public void changeFpsVisibility()
        {
            if (fpsUnlockCheck.Checked)
            {
                fpsCapLabel.Visible = true;
                fpsCapTxt.Visible = true;
            }
            if (!fpsUnlockCheck.Checked)
            {
                fpsCapLabel.Visible = false;
                fpsCapTxt.Visible = false;
            }
        }

        public void changeClientSettingsVisibility()
        {
            if (clientSettingsCheck.Checked)
            {
                setFflagsBtn.Visible = true;
            }
            if (!clientSettingsCheck.Checked)
            {
                setFflagsBtn.Visible = false;
            }
        }

        public void checkFontVisibility()
        {
            if (fontCheck.Checked)
            {
                mngFontsBtn.Visible = true;
            }
            if (!fontCheck.Checked)
            {
                mngFontsBtn.Visible = false;
            }
        }

        public void setVisibility()
        {
            changeFpsVisibility();
            changeClientSettingsVisibility();
            checkFontVisibility();
        }

        Color hoverColor = Color.FromArgb(0, 50, 205);
        Color defaultColor = Color.FromArgb(255, 255, 255);
        private void fontCheck_MouseEnter(object sender, EventArgs e)
        {
            fontCheck.ForeColor = hoverColor;
        }

        private void fontCheck_MouseLeave(object sender, EventArgs e)
        {
            fontCheck.ForeColor = defaultColor;
        }

        private void clientSettingsCheck_MouseEnter(object sender, EventArgs e)
        {
            clientSettingsCheck.ForeColor = hoverColor;
        }

        private void clientSettingsCheck_MouseLeave(object sender, EventArgs e)
        {
            clientSettingsCheck.ForeColor = defaultColor;
        }

        private void fpsUnlockCheck_MouseEnter(object sender, EventArgs e)
        {
            fpsUnlockCheck.ForeColor = hoverColor;
        }

        private void fpsUnlockCheck_MouseLeave(object sender, EventArgs e)
        {
            fpsUnlockCheck.ForeColor = defaultColor;
        }

        private void texturesCheck_MouseEnter(object sender, EventArgs e)
        {
            texturesCheck.ForeColor = hoverColor;
        }

        private void texturesCheck_MouseLeave(object sender, EventArgs e)
        {
            texturesCheck.ForeColor = defaultColor;
        }

        private void fpsCapTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void fpsCapTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void fpsCapTxt_MouseClick(object sender, MouseEventArgs e)
        {
            fpsCapTxt.SelectAll();
        }

        private void fpsUnlockCheck_CheckedChanged(object sender, EventArgs e)
        {
            changeFpsVisibility();
        }

        private void clientSettingsCheck_CheckedChanged(object sender, EventArgs e)
        {
            changeClientSettingsVisibility();
        }

        private void fontCheck_CheckedChanged(object sender, EventArgs e)
        {
            checkFontVisibility();
        }
    }
}
