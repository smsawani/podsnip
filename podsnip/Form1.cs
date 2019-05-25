using System;
using System.Windows.Forms;
using System.IO;
using NAudio.Wave;

namespace podsnip
{
    public partial class podsnip : Form
    {
        public podsnip()
        {
            InitializeComponent();
        }

        private void btnSnip_Click(object sender, EventArgs e)
        {
            processFile();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1;
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            txtOpenFilename.Text = openFileDialog1.FileName.ToString();
            lblDone.Visible = false;
        }

        private void processFile()
        {
            var mp3Path = txtOpenFilename.Text;
            var mp3Dir = Path.GetDirectoryName(mp3Path);
            var mp3File = Path.GetFileName(mp3Path);
            var splitDir = Path.Combine(mp3Dir, Path.GetFileNameWithoutExtension(mp3Path));
            Directory.CreateDirectory(splitDir);

            // get all the values in seconds
            var sH = startHour.Value * 60 * 60;
            var sM = startMinutes.Value * 60;
            var sS = startSeconds.Value;
            var eH = endHour.Value * 60 * 60;
            var eM = endMinutes.Value * 60;
            var eS = endSeconds.Value;

            var startSecondsTotal = sH + sM + sS;
            var endSecondsTotal = eH + eM + eS;

            var splitLength = endSecondsTotal - startSecondsTotal;

            using (var reader = new Mp3FileReader(mp3Path))
            {
                var outputFilename = String.Format("{0}_{1}h{2}m{3}s_to_{4}h{5}m{6}s",
                                                    Path.GetFileNameWithoutExtension(mp3Path),
                                                    startHour.Value,
                                                    startMinutes.Value,
                                                    startSeconds.Value,
                                                    endHour.Value,
                                                    endMinutes.Value,
                                                    endSeconds.Value);

                FileStream writer = null;
                Action createWriter = new Action(() =>
                {
                    writer = File.Create(Path.Combine(splitDir, outputFilename + ".mp3"));
                });

                Mp3Frame frame;
                createWriter();

                while ((frame = reader.ReadNextFrame()) != null && writer.CanWrite == true)
                {
                    if ((int)reader.CurrentTime.TotalSeconds >= startSecondsTotal)
                        writer.Write(frame.RawData, 0, frame.RawData.Length);

                    // once we have passed the point in the reader that we needed, dispose writer
                    if ((int)reader.CurrentTime.TotalSeconds - startSecondsTotal >= splitLength)
                    {
                        // done!
                        writer.Dispose();
                    }
                }

                if (writer != null) writer.Dispose();

                lblDone.Visible = true;
            }

        }

        private void startHour_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = startHour.Value.ToString().PadLeft(2, '0');
        }

        private void startMinutes_ValueChanged(object sender, EventArgs e)
        {
            label3.Text = startMinutes.Value.ToString().PadLeft(2, '0');
        }

        private void startSeconds_ValueChanged(object sender, EventArgs e)
        {
            label5.Text = startSeconds.Value.ToString().PadLeft(2, '0');
        }

        private void endHour_ValueChanged(object sender, EventArgs e)
        {
            label8.Text = endHour.Value.ToString().PadLeft(2, '0');
        }

        private void endMinutes_ValueChanged(object sender, EventArgs e)
        {
            label7.Text = endMinutes.Value.ToString().PadLeft(2, '0');
        }

        private void endSeconds_ValueChanged(object sender, EventArgs e)
        {
            label6.Text = endSeconds.Value.ToString().PadLeft(2, '0');
        }
    }
}
