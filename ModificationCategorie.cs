using Newtonsoft.Json;
namespace Classes;

public class ModificationCategorie{

    const string sep = "\n\n--------------------------------------------------\n\n";


    public static void SelectionUneCategorie(List<RacineJson> source,Joueur joueur){
        int index = 1;
        var verificationBonchoix = false;
        Console.WriteLine($"Veuillez choisir votre catégorie{sep}");
            foreach (RacineJson itemRoot in source)
            {
                Console.WriteLine(index + "." + itemRoot.Quizz[1].Category);
                index++;
            }
        Console.WriteLine($"{index}.Crée une nouvelle catégorie{sep}");
        while (!verificationBonchoix)
        {
            Console.WriteLine($"{sep}Votre choix ->");
            Int32.TryParse(Console.ReadLine(),out int num_quizz);
            if (num_quizz <= source.Count && num_quizz > 0)
            {
                num_quizz--;
                Console.WriteLine($"Catégorie {source[num_quizz].Quizz[1].Category}");
                Console.WriteLine($"1.Modifier\n2.Supprimer\n3.Retour au menu");
                while(!verificationBonchoix){
                    string choixSurCategorie = Console.ReadLine();
                    if(choixSurCategorie == "1"){
                        verificationBonchoix = true;
                        ModifierCategorie(source,num_quizz);
                    }else if(choixSurCategorie == "2"){
                        verificationBonchoix = true;
                        AjouterCategorie(source,joueur);
                    }else if(choixSurCategorie == "3"){
                        verificationBonchoix = true;
                        AffichageMenu.Demarrage(joueur);
                    }else{
                        Console.WriteLine("Veuillez répondre par 1,2 ou 3");
                    }
                }
            }else if(num_quizz>source.Count){
                AjouterCategorie(source,joueur);
            }
            else
            {
                Console.WriteLine("Merci de bien renseigner le chiffre de la catégorie!");
            }
        }
    }

    public static void ModifierCategorie(List<RacineJson> source,int num_quizz){
        var verif = false;
        string json;
        Console.WriteLine("Entrer le nouveau nom ->");
        while(!verif){
            string nomModifier=Console.ReadLine();
            if(nomModifier != null || nomModifier != "" || nomModifier != " "){
                source[num_quizz].Quizz[1].Category = nomModifier;
                json = JsonConvert.SerializeObject(source);
                using (StreamWriter sw = new StreamWriter("../../../question.json")){
                    sw.WriteLine(json);
                    sw.Dispose();
                    sw.Close();
                }
                verif=true;       
            }else{
                Console.WriteLine("Merci de bien écrire quelque chose pas de vide, pas d'espace");
            }
        }
        
    }

    public static void SupprimerCategorie(List<RacineJson> source,int num_quizz,Joueur joueur){
        bool verif=true;
        Console.WriteLine("ATTENTION SUPPRIMER LA CATEGORIE SUPPRIMERA LES QUESTION LIÉ A CELLE-CI\nEtes-vous sur de vouloir supprimer\n1.Oui\n2.Non");
        string confirmation=Console.ReadLine();
        while(!verif){
            if(confirmation=="1"){
                source.Remove(source[num_quizz]);
                Console.WriteLine("Supprimer ! Retour au Menu principal");
                Thread.Sleep(2000);
                Console.Clear();
                AffichageMenu.Demarrage(joueur);
            }else if(confirmation =="2"){
                AffichageMenu.Demarrage(joueur);
            }else{
                Console.WriteLine("Veuillez répondre par 1 ou 2");
            }
        }
    }

    public static void AjouterCategorie(List<RacineJson> source,Joueur joueur){
        var verif = false;
        string json;
        Console.WriteLine("Entrer le nouveau nom ->");
        while(!verif){
            string nomAjoutCategorie=Console.ReadLine();
            if(nomAjoutCategorie != null || nomAjoutCategorie != "" || nomAjoutCategorie != " "){
                RacineJson nouvelleCategorie = new RacineJson();
                Quizz fameuxContournementDeProbleme =new Quizz();
                nouvelleCategorie.Quizz.Add(fameuxContournementDeProbleme);
                source.Add(nouvelleCategorie);
                source[source.Count-1].Quizz[1].Category = nomAjoutCategorie; 
                
                Console.WriteLine("Une Catégorie sans question c'est nul non ? On va en ajouter une !");
                ModifiicationQuestion.AjouterQuestion(source,joueur);
                json = JsonConvert.SerializeObject(source);
                using (StreamWriter sw = new StreamWriter("../../../question.json")){
                    sw.WriteLine(json);
                    sw.Close();
                }
                verif=true;       
            }else{
                Console.WriteLine("Merci de bien écrire quelque chose pas de vide, pas d'espace");
            }
        }
        
    }

}