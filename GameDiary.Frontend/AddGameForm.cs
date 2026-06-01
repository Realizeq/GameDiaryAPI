namespace GameDiary.Frontend
{
    public partial class AddGameForm : Form
    {
        public string GameTitle { get; private set; } = "";
        public string Platform { get; private set; } = "";
        public string Status { get; private set; } = "";
        public int Rating { get; private set; } = 5;

        public AddGameForm()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(27, 40, 56);
            this.ForeColor = Color.White;
            this.Text = "Добавление игры";

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

            btnOk.BackColor = Color.FromArgb(66, 165, 245);
            btnOk.ForeColor = Color.White;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.FlatAppearance.BorderSize = 0;

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
            cmbPlatform.SelectedIndex = 0;

            cmbStatus.Items.AddRange(new[] { "В процессе", "Пройдена", "Брошена", "Вишлист" });
            cmbStatus.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}