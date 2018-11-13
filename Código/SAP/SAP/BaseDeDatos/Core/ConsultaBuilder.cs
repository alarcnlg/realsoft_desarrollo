using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.BaseDeDatos.Core
{
    class ConsultaBuilder
    {
        string _tabla;
        string _campos;
        string _criterio;
        string _join;
        string _group;
        string _order;
        string _limit;

        public ConsultaBuilder()
        {
            _tabla = "";
            _campos = "";
            _criterio = "";
            _join = "";
            _group = "";
            _order = "";
            _limit = "";
        }

        public ConsultaBuilder(string tabla) {
            _tabla = tabla + " ";
            _campos = "";
            _criterio = "";
            _join = "";
            _group = "";
            _order = "";
            _limit = "";
        }

        public void AsignarTabla(string tabla)
        {
            _tabla = tabla + " ";
        }

        public void AgregarCampo(string campo) {
            if (_campos.Length > 0) {
                _campos += ", ";
            }
            _campos += campo + " ";
        }

        public void AgregarJoin(string join)
        {
            _join += join + " ";
        }

        public void AgregarCriterio(string criterio)
        {
            if (_criterio.Length > 0)
            {
                _criterio += "AND ";
            }
            _criterio += criterio + " ";
        }

        public void AgregarGroupBy(string group)
        {
            if (_group.Length > 0)
            {
                _group += ", ";
            }
            _group += group + " ";
        }

        public void AgregarOrderBy(string order)
        {
            if (_order.Length > 0)
            {
                _order += ", ";
            }
            _order += order + " ";
        }

        public void AgregarLimit(string limit)
        {
            _limit = limit + " ";
        }

        public override string ToString() {
            string sql = "SELECT " + (_campos.Length > 0 ? _campos : "* ") + "FROM " + _tabla;
            sql += _join + (_criterio.Length > 0 ? "WHERE " + _criterio : " ");
            sql += _group.Length > 0 ? "GROUP BY " + _group : " ";
            sql += _order.Length > 0 ? "ORDER BY " + _order : " ";
            sql += _limit.Length > 0 ? "LIMIT " + _limit : " ";
            return sql;
        }

    }
}
