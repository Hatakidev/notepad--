namespace notepadd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Notepad" + openFileDialog.FileName;
        }
        OpenFileDialog openFileDialog = new OpenFileDialog();
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Height = ClientSize.Height;
            pictureBox1.Width = ClientSize.Width;
            pictureBox1.Show();
            MessageBox.Show("Хахахаха попался");
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowColor = false;
            fontDialog.Font = textBox1.Font;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.ForeColor = colorDialog.Color;
                menuStrip1.ForeColor = colorDialog.Color;
            }
        }

        private void formColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.BackColor = colorDialog.Color;
                this.BackColor = colorDialog.Color;
                menuStrip1.BackColor = colorDialog.Color;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream stream;
            openFileDialog.Filter = "text files (*.txt)|*.txt";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((stream = openFileDialog.OpenFile()) != null)
                {
                    stream.Close();
                    StreamReader streamReader = new StreamReader(openFileDialog.FileName);
                    string value = streamReader.ReadToEnd();
                    streamReader.Close();
                    textBox1.Text = value;
                }
            }
            this.Text = "Notepad " + openFileDialog.FileName;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter(openFileDialog.FileName);
                streamWriter.Write(textBox1.Text);
                streamWriter.Close();
                MessageBox.Show("Сохранено в " + openFileDialog.FileName);

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Не указана директория", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                saveAsToolStripMenuItem_Click(sender, e);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream stream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "text files (*.txt)|*.txt";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((stream = saveFileDialog.OpenFile()) != null)
                {

                    stream.Close();
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                    streamWriter.Write(textBox1.Text);
                    streamWriter.Close();

                }
            }
            this.Text = "Notepad " + saveFileDialog.FileName;
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                StreamReader reader = new StreamReader(openFileDialog.FileName);
                string text = reader.ReadToEnd();
                reader.Close();
                if (text != textBox1.Text)
                {
                    if (MessageBox.Show("Вы не сохранили файл. Сохранить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        StreamWriter streamWriter = new StreamWriter(openFileDialog.FileName);
                        streamWriter.Write(textBox1.Text);
                        streamWriter.Close();
                    }
                }
            }
            catch (ArgumentException)
            {
                return;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ты попался дебил тупой, можешь закрывать");
        }
    }
}