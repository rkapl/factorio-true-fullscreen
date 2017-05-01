using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace factorio_patcher
{
    public partial class FactorioPatcher : Form
    {
        private OpenFileDialog dlg = new OpenFileDialog();
        public FactorioPatcher()
        {
            InitializeComponent();
        }
        private void patch_Click(object sender, EventArgs eargs)
        {
            int w,h;
            try{
                w = int.Parse(width.Text);
                h = int.Parse(height.Text);
            }catch(FormatException e){
                 MessageBox.Show(this, e.Message, "Width and height not number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
            }

            try
            {
                var data = File.ReadAllBytes(FilePath);
                var matcher = new Matcher(data);
                matcher.Find(
                    0xB9, 0x10, 0x02, 0x00, 0x00,  // mov ecx, 0x210
                    0xB8, 0x10, 0x00, 0x00, 0x00); // mov eax, 0x10
                matcher.Patch(
                    0xB9, 0x02, 0x00, 0x00, 0x00, // mov ecx, 0x2 (FULLSCREEN, not RESIZABLE)
                    0xB8, 0x10, 0x00, 0x00, 0x00);

                matcher.Find(
                    0x41, 0x0F, 0xBF, 0xDD,        // movsz ebx, r13w
                    0x45, 0x0F, 0xBF, 0xFF,        // movszx r15d, r15w
                    0x44, 0x8B, 0xC3,              // mov r8d, ebx
                    0x41, 0x8B, 0xD7,              // mov edx, r15d
                    0x8B, 0xCE,                    // mov ecx, esi
                    0xE8                           // jmp
                );
                matcher.Patch(
                    0xB9, (byte) (w), (byte)(w >> 8), 0x00, 0x00,
                    0xBA, (byte) (h), (byte)(h >> 8), 0x00, 0x00,
                    0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90,
                    0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90
                );

                File.Copy(file.Text, FileBackupPath, true);
                File.WriteAllBytes(FilePath, matcher.Data);
                restore.Enabled = true;
            }

            

            catch (IOException e)
            {
                MessageBox.Show(this, e.Message, "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (MatchException)
            {
                MessageBox.Show(this, "The factorio file is unknown or already patched.", "Patch exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Patched.", "Done");
        }

        public string FilePath
        {
            get
            {
                return file.Text;
            }
        }
        public string FileBackupPath
        {
            get
            {
                return file.Text + ".backup";
            }
        }

        private void FactorioPatcher_Load(object sender, EventArgs e)
        {
            file_TextChanged(null, null);
            foreach(var m in Mode.ListModes()){
                modes.Items.Add(m);
            }
        }

        private void modes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var m = (Mode) modes.SelectedItem;
            if (m == null)
                return;
            width.Text = m.W.ToString();
            height.Text = m.H.ToString();
        }

        private void file_TextChanged(object sender, EventArgs e)
        {
            restore.Enabled = File.Exists(FileBackupPath);
        }

        private void restore_Click(object sender, EventArgs eargs)
        {
            try
            {
                File.Copy(FileBackupPath, FilePath, true);
            }
            catch (IOException e)
            {
                MessageBox.Show(this, e.Message, "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Restored.", "Done");
        }

        private void selectFile_Click(object sender, EventArgs e)
        {
            dlg.Filter = "Executables (*.exe)|*.exe|All files (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                file.Text = dlg.FileName;
            }
        }

    }
}
