using Core.BaseWeb.ViewModel.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Application.Helper
{
    public static class TimeResultadoHelper
    {

        public static TimeResultado RemoveSelfReference(this TimeResultado entity)
        {
            entity.Time.Estado.SetTimes(null);
            entity.Time.SetPosicoes(null);
            return entity;
        }


    }
}
