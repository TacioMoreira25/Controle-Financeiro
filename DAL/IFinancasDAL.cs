using FinanceControl.Models;
using System.Collections.Generic;

namespace FinanceControl.DAL
{
    public interface IFinancasDAL
    {
        IEnumerable<RelatorioDespesa> GetAllDespesas();
        IEnumerable<RelatorioDespesa> GetFiltraDespesa(string criterio);
        void AddDespesa(RelatorioDespesa despesa);
        int UpdateDespesa(RelatorioDespesa despesa);
        RelatorioDespesa GetDespesa(int id);
        void DeleteDespesa(int id);
        Dictionary<string, decimal> CalculaDespesaPeriodo(int periodo);
        Dictionary<string, decimal> CalculaDespesaPeriodoSemanal( int  periodo);
    }   
}
