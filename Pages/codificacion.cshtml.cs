using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace IntroduccionRazor.Pages
{
    public class Index1Model : PageModel
    {
        [BindProperty]
        public string Mensaje { get; set; }

        [BindProperty]
        public int N { get; set; }

        public string Resultado { get; set; }

        public void OnPost(string accion)
        {
            if (!string.IsNullOrEmpty(Mensaje))
            {
                if (accion == "Codificar")
                {
                    Resultado = Cifrar(Mensaje, N);
                }
                else if (accion == "Decodificar")
                {
                    Resultado = Cifrar(Mensaje, -N);
                }
            }
        }

        private string Cifrar(string input, int n)
        {
            StringBuilder resultado = new StringBuilder();

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    bool esMayuscula = char.IsUpper(c);
                    char offset = esMayuscula ? 'A' : 'a';
                    char letraCifrada = (char)((c + n - offset) % 26 + offset);
                    resultado.Append(letraCifrada);
                }
                else
                {
                    resultado.Append(c);
                }
            }

            return resultado.ToString();
        }
    }
}
