using Microsoft.Win32;
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

namespace RobloxSettingsHelper
{
    public partial class FontsForm : Form
    {
        private static string appPath = AppDomain.CurrentDomain.BaseDirectory;
        private static string fontFolderPath = appPath + "fonts\\";
        private string localFontPath = fontFolderPath + "font.ttf";
        private string scoreboardFontPath = fontFolderPath + "scoreboardfont.ttf";
        private string menuUIFontPath = fontFolderPath + "menuuifont.ttf";
        private string dmgIndicatorsFontPath = fontFolderPath + "indicatorsfont.ttf";

        public FontsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAndCopyFont(scoreboardFontPath);
        }

        private void setMenuUIBtn_Click(object sender, EventArgs e)
        {
            GetAndCopyFont(menuUIFontPath);
        }

        private void setIndicatorsBtn_Click(object sender, EventArgs e)
        {
            GetAndCopyFont(dmgIndicatorsFontPath);
        }

        private void setEverythingBtn_Click(object sender, EventArgs e)
        {
            GetAndCopyFont(localFontPath);
        }

        private void setAllBtn_Click(object sender, EventArgs e)
        {
            GetAndCopyToAllFonts();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void GetAndCopyFont(string outputFile)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Font Files (*.ttf;*.otf)|*.ttf;*.otf";
            ofd.Title = "Select a Font File";

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            string selectedFontPath = ofd.FileName;
            File.Copy(selectedFontPath, outputFile, true);
        }

        public static void GetAndCopyToAllFonts()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Font Files (*.ttf;*.otf)|*.ttf;*.otf";
            ofd.Title = "Select a Font File";

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            foreach (var f in Directory.GetFiles(fontFolderPath))
            {
                File.Delete(f.ToString());
                File.Copy(ofd.FileName, f.ToString());
            }
        }
    }
}
