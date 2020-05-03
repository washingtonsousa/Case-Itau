using Core.Domain.Entities.Concrete.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BaseWeb.ViewModel.ValueObject
{
    public class TimeResultado
    {
        public TimeResultado(Time time, int valor)
        {
            Time = time;
            Valor = valor;
        }

        public Time Time { get; private set; }
        public int Valor { get; private set; }

    }
}
