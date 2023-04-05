﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Models;

namespace Financas
{
    public partial class FormCadastroBanco : Form
    {
        public int Id;
        public FormCadastroBanco(int id=0)
        {
            InitializeComponent();
            Id = id;
        }

          private void buttonCancelarCadBanco_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSalvarCadBanco_Click(object sender, EventArgs e)
        {
            BancoBLL BancoBLL = new BancoBLL();
            bancoBindingSource.EndEdit();

            if (Id == 0)
                BancoBLL.Inserir((Banco)bancoBindingSource.Current);
            else
                BancoBLL.Alterar((Banco)bancoBindingSource.Current);

            MessageBox.Show("Registro salvo com sucesso");
            Close();
        }
    }
}
