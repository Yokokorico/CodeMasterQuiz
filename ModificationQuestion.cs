namespace Classes;

public class ModifiicationQuestion{

    public static void SelectionQuestion(){

    }
    public static void ModifierQuestion(){

    }

    public static void SupprimerQuestion(){

    }

    public static void AjouterQuestion(List<RacineJson> source,Joueur joueur){
        bool verif=false;
        Console.WriteLine("Tout d'abord qu'elle est l'intitulé de t'as question ?");
        while(!verif){
            string intitule = Console.ReadLine();
            if(verificationChamps(intitule)){
                source[source.Count-1].Quizz[1].Questions[source[source.Count-1].Quizz[1].Questions.Count].IntituleQuestion = intitule;
                Console.WriteLine("Ensuite tu vas écrire 4 réponses possibles (Attention seulement une doit-être bonne !) ?");
            }
        }

    }

    public static bool verificationChamps(string texteAVerif){
        if(texteAVerif == null || texteAVerif =="" || texteAVerif == " "){
            return true;
        }else{
            return false;
        }
    }
}