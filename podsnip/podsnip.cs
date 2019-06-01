using System;
using System.Windows.Forms;
using System.IO;
using System.Net;
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
            try
            {
                // start waiting cursor
                Cursor.Current = Cursors.WaitCursor;

                if (txtOpenFilename.Text.Trim().Contains("://"))
                {
                    processStream();
                }
                else
                {
                    processFile();
                }

                // end waiting cursor
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                clearForm();
                lblErrorMsg.Text = ex.Message;
                lblErrorMsg.Visible = true;
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1;
                openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                txtOpenFilename.Text = openFileDialog1.FileName.ToString();
                lblDone.Visible = false;
            }
            catch
            {
                throw;
            }
        }

        private void btnOutputFolder_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowserDialog1;
                folderBrowserDialog1 = new FolderBrowserDialog();
                folderBrowserDialog1.ShowDialog();
                txtOutputFolder.Text = folderBrowserDialog1.SelectedPath.ToString();
                lblDone.Visible = false;
            }
            catch
            {
                throw;
            }
        }

        private void calculateSnipLength()
        {
            DateTime startTime = Convert.ToDateTime(String.Format("{0}:{1}:{2}", displayStartHour.Text, displayStartMinutes.Text, displayStartSeconds.Text));
            DateTime endTime = Convert.ToDateTime(String.Format("{0}:{1}:{2}", displayEndHour.Text, displayEndMinutes.Text, displayEndSeconds.Text));
            TimeSpan snipLength = endTime - startTime;
            if (snipLength.TotalSeconds < 0)
            {
                lblSnipLength.Text = "00:00:00";
            }
            else
            {
                lblSnipLength.Text = snipLength.ToString();
            }
        }

        private void startHour_ValueChanged(object sender, EventArgs e)
        {
            displayStartHour.Text = startHour.Value.ToString().PadLeft(2, '0');
            lblDone.Visible = false;
            calculateSnipLength();
        }

        private void startMinutes_ValueChanged(object sender, EventArgs e)
        {
            displayStartMinutes.Text = startMinutes.Value.ToString().PadLeft(2, '0');
            lblDone.Visible = false;
            calculateSnipLength();
        }

        private void startSeconds_ValueChanged(object sender, EventArgs e)
        {
            displayStartSeconds.Text = startSeconds.Value.ToString().PadLeft(2, '0');
            lblDone.Visible = false;
            calculateSnipLength();
        }

        private void endHour_ValueChanged(object sender, EventArgs e)
        {
            displayEndHour.Text = endHour.Value.ToString().PadLeft(2, '0');
            lblDone.Visible = false;
            calculateSnipLength();
        }

        private void endMinutes_ValueChanged(object sender, EventArgs e)
        {
            displayEndMinutes.Text = endMinutes.Value.ToString().PadLeft(2, '0');
            lblDone.Visible = false;
            calculateSnipLength();
        }

        private void endSeconds_ValueChanged(object sender, EventArgs e)
        {
            displayEndSeconds.Text = endSeconds.Value.ToString().PadLeft(2, '0');
            lblDone.Visible = false;
            calculateSnipLength();
        }

        private string evalOptionalTag()
        {
            try
            {
                var optionalTag = "";

                if (txtOptionalTag.Text.Trim() != "")
                {
                    optionalTag = "[" + txtOptionalTag.Text + "] ";
                }
                else
                {
                    optionalTag = "";
                }
                return optionalTag;
            }
            catch
            {
                throw;
            }
        }

        private string evalHourTextForOutputFilename(decimal hour)
        {
            try
            {
                var hourForFilename = "";

                if (hour != 0)
                {
                    hourForFilename = hour.ToString() + "h";
                }
                else
                {
                    hourForFilename = "";
                }

                return hourForFilename;
            }
            catch
            {
                throw;
            }
        }

        private void txtOptionalTag_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^?:\\/:*?\""<>|]"))
            {
                e.Handled = true;
            }
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void clearForm()
        {
            txtOpenFilename.Text = "";
            txtOutputFolder.Text = @"C:\podsnip\";
            startHour.Value = 0;
            startMinutes.Value = 0;
            startSeconds.Value = 0;
            endHour.Value = 0;
            endMinutes.Value = 0;
            endSeconds.Value = 0;
            displayEndHour.Text = "00";
            displayEndMinutes.Text = "00";
            displayEndSeconds.Text = "00";
            displayStartHour.Text = "00";
            displayStartMinutes.Text = "00";
            displayStartSeconds.Text = "00";
            txtOptionalTag.Text = "";
            lblDone.Visible = false;
            lblErrorMsg.Visible = false;
        }

        private bool validateInputs(decimal startSecondsTotal, decimal endSecondsTotal)
        {
            try
            {
                // no filename error
                if (txtOpenFilename.Text.Trim() == "")
                {
                    lblErrorMsg.Text = "filename is required!";
                    lblErrorMsg.Visible = true;
                    lblDone.Visible = false;
                    return false;
                }

                // no output folder error
                if (txtOutputFolder.Text.Trim() == "")
                {
                    lblErrorMsg.Text = "output folder is required!";
                    lblErrorMsg.Visible = true;
                    lblDone.Visible = false;
                    return false;
                }

                // bad time range error
                if (endSecondsTotal < startSecondsTotal || endSecondsTotal == startSecondsTotal)
                {
                    lblErrorMsg.Text = "bad time range!";
                    lblErrorMsg.Visible = true;
                    lblDone.Visible = false;
                    return false;
                }

                return true;
            }
            catch
            {
                throw;
            }
        }

        private void processFile()
        {
            try
            {
                // get all the values in seconds
                var sH = startHour.Value * 60 * 60;
                var sM = startMinutes.Value * 60;
                var sS = startSeconds.Value;
                var eH = endHour.Value * 60 * 60;
                var eM = endMinutes.Value * 60;
                var eS = endSeconds.Value;

                var startSecondsTotal = sH + sM + sS;
                var endSecondsTotal = eH + eM + eS;

                if (!validateInputs(startSecondsTotal, endSecondsTotal))
                    return;

                var splitLength = endSecondsTotal - startSecondsTotal;

                var mp3Path = txtOpenFilename.Text;
                var mp3Dir = Path.GetDirectoryName(mp3Path);
                var mp3File = Path.GetFileName(mp3Path);
                Directory.CreateDirectory(txtOutputFolder.Text.Trim());

                // split this text into hours, minutes, seconds for the filename
                string[] totalTimePieces = lblSnipLength.Text.Split(':');

                var outputFilename = String.Format("{7}[{1}{2}m{3}s-{4}{5}m{6}s, {8}{9}m{10}s total] {0}",
                                                        Path.GetFileNameWithoutExtension(mp3Path),
                                                        evalHourTextForOutputFilename(startHour.Value),
                                                        startMinutes.Value,
                                                        startSeconds.Value,
                                                        evalHourTextForOutputFilename(endHour.Value),
                                                        endMinutes.Value,
                                                        endSeconds.Value,
                                                        evalOptionalTag(),
                                                        evalHourTextForOutputFilename(Convert.ToDecimal(totalTimePieces[0])),
                                                        Convert.ToDecimal(totalTimePieces[1]),
                                                        Convert.ToDecimal(totalTimePieces[2]));

                process(mp3Path, outputFilename, startSecondsTotal, splitLength);
            }
            catch
            {
                throw;
            }
        }

        private void processStream()
        {
            try
            {
                // get all the values in seconds
                var sH = startHour.Value * 60 * 60;
                var sM = startMinutes.Value * 60;
                var sS = startSeconds.Value;
                var eH = endHour.Value * 60 * 60;
                var eM = endMinutes.Value * 60;
                var eS = endSeconds.Value;

                var startSecondsTotal = sH + sM + sS;
                var endSecondsTotal = eH + eM + eS;

                if (!validateInputs(startSecondsTotal, endSecondsTotal))
                    return;

                // get the name of the mp3 out of the URL
                // 1. split on "?"
                // 2. split that result on "/"
                // 3. take last element of that as the mp3 name
                string[] split1 = txtOpenFilename.Text.Trim().Split('?');
                string[] split2 = split1[0].Split('/');
                string[] split3 = split2[split2.Length - 1].Split('.');
                string mp3Name = split3[0];

                Directory.CreateDirectory(txtOutputFolder.Text.Trim());
                var splitLength = endSecondsTotal - startSecondsTotal;

                HttpWebRequest dynamicRequest = (HttpWebRequest)WebRequest.Create(txtOpenFilename.Text.Trim());

                string mp3Path = Path.GetTempFileName();

                FileStream fs = new FileStream(mp3Path, FileMode.Create, FileAccess.Write);

                using (Stream stream = dynamicRequest.GetResponse().GetResponseStream())
                {
                    byte[] buffer = new byte[32768];
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fs.Write(buffer, 0, read);
                    }
                    fs.Close();
                }

                // split this text into hours, minutes, seconds for the filename
                string[] totalTimePieces = lblSnipLength.Text.Split(':');

                var outputFilename = String.Format("{7}[{1}{2}m{3}s-{4}{5}m{6}s, {8}{9}m{10}s total] {0}",
                                                       mp3Name,
                                                       evalHourTextForOutputFilename(startHour.Value),
                                                       startMinutes.Value,
                                                       startSeconds.Value,
                                                       evalHourTextForOutputFilename(endHour.Value),
                                                       endMinutes.Value,
                                                       endSeconds.Value,
                                                       evalOptionalTag(),
                                                       evalHourTextForOutputFilename(Convert.ToDecimal(totalTimePieces[0])),
                                                       Convert.ToDecimal(totalTimePieces[1]),
                                                       Convert.ToDecimal(totalTimePieces[2]));

                process(mp3Path, outputFilename, startSecondsTotal, splitLength);

                // TODO: <><><>< I SHOULD be able to delete the temp file, right??? ><><><>
            }
            catch
            {
                throw;
            }
        }

        private void process(string mp3Path, string outputFilename, decimal startSecondsTotal, decimal splitLength)
        {
            using (var reader = new Mp3FileReader(mp3Path))
            {
                FileStream writer = null;
                Action createWriter = new Action(() =>
                {
                    writer = File.Create(Path.Combine(txtOutputFolder.Text.Trim(), outputFilename + ".mp3"));
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
                lblErrorMsg.Visible = false;
            }
        }
    }
}