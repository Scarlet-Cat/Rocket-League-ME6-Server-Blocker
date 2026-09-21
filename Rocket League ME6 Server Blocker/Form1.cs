using System.Text.Json;

namespace Rocket_League_ME6_Server_Blocker
{
    public partial class ServerBlockerForm : Form
    {
        bool serverBlockToggle = false;
        private readonly string roamingFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private readonly string programStateFolder;
        private const string programStateFileJsonName = "program State.json";
        private readonly string programStateFullPath;
        JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            IncludeFields = true,
        };

        public ServerBlockerForm()
        {
            InitializeComponent();
            programStateFolder = Path.Combine(roamingFolderPath, "Rocket League ME6 server Blocker");
            programStateFullPath = Path.Combine(programStateFolder, programStateFileJsonName);
        }

        struct ProgramState
        {
            public bool serverBlockToggle;
            public bool onlyBlockRocketCheckBoxToggle;
            public string rocketLeagueEXEPath;

            public ProgramState(bool serverBlockToggle, bool onlyBlockRocketCheckBoxToggle, string rocketLeagueEXEPath)
            {
                this.serverBlockToggle = serverBlockToggle;
                this.onlyBlockRocketCheckBoxToggle = onlyBlockRocketCheckBoxToggle;
                this.rocketLeagueEXEPath = rocketLeagueEXEPath;
            }
        }

        private void ServerBlockerForm_Load(object sender, EventArgs e)
        {
            onlyBlockRocketCheckBox.CheckedChanged -= onlyBlockRocketCheckBox_CheckedChanged;
            new ServerBlocker();
            loadProgramState();
            uiUpdate();
            onlyBlockRocketCheckBox.CheckedChanged += onlyBlockRocketCheckBox_CheckedChanged;
        }

        private void blockServerToggleButton_Click(object sender, EventArgs e)
        {
            if (!ServerBlocker.isRulesExist())
            {
                ServerBlocker.createRules();
            }
            serverBlockToggle = !serverBlockToggle;
            ServerBlocker.toggleRules(serverBlockToggle);
            saveProgramState();
            uiUpdate();
        }

        private void onlyBlockRocketCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (onlyBlockRocketCheckBox.Checked)
            {
                if (!File.Exists(programStateFullPath) || !ServerBlocker.checkForCorrectEXE())
                {
                    string defaultPath = fileBrowserDialog.FileName;
                    fileBrowserDialog.ShowDialog();
                    fileBrowserDialog.Multiselect = false;
                    string path = fileBrowserDialog.FileName;
                    if (defaultPath != path && validatePath(path) && ServerBlocker.checkForCorrectEXE(path))
                    {
                        ServerBlocker.setPath(path);
                    }
                }
            }
            ServerBlocker.toggleAffectRocketLeagueOnly(onlyBlockRocketCheckBox.Checked);
            saveProgramState();
        }
        private bool validatePath(string path)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("File doesn't exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void saveProgramState()
        {
            if (!Directory.Exists(programStateFolder))
            {
                Directory.CreateDirectory(programStateFolder);
            }
            using (FileStream saveFile = File.Create(programStateFullPath))
            {
                using StreamWriter streamWriter = new StreamWriter(saveFile);
                string json = JsonSerializer.Serialize(new ProgramState(serverBlockToggle: serverBlockToggle,
                                                       onlyBlockRocketCheckBoxToggle: onlyBlockRocketCheckBox.Checked,
                                                       rocketLeagueEXEPath: ServerBlocker.getPath()),
                                                       jsonSerializerOptions);
                streamWriter.Write(json);
            }
        }

        private void loadProgramState()
        {
            if (File.Exists(programStateFullPath))
            {
                string json = File.ReadAllText(programStateFullPath);
                ProgramState? programState = JsonSerializer.Deserialize<ProgramState>(json, jsonSerializerOptions);
                serverBlockToggle = programState?.serverBlockToggle ?? false;
                onlyBlockRocketCheckBox.Checked = programState?.onlyBlockRocketCheckBoxToggle ?? false;
                ServerBlocker.setPath(programState?.rocketLeagueEXEPath ?? "");
            }
        }
        private void uiUpdate()
        {
            blockServerToggleButton.Text = serverBlockToggle ? "Unblock server" : "Block server";
        }
        private void deleteSaveFiles()
        {
            if (Directory.Exists(programStateFolder))
            {
                Directory.Delete(programStateFolder, true);
            }
        }
        private void menuDropdown_reset_Click(object sender, EventArgs e)
        {
            ServerBlocker.resetPathToDefault();
            ServerBlocker.resetRules();
            blockServerToggleButton.Text = "Block server";
            onlyBlockRocketCheckBox.Checked = false;
            deleteSaveFiles();
        }
        private void menuDropdown_resetFilePath_Click(object sender, EventArgs e)
        {
            ServerBlocker.resetPathToDefault();
            if (Directory.Exists(programStateFolder))
            {
                Directory.Delete(programStateFolder, true);
            }
        }
        private void menuDropdown_deleteRules_Click(object sender, EventArgs e)
        {
            ServerBlocker.deleteRules();
        }
        private void menuDropdown_deleteAll_Click(object sender, EventArgs e)
        {
            ServerBlocker.deleteRules();
            deleteSaveFiles();
        }

        
    }
}
