﻿using System;
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
    public partial class FormCadastroContasPaga : Form
    {
        public FormCadastroContasPaga()
        {
            InitializeComponent();
        }

        private void buttonCancelarCadastroContasPagar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
