﻿using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReceitaBLL
    {
        public void Inserir(Receita _receita, ContasReceber _contasReceber = null)
        {
            _receita.Descricao = _receita.Descricao.Trim();
            if (Constantes.IdUsuarioLogado == -1)
                throw new Exception("Este usuário não possui permissão para realizar essa operação.");
            if (_contasReceber != null && _contasReceber.DataPagamento != null && _contasReceber.DataPagamento.Value.Year > 2000)
                throw new Exception("Este registro já foi pago!");
            if (_receita.Descricao.Length < 3)
                throw new Exception("O campo descrição deve ter mais que dois caracteres!") { Data = { { "Id", 0 } } };

            new ReceitaDAL().Inserir(_receita, _contasReceber);
        }
        public void Alterar(Receita _receita)
        {
            if (Constantes.IdUsuarioLogado == -1)
                throw new Exception("Este usuário não possui permissão para realizar essa operação.");
            new ReceitaDAL().Alterar(_receita);
        }
        public void Excluir(int _id)
        {
            if (Constantes.IdUsuarioLogado == -1)
                throw new Exception("Este usuário não possui permissão para realizar essa operação.");
            int idContasReceber = new ReceitaDAL().BuscarPorId(_id).IdContasReceber;

            if (idContasReceber != 0)
                throw new Exception("Registro não pode ser excluido, porque é preciso estornar o registro de contas a receber de id: " + idContasReceber);

            new ReceitaDAL().Excluir(_id);
        }
        public List<Receita> BuscarTodos()
        {
            return new ReceitaDAL().BuscarTodos();
        }
        public List<Receita> BuscarPorDescricao(string _descricao)
        {
            return new ReceitaDAL().BuscarPorDescricao(_descricao);
        }
        public Receita BuscarPorId(int _id)
        {
           return new ReceitaDAL().BuscarPorId(_id);
        }
        public List<Receita> BuscarPorPeriodo(DateTime _periodoInicial, DateTime _periodoFinal)
        {
            if (_periodoInicial > _periodoFinal)
                throw new Exception("Data inicial não pode ser maior que a data final");

            return new ReceitaDAL().BuscarPorPeriodo(_periodoInicial, _periodoFinal);
        }
        public List<Receita> BuscarPorContato(string _contato)
        {
            return new ReceitaDAL().BuscarPorContato(_contato);
        }
        public List<Receita> BuscarPorFormaPagamento(string _formaPagamento)
        {
            return new ReceitaDAL().BuscarPorFormaPagamento(_formaPagamento);
        }
        public List<Receita> BuscarPorBanco(string _banco)
        {
            return new ReceitaDAL().BuscarPorBanco(_banco);
        }

    }
}
