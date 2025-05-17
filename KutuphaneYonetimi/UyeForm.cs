using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KutuphaneYonetimi
{
    public partial class UyeForm : Form
    {
        public UyeForm()
        {
            InitializeComponent();
        }

        int secilenUyeId = -1;

        private void ListeleUyeler()
        {
            dataGridView1.DataSource = DatabaseHelper.ExecuteSelectCommand("SELECT * FROM Uyeler");
        }

        private void UyeForm_Load(object sender, EventArgs e)
        {
            ListeleUyeler();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {

            // Boşluk kontrolü
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtSoyad.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO Uyeler (ad, soyad) VALUES (@ad, @soyad)";
            SqlParameter[] parameters = {
        new SqlParameter("@ad", txtAd.Text.Trim()),
        new SqlParameter("@soyad", txtSoyad.Text.Trim())
    };

            try
            {
                DatabaseHelper.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Üye başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeleUyeler();

                // Alanları temizle
                txtAd.Clear();
                txtSoyad.Clear();
                txtAd.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Satır geçerli mi kontrol et
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                secilenUyeId = Convert.ToInt32(row.Cells["uye_id"].Value);

                // Seçilen verileri textbox'lara yüklemek istersen (isteğe bağlı):
                txtAd.Text = row.Cells["ad"].Value.ToString();
                txtSoyad.Text = row.Cells["soyad"].Value.ToString();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (secilenUyeId == -1)
            {
                MessageBox.Show("Lütfen silinecek bir üye seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bu üyeyi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM Uyeler WHERE uye_id = @id";
                SqlParameter[] parameters = {
            new SqlParameter("@id", secilenUyeId)
        };

                try
                {
                    DatabaseHelper.ExecuteNonQuery(query, parameters);
                    MessageBox.Show("Üye silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListeleUyeler();
                    secilenUyeId = -1;

                    // Textbox temizle
                    txtAd.Clear();
                    txtSoyad.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Silme sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
