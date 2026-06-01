namespace GameDiary.Frontend
{
    public partial class EditGameForm : Form
    {
        public string GameTitle { get; private set; } = "";
        public string Platform { get; private set; } = "";
        public string Status { get; private set; } = "";
        public int Rating { get; private set; } = 5;

        public EditGameForm(int id, string title, string platform, string status, int rating)
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(27, 40, 56);
            this.ForeColor = Color.White;
            this.Text = "Редактирование игры";

            txtTitle.BackColor = Color.FromArgb(32, 48, 68);
            txtTitle.ForeColor = Color.White;
            txtTitle.BorderStyle = BorderStyle.FixedSingle;

            cmbPlatform.BackColor = Color.FromArgb(32, 48, 68);
            cmbPlatform.ForeColor = Color.White;
            cmbPlatform.FlatStyle = FlatStyle.Flat;

            cmbStatus.BackColor = Color.FromArgb(32, 48, 68);
            cmbStatus.ForeColor = Color.White;
            cmbStatus.FlatStyle = FlatStyle.Flat;

            nudRating.BackColor = Color.FromArgb(32, 48, 68);
            nudRating.ForeColor = Color.White;

            btnSave.BackColor = Color.FromArgb(80, 140, 80);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;

            btnCancel.BackColor = Color.FromArgb(200, 60, 60);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;

            this.Font = new Font("Segoe UI", 9);
            label1.ForeColor = Color.FromArgb(199, 213, 224);
            label1.BackColor = Color.Transparent;
            label2.ForeColor = Color.FromArgb(199, 213, 224);
            label2.BackColor = Color.Transparent;
            label3.ForeColor = Color.FromArgb(199, 213, 224);
            label3.BackColor = Color.Transparent;
            label4.ForeColor = Color.FromArgb(199, 213, 224);
            label4.BackColor = Color.Transparent;

            cmbPlatform.Items.AddRange(new[] { "PC", "PS5", "PS4", "Xbox", "Nintendo Switch" });
            cmbStatus.Items.AddRange(new[] { "В процессе", "Пройдена", "Брошена", "Вишлист" });

            txtTitle.Text = title;
            cmbPlatform.SelectedItem = platform;
            cmbStatus.SelectedItem = status;
            nudRating.Value = rating;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Введи название игры!");
                return;
            }

            GameTitle = txtTitle.Text;
            Platform = cmbPlatform.SelectedItem?.ToString() ?? "PC";
            Status = cmbStatus.SelectedItem?.ToString() ?? "В процессе";
            Rating = (int)nudRating.Value;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EditGameForm_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}