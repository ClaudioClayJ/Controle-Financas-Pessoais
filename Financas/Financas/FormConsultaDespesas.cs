﻿using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace Financas
{
    public partial class FormConsultaDespesas : Form
    {
        public FormConsultaDespesas()
        {
            InitializeComponent();
        }

        private void despesasDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //switch (comboBox1.SelectedIndex)
                //{
                //    case 0:
                //        despesasBindingSource.DataSource = new DespesasBLL().BuscarTodos();
                //        break;
                //    case 1:
                //        despesasBindingSource.DataSource = new DespesasBLL().BuscarPorId(Convert.ToInt32(textBoxBuscarDespesas.Text));
                //        break;
                //    case 2:
                //        despesasBindingSource.DataSource = new DespesasBLL().BuscarPorDescricao(textBoxBuscarDespesas.Text);
                //        break;
                //    case 3:
                //        despesasBindingSource.DataSource = new DespesasBLL().BuscarPorPeriodo(Convert.ToDateTime(textBoxBuscarDespesas.Text), Convert.ToDateTime(textBoxBuscarDespesas2.Text));
                //        break;
                //    case 4:
                //        despesasBindingSource.DataSource = new DespesasBLL().BuscarPorContato(textBoxBuscarDespesas.Text);
                //        break;
                //    case 5:
                //        despesasBindingSource.DataSource = new DespesasBLL().BuscarPorFormaPagamento(textBoxBuscarDespesas.Text);
                //        break;
                //    case 6:
                //        despesasBindingSource.DataSource = new DespesasBLL().BuscarPorBanco(textBoxBuscarDespesas.Text);
                //        break;
                //    default:
                //        break;
                //}
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            using (FormConsultaDespesas frm = new FormConsultaDespesas())
            {
                frm.ShowDialog();
            }
            buttonBuscar_Click(null, null);
        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            int id = ((Despesas)despesasBindingSource.Current).Id;
            using (FormCadastroDespesas frm = new FormCadastroDespesas(id))
            {
                frm.ShowDialog();
            }
            buttonBuscar_Click(null, null);
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            if (despesasBindingSource.Count <= 0)
            {
                MessageBox.Show("Não existe registro para ser excluído");
                return;
            }

            if (MessageBox.Show("Deseja realmente excluir este registro?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            int id = ((Receita)despesasBindingSource.Current).Id;
            new ReceitaBLL().Excluir(id);
            despesasBindingSource.RemoveCurrent();

            MessageBox.Show("Registro excluído com sucesso!");
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxBuscarDespesas.Width = 498;
            textBoxBuscarDespesas2.Visible = false;

            if (comboBox1.SelectedIndex == 3)
            {
                textBoxBuscarDespesas.Width = 248;
                textBoxBuscarDespesas2.Visible = true;
            }
        }
    }
}
