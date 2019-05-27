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
                processFile();
                //processStream();
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

        private void startHour_ValueChanged(object sender, EventArgs e)
        {
            displayStartHour.Text = startHour.Value.ToString().PadLeft(2, '0');
            lblDone.Visible = false;
        }

        private void startMinutes_ValueChanged(object sender, EventArgs e)
        {
            displayStartMinutes.Text = startMinutes.Value.ToString().PadLeft(2, '0');
            lblDone.Visible = false;
        }

        private void startSeconds_ValueChanged(object sender, EventArgs e)
        {
            displayStartSeconds.Text = startSeconds.Value.ToString().PadLeft(2, '0');
            lblDone.Visible = false;
        }

        private void endHour_ValueChanged(object sender, EventArgs e)
        {
            displayEndHour.Text = endHour.Value.ToString().PadLeft(2, '0');
            lblDone.Visible = false;
        }

        private void endMinutes_ValueChanged(object sender, EventArgs e)
        {
            displayEndMinutes.Text = endMinutes.Value.ToString().PadLeft(2, '0');
            lblDone.Visible = false;
        }

        private void endSeconds_ValueChanged(object sender, EventArgs e)
        {
            displayEndSeconds.Text = endSeconds.Value.ToString().PadLeft(2, '0');
            lblDone.Visible = false;
        }

        private void processFile()
        {
            string splitDir = "";

            try
            {
                // no filename error
                if (txtOpenFilename.Text.Trim() == "")
                {
                    lblErrorMsg.Text = "filename is required!";
                    lblErrorMsg.Visible = true;
                    lblDone.Visible = false;
                    return;
                }

                var mp3Path = txtOpenFilename.Text;
                var mp3Dir = Path.GetDirectoryName(mp3Path);
                var mp3File = Path.GetFileName(mp3Path);
                splitDir = Path.Combine(mp3Dir, Path.GetFileNameWithoutExtension(mp3Path));
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

                // bad time range error
                if (endSecondsTotal < startSecondsTotal || endSecondsTotal == startSecondsTotal)
                {
                    lblErrorMsg.Text = "bad time range!";
                    lblErrorMsg.Visible = true;
                    lblDone.Visible = false;
                    return;
                }

                var splitLength = endSecondsTotal - startSecondsTotal;

                using (var reader = new Mp3FileReader(mp3Path))
                {
                    var outputFilename = String.Format("{7}{0} [{1}{2}m{3}s - {4}{5}m{6}s]",
                                                        Path.GetFileNameWithoutExtension(mp3Path),
                                                        evalHourTextForOutputFilename(startHour.Value),
                                                        startMinutes.Value,
                                                        startSeconds.Value,
                                                        evalHourTextForOutputFilename(endHour.Value),
                                                        endMinutes.Value,
                                                        endSeconds.Value,
                                                        evalOptionalTag());

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
                    lblErrorMsg.Visible = false;
                }
            }
            catch
            {
                Directory.Delete(splitDir);
                throw;
            }
        }

        private void processStream()
        {
            /*
                http://hwcdn.libsyn.com/p/0/e/c/0ecf0a466567e970/ep666beastmode.mp3?c_id=22289836&cs_id=22289836&expiration=1558928676&hwt=bef19cde314a5c2f11cc8b7d6dc041c5
            */

            string splitDir = "";

            try
            {
                // no filename error
                if (txtOpenFilename.Text.Trim() == "")
                {
                    lblErrorMsg.Text = "filename is required!";
                    lblErrorMsg.Visible = true;
                    lblDone.Visible = false;
                    return;
                }

                Directory.CreateDirectory(@"c:\snips\");

                // get all the values in seconds
                var sH = startHour.Value * 60 * 60;
                var sM = startMinutes.Value * 60;
                var sS = startSeconds.Value;
                var eH = endHour.Value * 60 * 60;
                var eM = endMinutes.Value * 60;
                var eS = endSeconds.Value;

                var startSecondsTotal = sH + sM + sS;
                var endSecondsTotal = eH + eM + eS;

                // bad time range error
                if (endSecondsTotal < startSecondsTotal || endSecondsTotal == startSecondsTotal)
                {
                    lblErrorMsg.Text = "bad time range!";
                    lblErrorMsg.Visible = true;
                    lblDone.Visible = false;
                    return;
                }

                var splitLength = endSecondsTotal - startSecondsTotal;

                using (Stream ms = new MemoryStream())
                {
                    using (Stream stream = WebRequest.Create(txtOpenFilename.Text)
                        .GetResponse().GetResponseStream())
                    {
                        byte[] buffer = new byte[32768];
                        int read;
                        while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ms.Write(buffer, 0, read);
                        }
                    }

                    using (var reader = new Mp3FileReader(ms))
                    {
                        var outputFilename = String.Format("{7}{0} [{1}{2}m{3}s - {4}{5}m{6}s]",
                                                            "podsnip_",
                                                            evalHourTextForOutputFilename(startHour.Value),
                                                            startMinutes.Value,
                                                            startSeconds.Value,
                                                            evalHourTextForOutputFilename(endHour.Value),
                                                            endMinutes.Value,
                                                            endSeconds.Value,
                                                            evalOptionalTag());

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
                        lblErrorMsg.Visible = false;
                    }
                }
            }
            catch
            {
                Directory.Delete(splitDir);
                throw;
            }
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
    }
}


