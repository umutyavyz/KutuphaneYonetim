using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneYonetimi
{
    public partial class OduncForm : Form
    {
        public OduncForm()
        {
            InitializeComponent();
        }

        private void OduncForm_Load(object sender, EventArgs e)
        {
            YukleComboBoxlar();
            ListeleOdunc();
        }


        int secilenKitapId = -1;



        private void YukleComboBoxlar()
        {
            cmbKitaplar.DataSource = DatabaseHelper.ExecuteSelectCommand("SELECT * FROM Kitaplar WHERE durum = 1");
            cmbKitaplar.DisplayMember = "ad";
            cmbKitaplar.ValueMember = "kitap_id";

            cmbUyeler.DataSource = DatabaseHelper.ExecuteSelectCommand("SELECT * FROM Uyeler");
            cmbUyeler.DisplayMember = "ad";
            cmbUyeler.ValueMember = "uye_id";
        }

        private void btnOduncAl_Click(object sender, EventArgs e)
        {
            string query = @"
            INSERT INTO OduncIslemleri (kitap_id, uye_id, odunc_tarihi) VALUES (@kitap_id, @uye_id, @tarih);
            UPDATE Kitaplar SET durum = 0 WHERE kitap_id = @kitap_id;";
            SqlParameter[] parameters = {
            new SqlParameter("@kitap_id", cmbKitaplar.SelectedValue),
            new SqlParameter("@uye_id", cmbUyeler.SelectedValue),
            new SqlParameter("@tarih", DateTime.Now)
        };
            DatabaseHelper.ExecuteNonQuery(query, parameters);
            YukleComboBoxlar();
            ListeleOdunc();
        }

        private void btnIadeEt_Click(object sender, EventArgs e)
        {
            if (secilenKitapId == -1)
            {
                MessageBox.Show("Lütfen iade edilecek kitabı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"
        UPDATE Kitaplar SET durum = 1 WHERE kitap_id = @kitap_id;
        UPDATE OduncIslemleri SET iade_tarihi = @iade 
        WHERE kitap_id = @kitap_id AND iade_tarihi IS NULL;";
            SqlParameter[] parameters = {
        new SqlParameter("@kitap_id", secilenKitapId),
        new SqlParameter("@iade", DateTime.Now)
    };

            try
            {
                DatabaseHelper.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Kitap başarıyla iade edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                YukleComboBoxlar();
                ListeleOdunc();
                secilenKitapId = -1; // Sıfırla
            }
            catch (Exception ex)
            {
                MessageBox.Show("İade sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ListeleOdunc()
        {
            dataGridView1.DataSource = DatabaseHelper.ExecuteSelectCommand("SELECT * FROM OduncIslemleri");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // kitap_id sütun adının veritabanındaki ve griddeki adla aynı olduğundan emin ol
                secilenKitapId = Convert.ToInt32(row.Cells["kitap_id"].Value);
            }
        }
    }
}
