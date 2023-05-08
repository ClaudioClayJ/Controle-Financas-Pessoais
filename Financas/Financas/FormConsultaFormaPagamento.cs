﻿using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financas
{
    public partial class FormConsultaFormaPagamento : Form
    {
        public int Id;
        public string Descricao;
        public FormConsultaFormaPagamento(bool _selecionar = false)
        {
            InitializeComponent();
            buttonSelecionar.Visible = _selecionar;
        }

        private void buttonBuscarFormaPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        formaPagamentoBindingSource.DataSource = new FormaPagamentoBLL().BuscarTodos();
                        break;
                    case 1:
                        formaPagamentoBindingSource.DataSource = new FormaPagamentoBLL().BuscarPorDescricao(textBoxConsultarFormaPagamento.Text);
                        break;
                    case 2:
                        formaPagamentoBindingSource.DataSource = new FormaPagamentoBLL().BuscarPorInativo(textBoxConsultarFormaPagamento.Text);
                        break;


                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAlterarFormaPagamento_Click(object sender, EventArgs e)
        {
            int id = ((FormaPagamento)formaPagamentoBindingSource.Current).Id;
            using (FormCadastroFormaPagamento frm = new FormCadastroFormaPagamento(id))
            {
                frm.ShowDialog();
            }
            buttonBuscarFormaPagamento_Click(null, null);
        }

        private void buttonExcluirFormaPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                if (formaPagamentoBindingSource.Count <= 0)
                {
                    MessageBox.Show("Não existe registro para ser excluído");
                    return;
                }

                if (MessageBox.Show("Deseja realmente excluir este registro?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                int id = ((FormaPagamento)formaPagamentoBindingSource.Current).Id;
                new FormaPagamentoBLL().Excluir(id);
                formaPagamentoBindingSource.RemoveCurrent();

                MessageBox.Show("Registro excluído com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonAdicionarFormaPagamento_Click(object sender, EventArgs e)
        {
            using (FormCadastroFormaPagamento frm = new FormCadastroFormaPagamento())
            {
                frm.ShowDialog();
            }
            buttonBuscarFormaPagamento_Click(null, null);
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAdicionarFormaPagamento_Click_1(object sender, EventArgs e)
        {
            using (FormCadastroFormaPagamento frm = new FormCadastroFormaPagamento())
            {
                frm.ShowDialog();
            }
            buttonBuscarFormaPagamento_Click(null, null);
        }

        private void buttonSair_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSelecionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (formaPagamentoBindingSource.Count > 0)
                {
                    if (!((FormaPagamento)formaPagamentoBindingSource.Current).Ativo)
                        throw new Exception("Esta forma de pagamento está inativa. Você precisa ativá-la ou escolher outra.");

                    Id = ((FormaPagamento)formaPagamentoBindingSource.Current).Id;
                    Descricao = ((FormaPagamento)formaPagamentoBindingSource.Current).Descricao;
                    Close();
                }
                else
                    MessageBox.Show("Não existe um Devedor para ser selecionado.");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void FormConsultaFormaPagamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void FormConsultaFormaPagamento_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\ProjetoFundo2.png");
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;

            this.label2.ForeColor = System.Drawing.SystemColors.Control;

            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;

        }


    }
}
