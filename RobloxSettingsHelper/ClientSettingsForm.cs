using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Formatting = Newtonsoft.Json.Formatting;

namespace RobloxSettingsHelper
{
    public partial class ClientSettingsForm : Form
    {
        private string _csPath;

        private readonly Dictionary<string, CheckBox> _boolControls = new Dictionary<string, CheckBox>();
        private readonly Dictionary<string, TextBox> _intControls = new Dictionary<string, TextBox>();

        private readonly Dictionary<string, Type> _fflagDefinitions = new Dictionary<string, Type>()
        {
            { "FFlagDisablePostFx", typeof(bool) },
            { "FFlagDisableShadows", typeof(bool) },
            { "FFlagDisableBloom", typeof(bool) },
            { "FFlagDisableDepthOfField", typeof(bool) },
            { "FFlagDisableGlobalShadows", typeof(bool) },
            { "FFlagEnableReducedLatency", typeof(bool) },
            { "FFlagFastGPULightCulling3", typeof(bool) },
            { "FFlagRenderFixFog", typeof(bool) },
            { "FFlagRenderOptimizedShadows", typeof(bool) },
            { "FFlagLuaAppEnableLowMemoryMode", typeof(bool) },
            { "FFlagDebugDisplayFPS", typeof(bool) },
            { "FFlagHandleAltEnterFullscreenManually", typeof(bool) },
            { "DFFlagTextureQualityOverrideEnabled", typeof(bool) },
            { "DFFlagDisableDPIScale", typeof(bool) },
            { "FFlagDebugGraphicsPreferD3D11", typeof(bool) },
            { "FFlagDebugSkyGray", typeof(bool) },
            { "DFFlagDebugPauseVoxelizer", typeof(bool) },
            { "FFlagDebugGraphicsPreferVulkan", typeof(bool) },
            { "FFlagDebugGraphicsPreferOpenGL", typeof(bool) },
            { "DFIntPhysicsStepsPerFrame", typeof(int) },
            { "DFIntGCJobFrequencyMs", typeof(int) },
            { "DFIntTaskSchedulerTargetFps", typeof(int) },
            { "DFIntConnectionMTUSize", typeof(int) },
            { "DFIntRakNetResendBufferArrayLength", typeof(int) },
            { "DFIntRakNetResendTimeoutMS", typeof(int) },
            { "DFIntNetworkPrediction", typeof(int) },
            { "DFIntNetworkLatencyTolerance", typeof(int) },
            { "DFIntCSGLevelOfDetailSwitchingDistance", typeof(int) },
            { "DFIntCSGLevelOfDetailSwitchingDistanceL12", typeof(int) },
            { "DFIntCSGLevelOfDetailSwitchingDistanceL23", typeof(int) },
            { "DFIntCSGLevelOfDetailSwitchingDistanceL34", typeof(int) },
            { "DFIntTextureQualityOverride", typeof(int) },
            { "FIntDebugForceMSAASamples", typeof(int) },
            { "DFIntDebugFRMQualityLevelOverride", typeof(int) },
            { "FIntFRMMaxGrassDistance", typeof(int) },
            { "FIntFRMMinGrassDistance", typeof(int) }
        };

        public ClientSettingsForm(string csPath)
        {
            InitializeComponent();
            _csPath = csPath;
        }

        private void ClientSettingsForm_Load(object sender, EventArgs e)
        {
            CreateDynamicControls();
        }

        private void CreateDynamicControls()
        {
            panel1.Controls.Clear();
            panel1.AutoScroll = true;

            JObject json = new JObject();

            if (File.Exists(_csPath))
            {
                string jsonText = File.ReadAllText(_csPath);

                if (!string.IsNullOrWhiteSpace(jsonText))
                {
                    json = JObject.Parse(jsonText);
                }
            }

            int y = 0;

            int labelX = 10;
            int controlX = 350;

            // Alternating row colors
            Color rowColor1 = Color.FromArgb(0, 102, 204);
            Color rowColor2 = Color.FromArgb(0, 120, 205);
            Color hoverColor = Color.FromArgb(0, 50, 205);

            bool useAltColor = false;

            foreach (var flag in _fflagDefinitions.OrderBy(x => x.Key))
            {
                string flagName = flag.Key;
                Type flagType = flag.Value;

                Color currentRowColor = useAltColor ? rowColor1 : rowColor2;
                useAltColor = !useAltColor;

                if (flagType == typeof(bool))
                {
                    Panel rowPanel = new Panel();
                    rowPanel.Size = new Size(panel1.Width - 25, 30);
                    rowPanel.Location = new Point(0, y);
                    rowPanel.BackColor = currentRowColor;

                    Label label = new Label();
                    label.Text = flagName;
                    label.AutoSize = true;
                    label.Location = new Point(labelX, 7);
                    label.ForeColor = Color.White;

                    CheckBox checkBox = new CheckBox();
                    checkBox.Text = "";
                    checkBox.AutoSize = true;
                    checkBox.Location = new Point(controlX + 75, 8);

                    bool value = false;

                    if (json.TryGetValue(flagName, out JToken token))
                    {
                        bool.TryParse(token.ToString(), out value);
                    }

                    checkBox.Checked = value;
                    void ToggleCheckbox(object sender, EventArgs e)
                    {
                        checkBox.Checked = !checkBox.Checked;
                    }

                    rowPanel.Click += ToggleCheckbox;
                    label.Click += ToggleCheckbox;

                    rowPanel.MouseEnter += (s, e) =>
                    {
                        rowPanel.BackColor = hoverColor;
                    };

                    rowPanel.MouseLeave += (s, e) =>
                    {
                        rowPanel.BackColor = currentRowColor;
                    };

                    checkBox.MouseEnter += (s, e) =>
                    {
                        rowPanel.BackColor = hoverColor;
                    };

                    checkBox.MouseLeave += (s, e) =>
                    {
                        rowPanel.BackColor = currentRowColor;
                    };

                    label.MouseEnter += (s, e) =>
                    {
                        rowPanel.BackColor = hoverColor;
                    };

                    label.MouseLeave += (s, e) =>
                    {
                        rowPanel.BackColor = currentRowColor;
                    };

                    rowPanel.Controls.Add(label);
                    rowPanel.Controls.Add(checkBox);

                    panel1.Controls.Add(rowPanel);

                    _boolControls[flagName] = checkBox;

                    y += 30;
                }

                else if (flagType == typeof(int))
                {
                    Panel rowPanel = new Panel();
                    rowPanel.Size = new Size(panel1.Width - 25, 35);
                    rowPanel.Location = new Point(0, y);
                    rowPanel.BackColor = currentRowColor;

                    Label label = new Label();
                    label.Text = flagName;
                    label.AutoSize = true;
                    label.Location = new Point(labelX, 9);
                    label.ForeColor = Color.White;

                    TextBox textBox = new TextBox();
                    textBox.Width = 100;
                    textBox.Location = new Point(controlX - 10, 10);
                    textBox.BorderStyle = BorderStyle.None;
                    textBox.BackColor = currentRowColor;
                    textBox.ForeColor = Color.White;
                    textBox.TextAlign = HorizontalAlignment.Right;
                    textBox.HideSelection = true;

                    textBox.KeyPress += IntegerTextBox_KeyPress;

                    int value = 0;

                    if (json.TryGetValue(flagName, out JToken token))
                    {
                        int.TryParse(token.ToString(), out value);
                    }

                    textBox.Text = value.ToString();

                    rowPanel.MouseEnter += (s, e) =>
                    {
                        rowPanel.BackColor = hoverColor;
                        textBox.BackColor = hoverColor;
                    };

                    label.MouseEnter += (s, e) =>
                    {
                        rowPanel.BackColor = hoverColor;
                        textBox.BackColor = hoverColor;
                    };

                    label.MouseLeave += (s, e) =>
                    {
                        rowPanel.BackColor = currentRowColor;
                        textBox.BackColor = currentRowColor;
                    };

                    textBox.MouseEnter += (s, e) =>
                    {
                        rowPanel.BackColor = hoverColor;
                        textBox.BackColor = hoverColor;
                    };

                    textBox.MouseLeave += (s, e) =>
                    {
                        rowPanel.BackColor = currentRowColor;
                        textBox.BackColor = currentRowColor;
                    };

                    rowPanel.MouseLeave += (s, e) =>
                    {
                        rowPanel.BackColor = currentRowColor;
                        textBox.BackColor = currentRowColor;
                    };

                    textBox.GotFocus += (s, e) =>
                    {
                        textBox.SelectionStart = textBox.Text.Length;
                        textBox.SelectionLength = 0;
                    };

                    rowPanel.Click += (s, e) =>
                    {
                        textBox.Focus();
                    };

                    label.Click += (s, e) =>
                    {
                        textBox.Focus();
                    };

                    rowPanel.Controls.Add(label);
                    rowPanel.Controls.Add(textBox);

                    panel1.Controls.Add(rowPanel);

                    _intControls[flagName] = textBox;

                    y += 35;
                }
            }
        }

        private void CheckBox_MouseLeave(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void IntegerTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SaveFlags()
        {
            JObject json = new JObject();

            foreach (var pair in _boolControls)
            {
                json[pair.Key] = pair.Value.Checked;
            }

            foreach (var pair in _intControls)
            {
                if (int.TryParse(pair.Value.Text, out int value))
                {
                    json[pair.Key] = value;
                }
                else
                {
                    json[pair.Key] = 0;
                }
            }

            File.WriteAllText(_csPath, json.ToString(Formatting.Indented));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (CheckBox checkbox in _boolControls.Values)
            {
                checkbox.Checked = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (CheckBox checkbox in _boolControls.Values)
            {
                checkbox.Checked = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFlags();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}