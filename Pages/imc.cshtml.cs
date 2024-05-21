using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor.Pages
{
    public class imcModel : PageModel
    {
        [BindProperty]
        public double Peso { get; set; }

        [BindProperty]
        public double Altura { get; set; }

        public double? IMC { get; set; }
        public string Clasificacion { get; set; }
        public string Imagen { get; set; }

        public void OnPost()
        {
            if (Peso > 0 && Altura > 0)
            {
                IMC = Peso / (Altura * Altura);

                if (IMC < 18)
                {
                    Clasificacion = "Peso Bajo";
                    Imagen = "peso_bajo.png";
                }
                else if (IMC >= 18 && IMC < 25)
                {
                    Clasificacion = "Peso Normal";
                    Imagen = "normal.png";
                }
                else if (IMC >= 25 && IMC < 27)
                {
                    Clasificacion = "Sobrepeso";
                    Imagen = "sobrepeso.png";
                }
                else if (IMC >= 27 && IMC < 30)
                {
                    Clasificacion = "Obesidad grado I";
                    Imagen = "obesidad_grado1.png";
                }
                else if (IMC >= 30 && IMC < 40)
                {
                    Clasificacion = "Obesidad grado II";
                    Imagen = "obesidad_grado2.png";
                }
                else if (IMC >= 40)
                {
                    Clasificacion = "Obesidad grado III";
                    Imagen = "obesidad_grado3.png";
                }
            }
        }
    }
}
