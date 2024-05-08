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

namespace Login
{
    public partial class Empleado : Form
    {
        public Empleado()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker1.CustomFormat = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("@Data source=GESTOR30\\SQLEXPRESS;Initial Catalog=empleadodb;Integrated Security=True;Trust Server Certificate=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into emtab values(@empleado,@empleadonombre,@position,@status,@fechacreacion)", con);
            cnn.Parameters.AddWithValue("@EmpleadoID", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@EmpleadoNombre", textBox2.Text);
            cnn.Parameters.AddWithValue("@Position", textBox3.Text);
            cnn.Parameters.AddWithValue("@Status", textBox4.Text);
            cnn.Parameters.AddWithValue("@FechaCreacion", dateTimePicker1.Value);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Registro guardado con éxito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("@Data Source=GESTOR30\\SQLEXPRESS;Initial Catalog=empleadodb;Integrated Security=True;Trust Server Certificate=True");
            con.Open();
            SqlCommand cnn = new SqlCommand(" select * from  emtab", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("@Data source=GESTOR30\\SQLEXPRESS;Initial Catalog=empleadodb;Integrated Security=True;Trust Server Certificate=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("delete from emptab where empleadoid=@empleadoid", con);
            cnn.Parameters.AddWithValue("@EmpleadoID", int.Parse(textBox1.Text));
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Registro eliminado con éxito", "eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
       