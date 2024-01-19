using System.Diagnostics;

namespace Classes;
public class CalculPoint{
    const string sep = "\n\n--------------------------------------------------\n\n";

    public static void CalculDesPoints(int numquiz, int numquestion, List<RacineJson> source, Joueur joueur, string DifficulteQuestion, string DescriptifQuestion, Stopwatch stopwatch, string rep)
    {
        Int32.TryParse(rep, out int comparateur);
        if (comparateur == source[numquiz].Quizz[0].Questions[numquestion].Resultat[0].Reponse)
        {
            stopwatch.Stop();
            Console.WriteLine($"Vous avez mis {stopwatch.ElapsedMilliseconds / 1000} secondes pour répondre\nBien joué !\n{sep}{DescriptifQuestion}{sep}");
            int temps = (int)stopwatch.ElapsedMilliseconds / 1000;
            PointsEnFonctionDuTemps(temps,joueur,DifficulteQuestion);
            Console.ReadLine();
            stopwatch.Reset();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"Mauvaise réponse ! C'était la réponse numéro {source[numquiz].Quizz[0].Questions[numquestion].Resultat[0].Reponse}\n{sep}{DescriptifQuestion}{sep}\nAppuyer sur une touche pour continuer !");
            Console.ReadLine();
            Console.Clear();
        }
    }

    public static void PointsEnFonctionDuTemps(int temps,Joueur joueur,string DifficulteQuestion)
    {
        Int32.TryParse(DifficulteQuestion,out int diffi);
        double points=0;
        if(temps<30){
            points = (1-((temps/30.0)/2))*(diffi*100);
        }else{
            Console.WriteLine("Vous avez dépassé la limite de temps de 30 secondes vous obtenez donc 0 point");
        }
        joueur.Scoreactuel = (int)joueur.Scoreactuel + (int)points;
        Console.WriteLine($"Vous gagnez {(diffi*points).ToString("#")} points ! Difficulté {DifficulteQuestion}\nVotre total de points est maintenant de {joueur.Scoreactuel}\nAppuyer sur une touche pour continuer !");
    }
}