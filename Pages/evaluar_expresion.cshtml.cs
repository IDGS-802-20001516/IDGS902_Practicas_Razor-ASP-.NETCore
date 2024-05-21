using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor.Pages
{
    public class ExpressionModel : PageModel
    {
        [BindProperty]
        public string A { get; set; } = "";
        [BindProperty]
        public string B { get; set; } = "";
        [BindProperty]
        public string X { get; set; } = "";
        [BindProperty]
        public string Y { get; set; } = "";
        [BindProperty]
        public string N { get; set; } = "";
        public double AX { get; set; } = 0;
        public double BY { get; set; } = 0;
        public double S { get; set; } = 0;
        public double P { get; set; } = 0;
        public string M { get; set; } = "";
        public List<double> R = new List<double>();

        public void OnPost()
        {
            if (string.IsNullOrWhiteSpace(A) || string.IsNullOrWhiteSpace(B) || string.IsNullOrWhiteSpace(X) || string.IsNullOrWhiteSpace(Y) || string.IsNullOrWhiteSpace(N))
            {
                M = "LLene los campos";
                return;
            }

            double aD = double.Parse(A);
            double bD = double.Parse(B);
            double xD = double.Parse(X);
            double yD = double.Parse(Y);
            double nD = double.Parse(N);
            AX = aD * xD;
            BY = bD * yD;
            S = AX + BY;

            P = 1.0;
            for (int i = 0; i < nD; i++)
            {
                P *= S;
            }

            R.Clear();

            for (int k = 0; k <= nD; k++)
            {
                double c = 1;
                for (int i = 1; i <= nD; i++)
                {
                    c *= i;
                }
                for (int i = 1; i <= k; i++)
                {
                    c /= i;
                }
                for (int i = 1; i <= nD - k; i++)
                {
                    c /= i;
                }

                double t = c;
                for (int i = 0; i < nD - k; i++)
                {
                    t *= aD * xD;
                }
                for (int i = 0; i < k; i++)
                {
                    t *= bD * yD;
                }
                R.Add(t);
            }

            ModelState.Clear();
        }
    }
}
