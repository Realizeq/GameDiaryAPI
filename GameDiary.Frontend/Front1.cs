using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace GameDiary.Frontend
{
    public partial class Form1 : Form
    {
        private const string ApiUrl = "http://localhost:5081/api/games";
        private HttpClient _client;

        public Form1()
        {
            InitializeComponent();
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (m, c, ch, e) => true;
            _client = new HttpClient(handler);
            this.BackColor = Color.FromArgb(27, 40, 56);
            this.ForeColor = Color.White;

            dgvGames.BackgroundColor = Color.FromArgb(27, 40, 56);
            dgvGames.DefaultCellStyle.BackColor = Color.FromArgb(32, 48, 68);
            dgvGames.DefaultCellStyle.ForeColor = Color.White;
            dgvGames.DefaultCellStyle.SelectionBackColor = Color.FromArgb(66, 165, 245);
            dgvGames.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvGames.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 30, 48);
            dgvGames.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(100, 180, 255);
            dgvGames.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvGames.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvGames.GridColor = Color.FromArgb(50, 70, 90);
            dgvGames.EnableHeadersVisualStyles = false;

            btnAdd.BackColor = Color.FromArgb(66, 165, 245);
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            btnDelete.BackColor = Color.FromArgb(200, 60, 60);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            btnRefresh.BackColor = Color.FromArgb(50, 70, 90);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            btnEdit.BackColor = Color.FromArgb(80, 140, 80);
            btnEdit.ForeColor = Color.White;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnStats.BackColor = Color.FromArgb(100, 80, 180);
            btnStats.ForeColor = Color.White;
            btnStats.FlatStyle = FlatStyle.Flat;
            btnStats.FlatAppearance.BorderSize = 0;
            btnStats.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            pnlStats.BackColor = Color.FromArgb(20, 30, 48);
            pnlStats.Visible = false;

            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            this.Paint += (s, e) => {
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                    Color.FromArgb(60, 80, 100), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(60, 80, 100), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(60, 80, 100), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(60, 80, 100), 1, ButtonBorderStyle.Solid);
            };

            var titlePanel = new Panel();
            titlePanel.Size = new Size(this.ClientSize.Width, 35);
            titlePanel.Location = new Point(0, 0);
            titlePanel.BackColor = Color.FromArgb(15, 22, 35);
            this.Controls.Add(titlePanel);

            var lblTitle = new Label();
            lblTitle.Text = "🎮 Игровой дневник";
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(12, 8);
            lblTitle.BackColor = Color.Transparent;
            titlePanel.Controls.Add(lblTitle);

            var btnClose = new Button();
            btnClose.Text = "✕";
            btnClose.Size = new Size(35, 35);
            btnClose.Location = new Point(titlePanel.Width - 35, 0);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.BackColor = Color.FromArgb(200, 60, 60);
            btnClose.ForeColor = Color.White;
            btnClose.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnClose.Click += (s, e) => {
                foreach (var process in System.Diagnostics.Process.GetProcessesByName("GameDiary.API"))
                {
                    process.Kill();
                }
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            };
            titlePanel.Controls.Add(btnClose);

            var btnMinimize = new Button();
            btnMinimize.Text = "─";
            btnMinimize.Size = new Size(35, 35);
            btnMinimize.Location = new Point(titlePanel.Width - 75, 0);
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.BackColor = Color.FromArgb(15, 22, 35);
            btnMinimize.ForeColor = Color.White;
            btnMinimize.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            titlePanel.Controls.Add(btnMinimize);

            bool dragging = false;
            Point dragStart = Point.Empty;
            titlePanel.MouseDown += (s, e) => { dragging = true; dragStart = e.Location; };
            titlePanel.MouseMove += (s, e) => { if (dragging) this.Location = new Point(this.Location.X + e.X - dragStart.X, this.Location.Y + e.Y - dragStart.Y); };
            titlePanel.MouseUp += (s, e) => dragging = false;
            lblTitle.MouseDown += (s, e) => { dragging = true; dragStart = e.Location; };
            lblTitle.MouseMove += (s, e) => { if (dragging) this.Location = new Point(this.Location.X + e.X - dragStart.X, this.Location.Y + e.Y - dragStart.Y); };
            lblTitle.MouseUp += (s, e) => dragging = false;

            this.Font = new Font("Segoe UI", 9);
            this.Text = "Игровой дневник";
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadGames();
        }

        private async Task LoadGames()
        {
            try
            {
                var response = await _client.GetStringAsync(ApiUrl);
                var games = JsonSerializer.Deserialize<List<GameDto>>(response,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                dgvGames.DataSource = games;

                if (dgvGames.Columns["Id"] != null) dgvGames.Columns["Id"].Visible = false;
                if (dgvGames.Columns["Title"] != null) dgvGames.Columns["Title"].HeaderText = "Название";
                if (dgvGames.Columns["Platform"] != null) dgvGames.Columns["Platform"].HeaderText = "Платформа";
                if (dgvGames.Columns["Status"] != null) dgvGames.Columns["Status"].HeaderText = "Статус";
                if (dgvGames.Columns["AddedAt"] != null) dgvGames.Columns["AddedAt"].HeaderText = "Добавлена";
                if (dgvGames.Columns["CoverImageUrl"] != null) dgvGames.Columns["CoverImageUrl"].Visible = false;
                if (dgvGames.Columns["Reviews"] != null) dgvGames.Columns["Reviews"].Visible = false;

                if (!dgvGames.Columns.Contains("Оценка"))
                {
                    var ratingColumn = new DataGridViewTextBoxColumn();
                    ratingColumn.Name = "Оценка";
                    ratingColumn.HeaderText = "Оценка";
                    dgvGames.Columns.Add(ratingColumn);
                }

                foreach (DataGridViewRow row in dgvGames.Rows)
                {
                    var gameDto = row.DataBoundItem as GameDto;
                    if (gameDto?.Reviews != null && gameDto.Reviews.Count > 0)
                    {
                        var firstReview = System.Text.Json.JsonSerializer.Deserialize<ReviewDto>(
                            gameDto.Reviews[0].ToString()!,
                            new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        row.Cells["Оценка"].Value = firstReview?.Rating + "/10";
                    }
                    else
                    {
                        row.Cells["Оценка"].Value = "—";
                    }

                    var status = row.Cells["Status"].Value?.ToString();
                    if (status == "Пройдена")
                        row.Cells["Status"].Style.ForeColor = Color.FromArgb(100, 220, 100);
                    else if (status == "В процессе")
                        row.Cells["Status"].Style.ForeColor = Color.FromArgb(255, 200, 50);
                    else if (status == "Брошена")
                        row.Cells["Status"].Style.ForeColor = Color.FromArgb(220, 80, 80);
                    else if (status == "Вишлист")
                        row.Cells["Status"].Style.ForeColor = Color.FromArgb(130, 180, 255);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message);
            }
        }


        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadGames();
        }


        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddGameForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                var game = new
                {
                    title = addForm.GameTitle,
                    platform = addForm.Platform,
                    status = addForm.Status,
                    coverImageUrl = ""
                };

                var json = System.Text.Json.JsonSerializer.Serialize(game);
                var content = new System.Net.Http.StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(ApiUrl, content);
                var responseBody = await response.Content.ReadAsStringAsync();
                var createdGame = System.Text.Json.JsonSerializer.Deserialize<GameDto>(responseBody,
                    new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (createdGame != null && addForm.Rating > 0)
                {
                    var review = new
                    {
                        gameId = createdGame.Id,
                        rating = addForm.Rating,
                        comment = ""
                    };
                    var reviewJson = System.Text.Json.JsonSerializer.Serialize(review);
                    var reviewContent = new System.Net.Http.StringContent(reviewJson,
                        System.Text.Encoding.UTF8, "application/json");

                    try
                    {
                        var reviewResponse = await _client.PutAsync("http://localhost:5081/api/reviews/game/" + createdGame.Id, reviewContent);
                        var reviewBody = await reviewResponse.Content.ReadAsStringAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка отзыва: " + ex.Message);
                    }
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvGames.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выбери игру для удаления");
                return;
            }

            var id = (int)dgvGames.SelectedRows[0].Cells["Id"].Value;
            var confirm = MessageBox.Show("Удалить игру?", "Подтверждение",
                MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                await _client.DeleteAsync(ApiUrl + "/" + id);
                await LoadGames();
            }
        }
        private void btnStats_Click(object sender, EventArgs e)
        {
            if (pnlStats.Visible)
            {
                pnlStats.Visible = false;
                return;
            }

            int total = dgvGames.Rows.Count;
            int done = 0, inProgress = 0, dropped = 0, wishlist = 0;



            foreach (DataGridViewRow row in dgvGames.Rows)
            {
                var status = row.Cells["Status"].Value?.ToString();
                if (status == "Пройдена") done++;
                else if (status == "В процессе") inProgress++;
                else if (status == "Брошена") dropped++;
                else if (status == "Вишлист") wishlist++;



                pnlStats.Controls.Clear();

                var items = new (string text, Color color)[]
                {
        ($"Всего: {total}", Color.White),
        ($"Пройдено: {done}", Color.FromArgb(100, 220, 100)),
        ($"В процессе: {inProgress}", Color.FromArgb(255, 200, 50)),
        ($"Брошено: {dropped}", Color.FromArgb(220, 80, 80)),
        ($"Вишлист: {wishlist}", Color.FromArgb(130, 180, 255)),
                };

                int x = 15;
                foreach (var item in items)
                {
                    var lbl = new Label
                    {
                        Text = item.text,
                        ForeColor = item.color,
                        BackColor = Color.Transparent,
                        AutoSize = true,
                        Font = new Font("Segoe UI", 9, FontStyle.Bold),
                        Location = new Point(x, 28)
                    };
                    pnlStats.Controls.Add(lbl);
                    x += lbl.PreferredWidth + 25;
                }

                pnlStats.Visible = true;
            }
        }



        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvGames.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выбери игру для редактирования");
                return;
            }

            var id = (int)dgvGames.SelectedRows[0].Cells["Id"].Value;
            var title = dgvGames.SelectedRows[0].Cells["Title"].Value.ToString();
            var platform = dgvGames.SelectedRows[0].Cells["Platform"].Value.ToString();
            var status = dgvGames.SelectedRows[0].Cells["Status"].Value.ToString();

            var currentRating = 5;
            var ratingCell = dgvGames.SelectedRows[0].Cells["Оценка"].Value?.ToString();
            if (ratingCell != null && ratingCell != "—")
            {
                int.TryParse(ratingCell.Replace("/10", ""), out currentRating);
            }
            var editForm = new EditGameForm(id, title, platform, status, currentRating);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                var updated = new
                {
                    title = editForm.GameTitle,
                    platform = editForm.Platform,
                    status = editForm.Status,
                    coverImageUrl = ""
                };

                var json = System.Text.Json.JsonSerializer.Serialize(updated);
                var content = new System.Net.Http.StringContent(json,
                    System.Text.Encoding.UTF8, "application/json");
                await _client.PutAsync(ApiUrl + "/" + id, content);

                var review = new
                {
                    gameId = id,
                    rating = editForm.Rating,
                    comment = ""
                };
                var reviewJson = System.Text.Json.JsonSerializer.Serialize(review);
                var reviewContent = new System.Net.Http.StringContent(reviewJson,
                    System.Text.Encoding.UTF8, "application/json");
                await _client.PutAsync("http://localhost:5081/api/reviews/game/" + id, reviewContent);

                await LoadGames();
            }
        }
        public class GameDto
        {
            public int Id { get; set; }
            public string Title { get; set; } = "";
            public string Platform { get; set; } = "";
            public string Status { get; set; } = "";
            public string CoverImageUrl { get; set; } = "";
            public DateTime AddedAt { get; set; }
            public List<object> Reviews { get; set; } = new();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pnlStats_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    public class ReviewDto
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
