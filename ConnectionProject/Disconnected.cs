﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
namespace ConnectionProject
{
    public partial class Disconnected : Form
    {
        string ordb = "Data source=orcl;User Id=scott;Password=tiger;";
        OracleConnection conn;
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        public Disconnected()
        {
            InitializeComponent();
        }

        private void Disconnected_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string The_connection = " Data Source=orcl;User id=scott ;password=tiger;";
            string selection = @"select singerid,singer,musicrate
                                from music  
                                where musicname=:n";

            adapter = new OracleDataAdapter(selection, The_connection);
            adapter.SelectCommand.Parameters.Add("n", textBox1.Text);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
            MessageBox.Show("Update Succesfully");
        }

        private void Disconnected_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ConnectionForm connectionForm = new ConnectionForm();
            connectionForm.Show();
        }
    }
}
