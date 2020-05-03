using Core.BaseWeb.ViewModel.ValueObject;
using Core.Domain.Entities.Concrete.Database;

namespace Core.BaseWeb.ViewModel
{
    public class EstatisticasResultadosGeraisViewModel
    {
        public EstatisticasResultadosGeraisViewModel(TimeResultado melhorAtaque, TimeResultado melhorDefesa, TimeResultado maisVitorioso, TimeResultado menosVitorioso, TimeResultado maiorMediaDeVitorias, TimeResultado menorMediaDeVitorias)
        {
            MelhorAtaque = melhorAtaque;
            MelhorDefesa = melhorDefesa;
            MaisVitorioso = maisVitorioso;
            MenosVitorioso = menosVitorioso;
            MaiorMediaDeVitorias = maiorMediaDeVitorias;
            MenorMediaDeVitorias = menorMediaDeVitorias;
        }

        public TimeResultado MelhorAtaque { get; private set; }
        public TimeResultado MelhorDefesa { get; private set; }
        public TimeResultado MaisVitorioso { get; private set; }
        public TimeResultado MenosVitorioso { get; private set; }
        public TimeResultado MaiorMediaDeVitorias { get; private set; }
        public TimeResultado MenorMediaDeVitorias { get; private set; }

    }
}
