using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Conexão
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        MySqlCommand comando;
        MySqlDataAdapter da;
        MySqlDataReader dr;

        string strSQL;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection("Server=localhost;Database=cad_cliente;Uid=root;Pwd=");
                strSQL = "INSERT INTO cad_cliente (nome, numero) VALUES (@NOME, @NUMERO)";

                comando = new MySqlCommand(strSQL, conn);
                comando.Parameters.AddWithValue("@NOME", textBox2.Text);
                comando.Parameters.AddWithValue("@NUMERO", textBox3.Text);

                conn.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                conn = null;
                comando = null;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection("Server=localhost;Database=cad_cliente;Uid=root;Pwd=");
                strSQL = "UPDATE cad_cliente SET NOME = @NOME, NUMERO = @NUMERO WHERE ID = @ID";

                comando = new MySqlCommand(strSQL, conn);
                comando.Parameters.AddWithValue("@ID", textBox1.Text);
                comando.Parameters.AddWithValue("@NOME", textBox2.Text);
                comando.Parameters.AddWithValue("@NUMERO", textBox3.Text);

                conn.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                conn = null;
                comando = null;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection("Server=localhost;Database=cad_cliente;Uid=root;Pwd=");
                strSQL = "DELETE FROM cad_cliente WHERE ID = @ID";

                comando = new MySqlCommand(strSQL, conn);
                comando.Parameters.AddWithValue("@ID", textBox1.Text);

                conn.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                conn = null;
                comando = null;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection("Server=localhost;Database=cad_cliente;Uid=root;Pwd=");
                strSQL = "SELECT * FROM cad_cliente WHERE ID = @ID";

                comando = new MySqlCommand(strSQL, conn);
                comando.Parameters.AddWithValue("@ID", textBox1.Text);

                conn.Open();

                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    textBox2.Text = (dr["nome"]).ToString();
                    textBox3.Text = (dr["numero"]).ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                conn = null;
                comando = null;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection("Server=localhost;Database=cad_cliente;Uid=root;Pwd=");
                strSQL = "SELECT * FROM cad_cliente";

    

                da = new MySqlDataAdapter(strSQL, conn);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                conn = null;
                comando = null;

            }
        }
    }
}
