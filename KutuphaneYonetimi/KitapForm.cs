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
    public partial class KitapForm : Form
    {
        public KitapForm()
        {
            InitializeComponent();
        }


        int secilenKitapId = -1;

        private void ListeleKitaplar()
        {
            dataGridView1.DataSource = DatabaseHelper.ExecuteSelectCommand("SELECT * FROM Kitaplar");
        }

        private void KitaplariListele()
        {
            dataGridView1.DataSource = DatabaseHelper.ExecuteSelectCommand("SELECT * FROM Kitaplar");
        }

        private void KitapForm_Load(object sender, EventArgs e)
        {
            ListeleKitaplar();
        }


        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtYazar.Text))
            {
                MessageBox.Show("Lütfen kitap adı ve yazar alanlarını doldurunuz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO Kitaplar (ad, yazar, durum) VALUES (@ad, @yazar, 1)";
            SqlParameter[] parameters = {
    new SqlParameter("@ad", txtAd.Text),
    new SqlParameter("@yazar", txtYazar.Text)
};

            DatabaseHelper.ExecuteNonQuery(query, parameters);
            ListeleKitaplar();

            // TextBox'ları temizle
            txtAd.Clear();
            txtYazar.Clear();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                secilenKitapId = Convert.ToInt32(row.Cells["kitap_id"].Value);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (secilenKitapId == -1)
            {
                MessageBox.Show("Lütfen silinecek kitabı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Seçili kitabı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM Kitaplar WHERE kitap_id = @kitap_id";
                SqlParameter[] parameters = {
            new SqlParameter("@kitap_id", secilenKitapId)
        };

                try
                {
                    DatabaseHelper.ExecuteNonQuery(query, parameters);
                    MessageBox.Show("Kitap silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    secilenKitapId = -1;
                    KitaplariListele(); // varsa listeyi güncelleyen fonksiyon
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Silme işlemi sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
