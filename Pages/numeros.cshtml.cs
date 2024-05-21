using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor.Pages
{
    public class numerosModel : PageModel
    {
        public int[] Numeros { get; set; }
        public int Suma { get; set; }
        public double Promedio { get; set; }
        public List<int> Moda { get; set; }
        public double Mediana { get; set; }

        public void OnPost()
        {
            var random = new Random();
            Numeros = new int[20];
            for (int i = 0; i < Numeros.Length; i++)
            {
                Numeros[i] = random.Next(0, 101);
            }

            Suma = Numeros.Sum();
            Promedio = Numeros.Average();
            Moda = CalcularModa(Numeros);
            Mediana = CalcularMediana(Numeros);
        }

        private List<int> CalcularModa(int[] numeros)
        {
            var frecuencia = numeros.GroupBy(n => n)
                                    .ToDictionary(g => g.Key, g => g.Count());
            int maxFrecuencia = frecuencia.Values.Max();

            return frecuencia.Where(f => f.Value == maxFrecuencia)
                             .Select(f => f.Key)
                             .ToList();
        }

        private double CalcularMediana(int[] numeros)
        {
            var numerosOrdenados = numeros.OrderBy(n => n).ToArray();
            int n = numerosOrdenados.Length;
            if (n % 2 == 0)
            {
                return (numerosOrdenados[n / 2 - 1] + numerosOrdenados[n / 2]) / 2.0;
            }
            else
            {
                return numerosOrdenados[n / 2];
            }
        }
    }
}
